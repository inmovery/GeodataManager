using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using GeoDataManager.Contracts;

namespace GeoDataManager.Services.HttpRequests
{
	public class HttpRequestService : IHttpRequestService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HttpRequestService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<Tuple<T?, HttpStatusCode, string>> GetAsync<T>(HttpRequestMessage httpRequestMessage)
		{
			using var httpClient = _httpClientFactory.CreateClient();
			return await ExecuteRequest<T>(httpClient, httpRequestMessage);
		}

		public async Task<Tuple<T?, HttpStatusCode, string>> PostAsync<T>(HttpRequestMessage httpRequestMessage, IDataRequest dataRequest)
		{
			using var httpClient = _httpClientFactory.CreateClient();
			using var httpContent = await Serialize(dataRequest);
			httpRequestMessage.Content = httpContent;

			return await ExecuteRequest<T>(httpClient, httpRequestMessage);
		}

		private async Task<Tuple<T?, HttpStatusCode, string>> ExecuteRequest<T>(HttpClient httpClient, HttpRequestMessage httpRequestMessage)
		{
			using var httpResponse = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
			var deserializedObject = await Deserialize<T>(httpResponse);

			if (!httpResponse.IsSuccessStatusCode)
				return Tuple.Create(deserializedObject, httpResponse.StatusCode, string.Empty);

			var errorDetails = await httpResponse.Content.ReadAsStringAsync();

			return Tuple.Create(deserializedObject, httpResponse.StatusCode, errorDetails);
		}

		private async Task<HttpContent> Serialize(IDataRequest request)
		{
			var serializer = JsonSerializer.CreateDefault();

			var content = new MemoryStream();
			await using (var streamWriter = new StreamWriter(content, new UTF8Encoding(false), 1024, true))
			{
				using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
				{
					serializer.Serialize(jsonWriter, request);
					await jsonWriter.FlushAsync();
				}
			}

			content.Seek(0L, SeekOrigin.Begin);

			var streamContent = new StreamContent(content);
			streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			return streamContent;
		}

		private async Task<T?> Deserialize<T>(HttpResponseMessage httpResponse)
		{
			var jsonSerializerSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore,
			};

			using var streamReader = new StreamReader(await httpResponse.Content.ReadAsStreamAsync());
			var responseText = await streamReader.ReadToEndAsync();

			var obj = await Task.Run(() => JsonConvert.DeserializeObject<T>(responseText, jsonSerializerSettings));

			return obj;
		}
	}
}

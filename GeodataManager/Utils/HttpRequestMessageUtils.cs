using System.Net.Http.Headers;
using GeoDataManager.Extensions;

namespace GeoDataManager.Utils
{
	public static class HttpRequestMessageUtils
	{
		public static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri) => new(httpMethod, uri);

		public static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, string token)
		{
			var request = ConstructRequest(httpMethod, uri);
			request.Headers.Authorization = new AuthenticationHeaderValue("Token", token);

			return request;
		}
	}
}

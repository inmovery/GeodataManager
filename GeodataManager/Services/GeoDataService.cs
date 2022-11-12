using System.Net;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using GeoDataManager.Contracts;
using GeoDataManager.Dto;
using GeoDataManager.Extensions;
using GeoDataManager.Models;
using GeoDataManager.Models.Requests;
using GeoDataManager.Utils;
using Newtonsoft.Json;

namespace GeoDataManager.Services
{
	[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
	public class GeoDataService : IGeoDataService
	{
		private readonly IConfiguration _configuration;
		private readonly IHttpRequestService _httpRequestService;
		private readonly IMapper _mapper;
		private readonly ILogger<GeoDataService> _logger;

		public GeoDataService(IConfiguration configuration, IHttpRequestService httpRequestService, IMapper mapper, ILogger<GeoDataService> logger)
		{
			_configuration = configuration;
			_httpRequestService = httpRequestService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<ApiResponse> GetGeoDataByAddress(AddressDto address)
		{
			var openStreetMapApiAddressTemplate = _configuration["OpenStreetMap:ApiAddressTemplate"];
			var url = string.Format(openStreetMapApiAddressTemplate, address.Country, address.City, address.Street);

			using var httpRequestMessage = HttpRequestMessageUtils.ConstructRequest(HttpMethod.Get, url);
			var (data, httpStatusCode, errorDetails) = await _httpRequestService.GetAsync<IEnumerable<GeoDataDto>>(httpRequestMessage);

			var sentDataAsJson = JsonConvert.SerializeObject(address);
			var responseAsJson = JsonConvert.SerializeObject(data);

			_logger.LogInformation($"Request: {httpRequestMessage.RequestUri} Sent data: [{sentDataAsJson}] Result: {responseAsJson}, HttpStatusCode = {httpStatusCode}");

			return await HandleHttpStatusAsResponse<IEnumerable<GeoDataDto>>(httpStatusCode, data, errorDetails);
		}

		public async Task<ApiResponse> GetNearest10AddressesByGeoData(GeoDataDto geoData)
		{
			var url = _configuration["DaData:Url"];
			var daDataApiKey = _configuration["DaData:ApiKey"];

			var geoLocationRequest = new GeoLocationRequest(geoData.Latitude, geoData.Longitude);

			using var httpRequestMessage = HttpRequestMessageUtils.ConstructRequest(HttpMethod.Post, url, daDataApiKey);
			var (data, httpStatusCode, errorDetails) = await _httpRequestService.PostAsync<SuggestionsListObject>(httpRequestMessage, geoLocationRequest);

			var addresses = data?.Suggestions.Select(suggestion => suggestion.AddressDetails);
			var requestedSuggestionAddressInfo = addresses?.Select(address => _mapper.Map<AdvancedAddressDto>(address));

			var sentDataAsJson = JsonConvert.SerializeObject(geoLocationRequest);
			var responseAsJson = JsonConvert.SerializeObject(requestedSuggestionAddressInfo);

			_logger.LogInformation($"Request: {httpRequestMessage.RequestUri} Sent data: [{sentDataAsJson}] Result: {responseAsJson}, HttpStatusCode = {httpStatusCode}");

			return await HandleHttpStatusAsResponse(httpStatusCode, requestedSuggestionAddressInfo, errorDetails);
		}

		private Task<ApiResponse> HandleHttpStatusAsResponse<TData>(HttpStatusCode httpStatusCode, TData data, string errorDetails)
		{
			if (data == null)
				return Task.FromResult(ApiServiceExtensions.CreateNotFoundResponse(errorDetails));

			var dataAsEnumerable = data as IEnumerable<object> ?? Enumerable.Empty<object>();
			if (!dataAsEnumerable.Any())
				return Task.FromResult(ApiServiceExtensions.CreateNoContentResponse());

			var isSuccessStatusCode = ApiServiceExtensions.IsSuccessStatusCode(httpStatusCode);
			if (isSuccessStatusCode)
				return Task.FromResult(ApiServiceExtensions.CreateSuccessResponse(data));

			return Task.FromResult(httpStatusCode switch
			{
				HttpStatusCode.BadRequest => ApiServiceExtensions.CreateBadRequestResponse(errorDetails),
				HttpStatusCode.NoContent => ApiServiceExtensions.CreateNoContentResponse(),
				HttpStatusCode.Unauthorized => ApiServiceExtensions.CreateUnauthorizedResponse(),
				HttpStatusCode.NotFound => ApiServiceExtensions.CreateNotFoundResponse(errorDetails),
				_ => ApiServiceExtensions.CreateBadRequestResponse(errorDetails)
			});
		}
	}
}

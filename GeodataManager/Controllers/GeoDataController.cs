using System.Net;
using Microsoft.AspNetCore.Mvc;
using GeoDataManager.Contracts;
using GeoDataManager.Dto;

namespace GeoDataManager.Controllers
{
	[ApiController]
	[Route("api")]
	public class GeoDataController : BaseApiController
	{
		private readonly IGeoDataService _geoDataService;

		public GeoDataController(IGeoDataService geoDataService)
		{
			_geoDataService = geoDataService;
		}

		/// <summary>
		/// Get geo-data by address
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("geodata")]
		[ProducesResponseType(typeof(GeoDataDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetGeoDataByAddress([FromQuery]AddressDto address)
		{
			var result = await _geoDataService.GetGeoDataByAddress(address);

			return ConvertApiResponse(result);
		}

		/// <summary>
		/// Get nearest 10 advanced addresses by geo-data
		/// </summary>
		/// <param name="geoData"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("addresses")]
		[ProducesResponseType(typeof(IEnumerable<AdvancedAddressDto>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetNearest10AddressesByGeoData([FromQuery]GeoDataDto geoData)
		{
			var result = await _geoDataService.GetNearest10AddressesByGeoData(geoData);

			return ConvertApiResponse(result);
		}
	}
}

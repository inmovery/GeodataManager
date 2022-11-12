using GeoDataManager.Dto;
using GeoDataManager.Models;

namespace GeoDataManager.Contracts
{
	public interface IGeoDataService
	{
		Task<ApiResponse> GetGeoDataByAddress(AddressDto address);

		Task<ApiResponse> GetNearest10AddressesByGeoData(GeoDataDto geoData);
	}
}

using Newtonsoft.Json;

namespace GeoDataManager.Dto
{
	public class GeoDataDto
	{
		[JsonProperty("lat")]
		public double Latitude { get; set; }

		[JsonProperty("lon")]
		public double Longitude { get; set; }
	}
}

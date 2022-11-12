using GeoDataManager.Contracts;
using Newtonsoft.Json;

namespace GeoDataManager.Models.Requests
{
	public class GeoLocationRequest : IDataRequest
	{
		public GeoLocationRequest(double lat, double lon, int radius = 100, int count = 10)
		{
			Latitude = lat;
			Longitude = lon;
			Radius = radius;
			Count = count;
			Language = string.Empty;
		}

		[JsonProperty("lat")]
		public double Latitude { get; set; }

		[JsonProperty("lon")]
		public double Longitude { get; set; }

		[JsonProperty("radius")]
		public int Radius { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		public override string ToString()
		{
			return $"Latitude = {Latitude}, Longitude = {Longitude}";
		}
	}
}

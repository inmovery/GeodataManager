using Newtonsoft.Json;

namespace GeoDataManager.Models
{
	public class AddressSuggestion
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("unrestricted_value")]
		public string UnrestrictedValue { get; set; }

		[JsonProperty("data")]
		public Address AddressDetails { get; set; }
	}
}

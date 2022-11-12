using Newtonsoft.Json;

namespace GeoDataManager.Models
{
	public class SuggestionsListObject
	{
		[JsonProperty("suggestions")]
		public IEnumerable<AddressSuggestion> Suggestions { get; set; }
	}
}

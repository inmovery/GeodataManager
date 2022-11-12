using System.Net.Http.Headers;

namespace GeoDataManager.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<MediaTypeWithQualityHeaderValue> ToMediaTypeWithQualityHeaderValues(this IEnumerable<string> source)
		{
			return source.Select(mediaType => new MediaTypeWithQualityHeaderValue(mediaType));
		}
	}
}

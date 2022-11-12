namespace GeoDataManager.Extensions
{
	public static class CollectionExtensions
	{
		public static void AddTo<T>(this ICollection<T> destination, IEnumerable<T> source)
		{
			foreach (var item in source)
				destination.Add(item);
		}
	}
}

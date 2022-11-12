using AutoMapper;

namespace GeoDataManager.Extensions
{
	public static class AutoMapperExtensions
	{
		public static ICollection<TDestination> MapCollection<TSource, TDestination>(this IMapper mapper, ICollection<TSource>? source)
		{
			return mapper.Map<ICollection<TDestination>>(source);
		}
	}
}

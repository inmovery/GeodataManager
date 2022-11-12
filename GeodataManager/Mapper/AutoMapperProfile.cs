using AutoMapper;
using GeoDataManager.Dto;
using GeoDataManager.Models;

namespace GeoDataManager.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Address, AdvancedAddressDto>()
				.ForMember(
					dest => dest.Region,
					opt => opt.MapFrom(src => src.region))
				.ForMember(
					dest => dest.City,
					opt => opt.MapFrom(src => src.city_with_type))
				.ForMember(
					dest => dest.Street,
					opt => opt.MapFrom(src => src.street_with_type))
				.ForMember(
					dest => dest.HouseNumber,
					opt => opt.MapFrom(src => src.house))
				.ForMember(
					dest => dest.ApartmentNumber,
					opt => opt.MapFrom(src => int.Parse(src.flat)))
				.ReverseMap();
		}
	}
}

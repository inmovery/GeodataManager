namespace GeoDataManager.Dto
{
	public class AdvancedAddressDto
	{
		public string Region { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;

		public string Street { get; set; } = string.Empty;

		public string HouseNumber { get; set; } = string.Empty;

		public int ApartmentNumber { get; set; }
	}
}

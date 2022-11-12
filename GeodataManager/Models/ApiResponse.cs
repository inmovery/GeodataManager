namespace GeoDataManager.Models
{
	public class ApiResponse
	{
		public object? Data { get; set; }

		public string ErrorMessage { get; set; } = string.Empty;

		public int StatusCode { get; set; }
	}
}

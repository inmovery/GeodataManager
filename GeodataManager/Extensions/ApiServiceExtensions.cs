using System.Net;
using GeoDataManager.Models;

namespace GeoDataManager.Extensions
{
	public static class ApiServiceExtensions
	{
		public static ApiResponse CreateSuccessResponse(object? data) => new() { Data = data, StatusCode = 200 };

		public static ApiResponse CreateNoContentResponse() => new() { StatusCode = 204 };

		public static ApiResponse CreateNotFoundResponse(string error) => new() { StatusCode = 404, ErrorMessage = error };

		public static ApiResponse CreateBadRequestResponse(string error) => new() { StatusCode = 400, ErrorMessage = error };

		public static ApiResponse CreateUnauthorizedResponse() => new() { StatusCode = 401 };

		public static bool IsSuccessStatusCode(HttpStatusCode httpStatusCode) => (int)httpStatusCode >= 200 && (int)httpStatusCode <= 299;
	}
}

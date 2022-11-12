using GeoDataManager.Models.Requests;
using System.Net;

namespace GeoDataManager.Contracts
{
	public interface IHttpRequestService
	{
		/// <summary>
		/// Execute request by  
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="httpRequestMessage"></param>
		/// <returns></returns>
		Task<Tuple<T?, HttpStatusCode, string>> GetAsync<T>(HttpRequestMessage httpRequestMessage);

		/// <summary>
		/// Make request by using POST http method
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="httpRequestMessage"></param>
		/// <param name="dataRequest"></param>
		/// <returns></returns>
		Task<Tuple<T?, HttpStatusCode, string>> PostAsync<T>(HttpRequestMessage httpRequestMessage, IDataRequest dataRequest);
	}
}

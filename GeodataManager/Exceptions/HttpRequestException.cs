using System.Net;
using System.Runtime.Serialization;

namespace GeoDataManager.Exceptions
{
	[Serializable]
	public class HttpRequestException : Exception
	{
		public HttpRequestException()
		{
		}

		public HttpRequestException(string message)
			: base(message)
		{
		}

		public HttpRequestException(string message, WebException inner)
			: base(message, inner)
		{
			Status = inner.Status;
		}

		protected HttpRequestException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public WebExceptionStatus Status { get; }
	}
}

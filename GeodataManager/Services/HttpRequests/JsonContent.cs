﻿using System.Text;

namespace GeoDataManager.Services.HttpRequests
{
	public class JsonContent : StringContent
	{
		public JsonContent(string content)
			: this(content, Encoding.UTF8)
		{
		}

		public JsonContent(string content, Encoding encoding)
			: base(content, encoding, "application/json")
		{
		}
	}
}

using System.Collections.Generic;
using System.Collections.Specialized;

namespace FakeN.Web
{
	public static class FakeHttpSessionStateExtensions
	{
		public static FakeHttpSessionState Add(this FakeHttpSessionState session, IDictionary<string, object> data)
		{
			foreach (var item in data) session.Add(item.Key, item.Value);
			return session;
		}
		public static FakeHttpSessionState Add(this FakeHttpSessionState session, NameValueCollection data)
		{
			foreach (string key in data.Keys) session.Add(key, data[key]);
			return session;
		}
	}
}
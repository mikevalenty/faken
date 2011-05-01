using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpRequest : HttpRequestBase
	{
		private readonly NameValueCollection form;
		private readonly NameValueCollection queryString;
		private readonly NameValueCollection headers;
		private readonly HttpCookieCollection cookies;
		private readonly Uri url;
		private readonly string method;

		public FakeHttpRequest(Uri url = null, string method = "GET")
		{
			this.url = url ?? new Uri("http://localhost");
			this.method = method;
			queryString = ParseQueryString(this.url.Query);
			form = new NameValueCollection();
			headers = new NameValueCollection();
			cookies = new HttpCookieCollection();
		}

		public override Uri Url
		{
			get { return url; }
		}

		public override string HttpMethod
		{
			get { return method; }
		}

		public override void ValidateInput()
		{
		}

		public override string RawUrl
		{
			get { return url.PathAndQuery; }
		}

		public override string this[string key]
		{
			get { return new NameValueCollection { form, queryString }[key]; }
		}

		public override NameValueCollection Form
		{
			get { return form; }
		}

		public override NameValueCollection QueryString
		{
			get { return queryString; }
		}

		public override NameValueCollection Headers
		{
			get { return headers; }
		}

		public override HttpCookieCollection Cookies
		{
			get { return cookies; }
		}

		static NameValueCollection ParseQueryString(string url)
		{
			url = url.Replace("?", "");

			var parameters = new NameValueCollection();

			foreach (var parameter in url.Split('&').Where(p => p.Contains('=')).Select(p => p.Split('=')))
			{
				parameters.Add(parameter[0], parameter[1]);
			}

			return parameters;
		}
	}
}
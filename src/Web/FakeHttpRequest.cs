using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpRequest : HttpRequestBase
	{
		private readonly NameValueCollection form;
		private readonly NameValueCollection queryString;
		private readonly NameValueCollection headers;
		private readonly NameValueCollection serverVariables;
		private readonly HttpCookieCollection cookies;
		private HttpFileCollectionBase files;
		private Uri url;
		private string method;
		private bool isLocal;
		private string userHostAddress;
		private string applicationPath;
		private string[] acceptTypes;

		public FakeHttpRequest(Uri url = null, string method = "GET")
		{
			this.url = url ?? new Uri("http://localhost");
			this.method = method;
			acceptTypes = new string[] { };
			queryString = ParseQueryString(this.url.Query);
			form = new NameValueCollection();
			headers = new NameValueCollection();
			serverVariables = new NameValueCollection();
			cookies = new HttpCookieCollection();
		}

		public override Uri Url
		{
			get { return url; }
		}

		public FakeHttpRequest SetUrl(Uri url)
		{
			this.url = url;
			queryString.Clear();
			queryString.Add(ParseQueryString(url.Query));
			return this;
		}

		public override bool IsLocal
		{
			get { return isLocal; }
		}

		public FakeHttpRequest SetIsLocal(bool isLocal)
		{
			this.isLocal = isLocal;
			return this;
		}

		public override string ApplicationPath
		{
			get { return applicationPath; }
		}

		public FakeHttpRequest SetApplicationPath(string applicationPath)
		{
			this.applicationPath = applicationPath;
			return this;
		}

		public override string HttpMethod
		{
			get { return method; }
		}

		public FakeHttpRequest SetHttpMethod(string method)
		{
			this.method = method;
			return this;
		}

		public override string UserHostAddress
		{
			get { return userHostAddress; }
		}

		public FakeHttpRequest SetUserHostAddress(string userHostAddress)
		{
			this.userHostAddress = userHostAddress;
			return this;
		}

		public override string[] AcceptTypes
		{
			get { return acceptTypes; }
		}

		public FakeHttpRequest SetAcceptTypes(string[] acceptTypes)
		{
			this.acceptTypes = acceptTypes;
			return this;
		}

		public override string RequestType { get; set; }

		public override string ContentType { get; set; }

		public override Encoding ContentEncoding { get; set; }

		public override void ValidateInput() { }

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

		public override NameValueCollection ServerVariables
		{
			get { return serverVariables; }
		}

		public override HttpCookieCollection Cookies
		{
			get { return cookies; }
		}

		static NameValueCollection ParseQueryString(string url)
		{
			return HttpUtility.ParseQueryString(url);
		}

		public override HttpFileCollectionBase Files
		{
			get { return files; }
		}

		public void SetFiles(FakeHttpFileCollection files)
		{
			this.files = files;
		}
	}
}
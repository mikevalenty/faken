using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace FakeN.Web {

	public interface IHttpObject { }

	public class FakeHttpRequest : HttpRequestBase, IHttpObject {
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
		private Stream inputStream;
		private bool isAuthenticated;

		private string anonymousId;
		private string appRelativeCurrentExecutionFilePath;
		private HttpBrowserCapabilitiesBase browser;
		private ChannelBinding httpChannelBinding;
		private HttpClientCertificate clientCertificate;
		private int contentLength;
		private string currentExecutionFilePath;
		private Stream filter;
		private bool isSecureConnection;
		private WindowsIdentity logonUserIdentity;
		private NameValueCollection @params;
		private string physicalApplicationPath;
		private string physicalPath;
		private RequestContext requestContext;
		private int totalBytes;
		private Uri urlReferrer;
		private string userAgent;
		private string[] userLanguages;
		private string userHostName;
		private string pathInfo;

		private static NameValueCollection ParseQueryString(string url) {
			return HttpUtility.ParseQueryString(url);
		}

		public FakeHttpRequest(Uri url = null, string method = "GET") {
			this.url = url ?? new Uri("http://localhost");
			this.method = method;
			acceptTypes = new string[] { };
			queryString = ParseQueryString(this.url.Query);
			form = new NameValueCollection();
			headers = new NameValueCollection();
			serverVariables = new NameValueCollection();
			cookies = new HttpCookieCollection();
		}

		public FakeHttpRequest SetUrl(Uri url) {
			this.url = url;
			queryString.Clear();
			queryString.Add(ParseQueryString(url.Query));
			return this;
		}

		public override string this[string key] {
			get { return new NameValueCollection { form, queryString }[key]; }
		}

		public override bool IsAuthenticated { get { return isAuthenticated; } }
		public override Uri Url { get { return url; } }
		public override bool IsLocal { get { return isLocal; } }
		public override string ApplicationPath { get { return applicationPath; } }
		public override string HttpMethod { get { return method; } }
		public override string UserHostAddress { get { return userHostAddress; } }
		public override string[] AcceptTypes { get { return acceptTypes; } }
		public override string RequestType { get; set; }
		public override string ContentType { get; set; }
		public override Encoding ContentEncoding { get; set; }
		public override void ValidateInput() { }
		public override string RawUrl { get { return url.PathAndQuery; } }
		public override NameValueCollection Form { get { return form; } }
		public override NameValueCollection QueryString { get { return queryString; } }
		public override NameValueCollection Headers { get { return headers; } }
		public override NameValueCollection ServerVariables { get { return serverVariables; } }
		public override HttpCookieCollection Cookies { get { return cookies; } }
		public override HttpFileCollectionBase Files { get { return files; } }
		public override string Path { get { return Url.AbsolutePath; } }
		public override string FilePath { get { return Url.AbsolutePath; } }
		public override string PathInfo { get { return pathInfo; } }
		public override Stream InputStream { get { return inputStream; } }
		public override string AnonymousID { get { return anonymousId; } }
		public override string AppRelativeCurrentExecutionFilePath { get { return appRelativeCurrentExecutionFilePath; } }
		public override HttpBrowserCapabilitiesBase Browser { get { return browser; } }
		public override ChannelBinding HttpChannelBinding { get { return httpChannelBinding; } }
		public override HttpClientCertificate ClientCertificate { get { return clientCertificate; } }
		public override int ContentLength { get { return contentLength; } }
		public override string CurrentExecutionFilePath { get { return currentExecutionFilePath; } }
		public override Stream Filter { get { return filter; } set { filter = value; } }
		public override bool IsSecureConnection { get { return isSecureConnection; } }
		public override WindowsIdentity LogonUserIdentity { get { return logonUserIdentity; } }
		public override NameValueCollection Params { get { return @params; } }
		public override string PhysicalApplicationPath { get { return physicalApplicationPath; } }
		public override string PhysicalPath { get { return physicalPath; } }
		public override RequestContext RequestContext { get { return requestContext; } }
		public override int TotalBytes { get { return totalBytes; } }
		public override Uri UrlReferrer { get { return urlReferrer; } }
		public override string UserAgent { get { return userAgent; } }
		public override string[] UserLanguages { get { return userLanguages; } }
		public override string UserHostName { get { return userHostName; } }
	}
}
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpResponse : HttpResponseBase
	{
		private Func<string, string> appPathModifier;

		private bool buffer;

		private bool bufferOutput;

		private string cacheControl;

		private string charset;

		private Encoding contentEncoding;

		private string contentType;

		private HttpCookieCollection cookies;

		private int expires;

		private DateTime expiresAbsolute;

		private Stream filter;

		private NameValueCollection headers;

		private Encoding headerEncoding;

		private bool isClientConnected;

		private bool isRequestBeingRedirected;

		private TextWriter output;

		private Stream outputStream;

		private string redirectLocation;

		private string status;

		private bool suppressContent;

		private bool trySkipIisCustomErrors;

		public FakeHttpResponse()
		{
			appPathModifier = x => x;
		}

		public override HttpCachePolicyBase Cache
		{
			get { return new FakeHttpCachePolicy(); }
		}

		public override string ApplyAppPathModifier(string virtualPath)
		{
			return appPathModifier(virtualPath);
		}

		public FakeHttpResponse SetAppPathModifier(Func<string, string> appPathModifier)
		{
			this.appPathModifier = appPathModifier;
			return this;
		}

		public override int StatusCode { get; set; }
		public override string StatusDescription { get; set; }
		public override int SubStatusCode { get; set; }

		public override bool Buffer { get { return buffer; } set { buffer = value; } }
		public override bool BufferOutput { get { return bufferOutput; } set { bufferOutput = value; } }
		public override string CacheControl { get { return cacheControl; } set { cacheControl = value; } }
		public override string Charset { get { return charset; } set { charset = value; } }
		public override Encoding ContentEncoding { get { return contentEncoding; } set { contentEncoding = value; } }
		public override string ContentType { get { return contentType; } set { contentType = value; } }
		public override HttpCookieCollection Cookies { get { return cookies; } }
		public override int Expires { get { return expires; } set { expires = value; } }
		public override DateTime ExpiresAbsolute { get { return expiresAbsolute; } set { expiresAbsolute = value; } }
		public override Stream Filter { get { return filter; } set { filter = value; } }
		public override NameValueCollection Headers { get { return headers; } }
		public override Encoding HeaderEncoding { get { return headerEncoding; } set { headerEncoding = value; } }
		public override bool IsClientConnected { get { return isClientConnected; } }
		public override bool IsRequestBeingRedirected { get { return isRequestBeingRedirected; } }
		public override TextWriter Output { get { return output; } set { output = value; } }
		public override Stream OutputStream { get { return outputStream; } }
		public override string RedirectLocation { get { return redirectLocation; } set { redirectLocation = value; } }
		public override string Status { get { return status; } set { status = value; } }
		public override bool SuppressContent { get { return suppressContent; } set { suppressContent = value; } }
		public override bool TrySkipIisCustomErrors { get { return trySkipIisCustomErrors; } set { trySkipIisCustomErrors = value; } }
	}
}
using System;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpResponse : HttpResponseBase
	{
		private Func<string, string> appPathModifier;

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
	}
}
using System;
using System.Security.Principal;
using System.Web;

namespace FakeN.Web
{
	public static class FakeHttpContextExtensions
	{
		public static FakeHttpContext Set(this FakeHttpContext context, IIdentity identity, string[] roles)
		{
			context.User = new GenericPrincipal(identity, roles);
			return context;
		}

		public static FakeHttpContext Set(this FakeHttpContext context, IIdentity identity)
		{
			return context.Set(identity, new string[] { });
		}

		public static FakeHttpContext Authenticate(this FakeHttpContext context)
		{
			var request = context.Request as FakeHttpRequest;
			if (request != null) {
				request.SetAuthenticated(true);
			}

			return context.Set(new MutableIdentity { IsAuthenticated = true });
		}

		public static FakeHttpContext ToHttpContext(this HttpRequestBase request)
		{
			return new FakeHttpContext(request);
		}

		public static FakeHttpContext ToHttpContext(this Uri uri)
		{
			return new FakeHttpRequest(uri).ToHttpContext();
		}
	}
}
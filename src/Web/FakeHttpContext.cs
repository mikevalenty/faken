using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpContext : HttpContextBase
	{
		private readonly HttpRequestBase request;
		private readonly HttpResponseBase response;
		private readonly HttpSessionStateBase session;
		private readonly IDictionary items;

		public FakeHttpContext(
			HttpRequestBase request = null,
			HttpResponseBase response = null,
			HttpSessionStateBase session = null)
		{
			this.request = request ?? new FakeHttpRequest();
			this.response = response ?? new FakeHttpResponse();
			this.session = session ?? new FakeHttpSessionState();
			items = new Dictionary<object, object>();
			User = new GenericPrincipal(new MutableIdentity(), new string[] { });
		}

		public override HttpRequestBase Request
		{
			get { return request; }
		}

		public override HttpResponseBase Response
		{
			get { return response; }
		}

		public override HttpSessionStateBase Session
		{
			get { return session; }
		}

		public override IDictionary Items
		{
			get { return items; }
		}

		public override IPrincipal User { get; set; }
	}
}
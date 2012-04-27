using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;

namespace FakeN.Web
{
	public class FakeHttpContext : HttpContextBase
	{
		private readonly HttpRequestBase request;
		private readonly HttpResponseBase response;
		private readonly HttpSessionStateBase session;
		private readonly IDictionary items;

		private TraceContext trace;
		private DateTime timestamp;
		private bool skipAuthorization;
		private HttpServerUtilityBase server;
		private ProfileBase profile;
		private IHttpHandler previousHandler;
		private bool isPostNotification;
		private bool isDebuggingEnabled;
		private bool isCustomErrorEnabled;
		private IHttpHandler handler;
		private Exception error;
		private RequestNotification currentNotification;
		private IHttpHandler currentHandler;
		private Cache cache;
		private HttpApplication applicationInstance;
		private HttpApplicationStateBase application;
		private Exception[] allErrors;

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

		public override TraceContext Trace { get { return trace; } }
		public override DateTime Timestamp { get { return timestamp; } }
		public override bool SkipAuthorization { get { return skipAuthorization; } set { skipAuthorization = value; } }
		public override HttpServerUtilityBase Server { get { return server; } }
		public override ProfileBase Profile { get { return profile; } }
		public override IHttpHandler PreviousHandler { get { return previousHandler; } }
		public override bool IsPostNotification { get { return isPostNotification; } }
		public override bool IsDebuggingEnabled { get { return isDebuggingEnabled; } }
		public override bool IsCustomErrorEnabled { get { return isCustomErrorEnabled; } }
		public override IHttpHandler Handler { get { return handler; } set { handler = value; } }
		public override Exception Error { get { return error; } }
		public override RequestNotification CurrentNotification { get { return currentNotification; } }
		public override IHttpHandler CurrentHandler { get { return currentHandler; } }
		public override Cache Cache { get { return cache; } }
		public override HttpApplication ApplicationInstance { get { return applicationInstance; } set { applicationInstance = value; } }
		public override HttpApplicationStateBase Application { get { return application; } }
		public override Exception[] AllErrors { get { return allErrors; } }
	}
}
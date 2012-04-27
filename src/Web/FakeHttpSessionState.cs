using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;

namespace FakeN.Web
{
	public class FakeHttpSessionState : HttpSessionStateBase
	{
		private readonly SessionStateCollection data;
		private int codePage;
		private HttpSessionStateBase contents;
		private HttpCookieMode cookieMode;
		private bool isCookieless;
		private bool isNewSession;
		private bool isReadOnly;
		private int lcid;
		private SessionStateMode mode;
		private string sessionId;
		private HttpStaticObjectsCollectionBase staticObjects;
		private int timeout;
		private int count;
		private bool isSynchronized;
		private object syncRoot;

		public FakeHttpSessionState()
		{
			data = new SessionStateCollection();
		}

		public override object this[string name]
		{
			get { return data[name]; }
			set { data[name] = value; }
		}

		public override void Add(string name, object value)
		{
			data[name] = value;
		}

		public override NameObjectCollectionBase.KeysCollection Keys
		{
			get { return data.Keys; }
		}

		private class SessionStateCollection : NameObjectCollectionBase
		{
			public object this[string key]
			{
				get { return BaseGet(key); }
				set { BaseSet(key, value); }
			}
		}

		public override int CodePage { get { return codePage; } set { codePage = value; } }
		public override HttpSessionStateBase Contents { get { return contents; } }
		public override HttpCookieMode CookieMode { get { return cookieMode; } }
		public override bool IsCookieless { get { return isCookieless; } }
		public override bool IsNewSession { get { return isNewSession; } }
		public override bool IsReadOnly { get { return isReadOnly; } }
		public override int LCID { get { return lcid; } set { lcid = value; } }
		public override SessionStateMode Mode { get { return mode; } }
		public override string SessionID { get { return sessionId; } }
		public override HttpStaticObjectsCollectionBase StaticObjects { get { return staticObjects; } }
		public override int Timeout { get { return timeout; } set { timeout = value; } }
		public override int Count { get { return count; } }
		public override bool IsSynchronized { get { return isSynchronized; } }
		public override object SyncRoot { get { return syncRoot; } }
	}
}
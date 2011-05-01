using System.Collections.Specialized;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpSessionState : HttpSessionStateBase
	{
		private readonly SessionStateCollection data;

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
	}
}
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpResponse : HttpResponseBase
	{
		public override HttpCachePolicyBase Cache
		{
			get { return new FakeHttpCachePolicy(); }
		}
	}
}
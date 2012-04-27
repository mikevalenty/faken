using System.Web;

namespace FakeN.Web
{
	public class FakeHttpCachePolicy : HttpCachePolicyBase
	{
		private HttpCacheVaryByParams varyByParams;
		private HttpCacheVaryByHeaders varyByHeaders;
		private HttpCacheVaryByContentEncodings varyByContentEncodings;

		public override void SetExpires(System.DateTime date)
		{
		}

		public override void SetValidUntilExpires(bool validUntilExpires)
		{
		}

		public override void SetRevalidation(HttpCacheRevalidation revalidation)
		{
		}

		public override void SetCacheability(HttpCacheability cacheability)
		{
		}

		public override void SetNoStore()
		{
		}

		public override HttpCacheVaryByParams VaryByParams { get { return varyByParams; } }
		public override HttpCacheVaryByHeaders VaryByHeaders { get { return varyByHeaders; } }
		public override HttpCacheVaryByContentEncodings VaryByContentEncodings { get { return varyByContentEncodings; } }
	}
}
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpCachePolicy : HttpCachePolicyBase
	{
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
	}
}
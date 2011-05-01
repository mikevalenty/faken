using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class RequestTests
	{
		[Test]
		public void Request_should_not_be_null()
		{
			Assert.That(new FakeHttpContext().Request, Is.Not.Null);
		}

		[Test]
		public void Can_specify_request()
		{
			var request = new FakeHttpRequest();

			var context = new FakeHttpContext(request);

			Assert.That(context.Request, Is.SameAs(request));
		}
	}
}
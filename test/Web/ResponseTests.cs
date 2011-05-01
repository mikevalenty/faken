using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class ResponseTests
	{
		[Test]
		public void Response_should_not_be_null()
		{
			Assert.That(new FakeHttpContext().Response, Is.Not.Null);
		}
	}
}
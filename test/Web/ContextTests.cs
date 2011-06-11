using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class ContextTests
	{
		private FakeHttpContext context;

		[SetUp]
		public void SetUp()
		{
			context = new FakeHttpContext();
		}

		[Test]
		public void Can_store_objects_in_Items()
		{
			context.Items.Add("color", "blue");

			Assert.That(context.Items["color"], Is.EqualTo("blue"));
		}
	}
}
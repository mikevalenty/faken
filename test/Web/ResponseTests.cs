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

		[Test]
		public void App_path_modifier_returns_virtual_path()
		{
			var response = new FakeHttpResponse();

			var path = response.ApplyAppPathModifier("the/path");

			Assert.That(path, Is.EqualTo("the/path"));
		}

		[Test]
		public void App_path_modifier_can_alter_virtual_path()
		{
			var response = new FakeHttpResponse();
			response.SetAppPathModifier(x => x + "/12345");

			var path = response.ApplyAppPathModifier("the/path");

			Assert.That(path, Is.EqualTo("the/path/12345"));
		}
	}
}
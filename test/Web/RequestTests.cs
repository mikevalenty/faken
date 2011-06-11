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

		[Test]
		public void Request_should_not_be_local()
		{
			Assert.That(new FakeHttpRequest().IsLocal, Is.False);
		}

		[Test]
		public void Request_can_be_specified_to_be_local()
		{
			Assert.That(new FakeHttpRequest(isLocal: true).IsLocal, Is.True);
		}

		[Test]
		public void Can_add_and_read_from_server_variables()
		{
			var request = new FakeHttpRequest();

			request.ServerVariables.Add("REMOTE_ADDR", "127.0.0.1");

			Assert.That(request.ServerVariables["REMOTE_ADDR"], Is.EqualTo("127.0.0.1"));
		}
	}
}
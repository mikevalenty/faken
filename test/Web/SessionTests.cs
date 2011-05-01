using System;
using System.Linq;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class SessionTests
	{
		[Test]
		public void Session_should_not_be_null()
		{
			Assert.That(new FakeHttpContext().Session, Is.Not.Null);
		}

		[Test]
		public void Can_initialize_context_with_existing_session()
		{
			var session = new FakeHttpSessionState();

			var context = new FakeHttpContext(session: session);

			Assert.That(context.Session, Is.SameAs(session));
		}

		[Test]
		public void Should_add_values_to_session()
		{
			var session = new FakeHttpSessionState { { "color", "red" } };

			Assert.That(session["color"], Is.EqualTo("red"));
		}

		[Test]
		public void Can_set_values_with_default_indexer()
		{
			var session = new FakeHttpSessionState();
			session["name"] = "slim";

			Assert.That(session["name"], Is.EqualTo("slim"));
		}
	}
}
using System.Security.Principal;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	public class UserTests
	{
		[Test]
		public void User_should_not_be_null()
		{
			Assert.That(new FakeHttpContext().User, Is.Not.Null);
		}

		[Test]
		public void User_should_not_be_authenticated()
		{
			var principal = new FakeHttpContext().User;

			Assert.That(principal.Identity.IsAuthenticated, Is.False);
		}

		[Test]
		public void User_can_be_authenticated_with_convenience_method()
		{
			var context = new FakeHttpContext().Authenticate();

			Assert.That(context.User.Identity.IsAuthenticated, Is.True);
			Assert.That(context.Request.IsAuthenticated, Is.True);
		}

		[Test]
		public void Principal_can_be_set()
		{
			var context = new FakeHttpContext
			{
				User = new GenericPrincipal(new MutableIdentity { Name = "slim" }, new string[] { })
			};

			Assert.That(context.User.Identity.Name, Is.EqualTo("slim"));
		}

		[Test]
		public void Identity_can_be_set_with_convenience_method()
		{
			var context = new FakeHttpContext().Set(new MutableIdentity { Name = "slim" });

			Assert.That(context.User.Identity.Name, Is.EqualTo("slim"));
		}
	}
}
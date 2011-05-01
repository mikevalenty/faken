using System;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class UrlTests
	{
		[Test]
		public void Url_should_not_be_null()
		{
			Assert.That(new FakeHttpRequest().Url, Is.Not.Null);
		}

		[Test]
		public void Url_can_be_set()
		{
			var request = new FakeHttpRequest(new Uri("http://google.com/"));

			Assert.That(request.Url.AbsoluteUri, Is.EqualTo("http://google.com/"));
		}

		[Test]
		public void Url_query_string_should_add_to_query_string_collection()
		{
			var url = new Uri("http://google.com?q=awesome&p=1");

			var request = new FakeHttpRequest(url);

			Assert.That(request.QueryString["q"], Is.EqualTo("awesome"));
			Assert.That(request.QueryString["p"], Is.EqualTo("1"));
		}

		[Test]
		public void Should_have_convenience_method_to_create_http_context()
		{
			var url = new Uri("http://google.com?q=awesome");

			var context = url.ToHttpContext();

			Assert.That(context.Request.QueryString["q"], Is.EqualTo("awesome"));
		}
	}
}
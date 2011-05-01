using System;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class QueryStringTests
	{
		[Test]
		public void Should_add_to_query_string()
		{
			var request = new FakeHttpRequest();

			request.QueryString.Add("id", "3");

			Assert.That(request.QueryString["id"], Is.EqualTo("3"));
		}

		[Test]
		public void Can_access_query_string_values_by_default_indexer()
		{
			var request = new FakeHttpRequest();

			request.QueryString.Add("id", "3");

			Assert.That(request["id"], Is.EqualTo("3"));
		}
	}
}
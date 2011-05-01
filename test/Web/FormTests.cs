using System;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class FormTests
	{
		[Test]
		public void Can_add_to_form_collection()
		{
			var request = new FakeHttpRequest();

			request.Form.Add("color", "blue");

			Assert.That(request.Form["color"], Is.EqualTo("blue"));
		}

		[Test]
		public void Can_access_form_values_by_default_indexer()
		{
			var request = new FakeHttpRequest();

			request.Form.Add("color", "blue");

			Assert.That(request["color"], Is.EqualTo("blue"));
		}
	}
}
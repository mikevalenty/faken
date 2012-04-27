using System;
using System.IO;
using System.Text;
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
			Assert.That(new FakeHttpRequest().Set(req => req.IsLocal, true).IsLocal, Is.True);
		}

		[Test]
		public void Can_add_and_read_from_server_variables()
		{
			var request = new FakeHttpRequest();

			request.ServerVariables.Add("REMOTE_ADDR", "127.0.0.1");

			Assert.That(request.ServerVariables["REMOTE_ADDR"], Is.EqualTo("127.0.0.1"));
		}

		[Test]
		public void Should_be_implemented()
		{
			var request = new FakeHttpRequest();

			Assert.That(request.ApplicationPath, Is.Null);
			Assert.That(request.AcceptTypes, Is.EquivalentTo(new string[] { }));
		}

		[Test]
		public void Can_add_and_read_from_files()
		{
			var request = new FakeHttpRequest();
			var files = new FakeHttpFileCollection();

			var bytes = Encoding.UTF8.GetBytes("These are file contents");
			var fileContents = new MemoryStream();
			fileContents.Write(bytes, 0, bytes.Length);
			fileContents.Flush();
			fileContents.Position = 0;

			var file = new FakeHttpPostedFile("SomeFile.txt", "text/plain", fileContents);
			files.Add("FileFormFieldValue", file);
			request.Set(req => req.Files, files);

			Assert.That(request.Files.Count, Is.EqualTo(1));
			Assert.That(request.Files[0].FileName, Is.EqualTo("SomeFile.txt"));
			Assert.That(request.Files[0].ContentType, Is.EqualTo("text/plain"));
			Assert.That(request.Files[0].ContentLength, Is.EqualTo(fileContents.Length));
		}

		[Test]
		public void Can_set_and_RetrieveInputStream()
		{
			var request = new FakeHttpRequest();
			var requestBodyText = "This is the raw request body.";
			var bytes = Encoding.UTF8.GetBytes(requestBodyText);
			var stream = new MemoryStream(bytes, false);
			request.Set(req => req.InputStream, stream);

			var gotStream = request.InputStream;
			var rdr = new StreamReader(gotStream, Encoding.UTF8);
			Assert.That(rdr.ReadToEnd(), Is.EqualTo(requestBodyText));
		}

		[Test]
		public void Can_set_authenticated_status() 
		{
			var request = new FakeHttpRequest();

			Assert.That(request, Has.Property("IsAuthenticated").False);
			request.Set(req => req.IsAuthenticated, true);
			Assert.That(request, Has.Property("IsAuthenticated").True);
		}

		[Test]
		public void Should_set_value() {
			var request = new FakeHttpRequest();
			var uri = new Uri("http://localhost/");
			request.Set(req => req.UrlReferrer, uri);
			Assert.That(request, Has.Property("UrlReferrer").EqualTo(uri));
		}
	}
}
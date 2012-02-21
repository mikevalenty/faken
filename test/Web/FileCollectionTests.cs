using System;
using System.Globalization;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace FakeN.Web.Test
{
	[TestFixture]
	public class FileCollectionTests
	{
		[Test]
		public void Field_names_are_not_case_sensitive()
		{
			var testSubject = new FakeHttpFileCollection();

			const string formFieldNameInMixedCase = "FileFormFieldValue";

			for (int i = 0; i < 4; i++)
			{
				// simulate an uploaded file
				var bytes = Encoding.UTF8.GetBytes("These are file contents");
				var fileContents = new MemoryStream(bytes, false);

				var file = new FakeHttpPostedFile("SomeFile" + i + ".txt", "text/plain", fileContents);

				var fieldNameToAdd = formFieldNameInMixedCase + i;
				testSubject.Add(fieldNameToAdd, file);
			}

			Assert.That(testSubject.Count, Is.EqualTo(4));
			for (int i = 0; i < 4; i++)
			{
				// retrieve each one using different variations of case and make sure we get the right one
				var fieldNameToRetrieve = formFieldNameInMixedCase + i;
				var foundFile = testSubject[fieldNameToRetrieve.ToUpperInvariant()];
				Assert.That(foundFile, Is.Not.Null);
				Assert.That(foundFile.FileName, Is.EqualTo("SomeFile" + i + ".txt"));
				
				foundFile = testSubject[fieldNameToRetrieve.ToLowerInvariant()];
				Assert.That(foundFile, Is.Not.Null);
				Assert.That(foundFile.FileName, Is.EqualTo("SomeFile" + i + ".txt"));

				TextInfo text = CultureInfo.CurrentCulture.TextInfo;
				var formFieldNameInTitleCase = text.ToTitleCase(fieldNameToRetrieve);
				foundFile = testSubject[formFieldNameInTitleCase];
				Assert.That(foundFile, Is.Not.Null);
				Assert.That(foundFile.FileName, Is.EqualTo("SomeFile" + i + ".txt"));
			}

		}

		//TODO: need to match the behavior when two or more uploaded files have the same form field name (and those form field names either match exactly, or match ignoring case)
		// but I don't yet know what that behavior is.
		/*
			bytes = Encoding.UTF8.GetBytes("These are other file contents.");
			fileContents = new MemoryStream(bytes, false);

			var file2 = new FakeHttpPostedFile("SomeOtherFile.txt", "text/plain", fileContents);
			// when we add the same field name with different case, it should merge into the existing one
			files.Add(formFieldNameInMixedCase.ToLowerInvariant(), file2);

		 */
	}
}
using System;
using System.IO;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpPostedFile : HttpPostedFileBase
	{
		private readonly string fileName;
		private readonly string contentType;
		private readonly Stream stream;
		private Action<string> saveAsCallback;

		public FakeHttpPostedFile(string fileName, string contentType, Stream stream)
		{
			this.fileName = fileName;
			this.contentType = contentType;
			this.stream = stream;
		}

		public override int ContentLength
		{
			get { return (int)stream.Length; }
		}

		public override string ContentType
		{
			get { return contentType; }
		}

		public override string FileName
		{
			get { return fileName; }
		}

		public override Stream InputStream
		{
			get { return stream; }
		}

		public override void SaveAs(string filename)
		{
			SavedFileName = filename;

			if (saveAsCallback != null)
			{
				saveAsCallback.Invoke(filename);
			}
		}

		/// <summary>
		/// Use this to set a callback function that will be invoked when the SaveAs method is called
		/// </summary>
		/// <param name="callback">The function to handle the SaveAs method call</param>
		public void OnSaveAs(Action<string> callback)
		{
			saveAsCallback = callback;
		}

		/// <summary>
		/// Read from this property to determine the last value passed to the filename parameter of the SaveAs method
		/// </summary>
		public string SavedFileName { get; private set; }
	}
}
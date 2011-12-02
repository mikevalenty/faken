using System.IO;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpPostedFile : HttpPostedFileBase
	{
		private readonly string mFileName;
		private readonly string mContentType;
		private readonly Stream mStream;

		public FakeHttpPostedFile(string fileName, string contentType, Stream stream)
		{
			mFileName = fileName;
			mContentType = contentType;
			mStream = stream;
		}

		public override int ContentLength
		{
			get { return (int)mStream.Length; }
		}

		public override string ContentType
		{
			get { return mContentType; }
		}

		public override string FileName
		{
			get { return mFileName; }
		}

		public override Stream InputStream
		{
			get { return mStream; }
		}

		public override void SaveAs(string filename)
		{
			using (var fs = new FileStream(mFileName, FileMode.Create))
			{
				mStream.CopyTo(fs);
				fs.Flush();
				fs.Close();
			}
		}
	}
}
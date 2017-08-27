//
// Metafile class unit tests
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Xunit;

namespace MonoTests.System.Drawing.Imaging {

	[TestFixture]
	public class MetafileTest {

		public const string Bitmap = "bitmaps/non-inverted.bmp";
		public const string WmfPlaceable = "bitmaps/telescope_01.wmf";
		public const string Emf = "bitmaps/milkmateya01.emf";

		// Get the input directory depending on the runtime
		static public string getInFile (string file)
		{
			string sRslt = Path.GetFullPath ("../System.Drawing/" + file);

			if (!File.Exists (sRslt))
				sRslt = "Test/System.Drawing/" + file;

			return sRslt;
		}

		[Fact]
		public void Metafile_Stream_Null ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile ((Stream)null));
		}

		[Fact]
		public void Metafile_String_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Metafile ((string) null));
		}

		[Fact]
		public void Metafile_String_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile (String.Empty));
		}

		[Fact]
		public void Metafile_String_FileDoesNotExists ()
		{
			string filename = getInFile ("telescope_02.wmf");
			Assert.Throws<ExternalException> (() => new Metafile (filename));
		}

		[Fact]
		public void Metafile_String ()
		{
			string filename = getInFile (WmfPlaceable);
			Metafile mf = new Metafile (filename);
			Metafile clone = (Metafile) mf.Clone ();
		}

		[Fact]
		public void GetMetafileHeader_Bitmap ()
		{
			Assert.Throws<ExternalException> (() => new Metafile (getInFile (Bitmap)));
		}

		static public void Check_MetaHeader_WmfPlaceable (MetaHeader mh)
		{
			Assert.Equal (9, mh.HeaderSize, "HeaderSize");
			Assert.Equal (98, mh.MaxRecord, "MaxRecord");
			Assert.Equal (3, mh.NoObjects, "NoObjects");
			Assert.Equal (0, mh.NoParameters, "NoParameters");
			Assert.Equal (1737, mh.Size, "Size");
			Assert.Equal (1, mh.Type, "Type");
			Assert.Equal (0x300, mh.Version, "Version");
		}

		public static void Check_MetafileHeader_WmfPlaceable (MetafileHeader header)
		{
			Assert.Equal (MetafileType.WmfPlaceable, header.Type, "Type");
			Assert.Equal (0x300, header.Version, "Version");
			// filesize - 22, which happens to be the size (22) of a PLACEABLEMETAHEADER struct
			Assert.Equal (3474, header.MetafileSize, "MetafileSize");

			Assert.Equal (-30, header.Bounds.X, "Bounds.X");
			Assert.Equal (-40, header.Bounds.Y, "Bounds.Y");
			Assert.Equal (3096, header.Bounds.Width, "Bounds.Width");
			Assert.Equal (4127, header.Bounds.Height, "Bounds.Height");
			Assert.Equal (606, header.DpiX, "DpiX");
			Assert.Equal (606, header.DpiY, "DpiY");
			Assert.Equal (0, header.EmfPlusHeaderSize, "EmfPlusHeaderSize");
			Assert.Equal (0, header.LogicalDpiX, "LogicalDpiX");
			Assert.Equal (0, header.LogicalDpiY, "LogicalDpiY");

			Assert.NotNull (header.WmfHeader, "WmfHeader");
			Check_MetaHeader_WmfPlaceable (header.WmfHeader);

			Assert.False (header.IsDisplay (), "IsDisplay");
			Assert.False (header.IsEmf (), "IsEmf");
			Assert.False (header.IsEmfOrEmfPlus (), "IsEmfOrEmfPlus");
			Assert.False (header.IsEmfPlus (), "IsEmfPlus");
			Assert.False (header.IsEmfPlusDual (), "IsEmfPlusDual");
			Assert.False (header.IsEmfPlusOnly (), "IsEmfPlusOnly");
			Assert.True (header.IsWmf (), "IsWmf");
			Assert.True (header.IsWmfPlaceable (), "IsWmfPlaceable");
		}

		[Fact]
		public void GetMetafileHeader_WmfPlaceable ()
		{
			using (Metafile mf = new Metafile (getInFile (WmfPlaceable))) {
				MetafileHeader header1 = mf.GetMetafileHeader ();
				Check_MetafileHeader_WmfPlaceable (header1);

				MetafileHeader header2 = mf.GetMetafileHeader ();
				Assert.False (Object.ReferenceEquals (header1, header2), "Same object");
			}
		}

		[Fact]
		public void GetMetafileHeader_FromFile_WmfPlaceable ()
		{
			using (Metafile mf = new Metafile (getInFile (WmfPlaceable))) {
				MetafileHeader header1 = mf.GetMetafileHeader ();
				Check_MetafileHeader_WmfPlaceable (header1);

				MetaHeader mh1 = header1.WmfHeader;
				Check_MetaHeader_WmfPlaceable (mh1);

				MetaHeader mh2 = mf.GetMetafileHeader ().WmfHeader;
				Assert.False (Object.ReferenceEquals (mh1, mh2), "Same object");
			}
		}

		[Fact]
		public void GetMetafileHeader_FromFileStream_WmfPlaceable ()
		{
			using (FileStream fs = File.OpenRead (getInFile (WmfPlaceable))) {
				using (Metafile mf = new Metafile (fs)) {
					MetafileHeader header1 = mf.GetMetafileHeader ();
					Check_MetafileHeader_WmfPlaceable (header1);

					MetaHeader mh1 = header1.WmfHeader;
					Check_MetaHeader_WmfPlaceable (mh1);

					MetaHeader mh2 = mf.GetMetafileHeader ().WmfHeader;
					Assert.False (Object.ReferenceEquals (mh1, mh2), "Same object");
				}
			}
		}

		[Fact]
		public void GetMetafileHeader_FromMemoryStream_WmfPlaceable ()
		{
			MemoryStream ms;
			string filename = getInFile (WmfPlaceable);
			using (FileStream fs = File.OpenRead (filename)) {
				byte[] data = new byte[fs.Length];
				fs.Read (data, 0, data.Length);
				ms = new MemoryStream (data);
			}
			using (Metafile mf = new Metafile (ms)) {
				MetafileHeader header1 = mf.GetMetafileHeader ();
				Check_MetafileHeader_WmfPlaceable (header1);

				MetaHeader mh1 = header1.WmfHeader;
				Check_MetaHeader_WmfPlaceable (mh1);

				MetaHeader mh2 = mf.GetMetafileHeader ().WmfHeader;
				Assert.False (Object.ReferenceEquals (mh1, mh2), "Same object");
			}
			ms.Close ();
		}

		public static void Check_MetafileHeader_Emf (MetafileHeader header)
		{
			Assert.Equal (MetafileType.Emf, header.Type, "Type");
			Assert.Equal (65536, header.Version, "Version");
			// extactly the filesize
			Assert.Equal (20456, header.MetafileSize, "MetafileSize");

			Assert.Equal (0, header.Bounds.X, "Bounds.X");
			Assert.Equal (0, header.Bounds.Y, "Bounds.Y");
#if false
			Assert.Equal (759, header.Bounds.Width, "Bounds.Width");
			Assert.Equal (1073, header.Bounds.Height, "Bounds.Height");
			Assert.Equal (96f, header.DpiX, 0.5f, "DpiX");
			Assert.Equal (96f, header.DpiY, 0.5f, "DpiY");
			Assert.Equal (6619188, header.EmfPlusHeaderSize, "EmfPlusHeaderSize");
			Assert.Equal (3670064, header.LogicalDpiX, "LogicalDpiX");
			Assert.Equal (3670064, header.LogicalDpiY, "LogicalDpiY");
#endif
			try {
				Assert.NotNull (header.WmfHeader, "WmfHeader");
				Assert.Fail ("WmfHeader didn't throw an ArgumentException");
			}
			catch (ArgumentException) {
			}
			catch (Exception e) {
				Assert.Fail ("WmfHeader didn't throw an ArgumentException but: {0}.", e.ToString ());
			}

			Assert.False (header.IsDisplay (), "IsDisplay");
			Assert.True (header.IsEmf (), "IsEmf");
			Assert.True (header.IsEmfOrEmfPlus (), "IsEmfOrEmfPlus");
			Assert.False (header.IsEmfPlus (), "IsEmfPlus");
			Assert.False (header.IsEmfPlusDual (), "IsEmfPlusDual");
			Assert.False (header.IsEmfPlusOnly (), "IsEmfPlusOnly");
			Assert.False (header.IsWmf (), "IsWmf");
			Assert.False (header.IsWmfPlaceable (), "IsWmfPlaceable");
		}

		[Fact]
		public void GetMetafileHeader_FromFile_Emf ()
		{
			using (Metafile mf = new Metafile (getInFile (Emf))) {
				MetafileHeader header1 = mf.GetMetafileHeader ();
				Check_MetafileHeader_Emf (header1);
			}
		}

		[Fact]
		public void GetMetafileHeader_FromFileStream_Emf ()
		{
			using (FileStream fs = File.OpenRead (getInFile (Emf))) {
				using (Metafile mf = new Metafile (fs)) {
					MetafileHeader header1 = mf.GetMetafileHeader ();
					Check_MetafileHeader_Emf (header1);
				}
			}
		}

		[Fact]
		public void GetMetafileHeader_FromMemoryStream_Emf ()
		{
			MemoryStream ms;
			string filename = getInFile (Emf);
			using (FileStream fs = File.OpenRead (filename)) {
				byte[] data = new byte[fs.Length];
				fs.Read (data, 0, data.Length);
				ms = new MemoryStream (data);
			}
			using (Metafile mf = new Metafile (ms)) {
				MetafileHeader header1 = mf.GetMetafileHeader ();
				Check_MetafileHeader_Emf (header1);
			}
			ms.Close ();
		}

		[Fact]
		public void Static_GetMetafileHeader_Stream_Null ()
		{
			Assert.Throws<NullReferenceException> (() => Metafile.GetMetafileHeader ((Stream)null));
		}

		[Fact]
		public void Static_GetMetafileHeader_Stream ()
		{
			string filename = getInFile (WmfPlaceable);
			using (FileStream fs = File.OpenRead (filename)) {
				MetafileHeader header = Metafile.GetMetafileHeader (fs);
				Check_MetafileHeader_WmfPlaceable (header);
			}
		}

		[Fact]
		public void Static_GetMetafileHeader_Filename_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => Metafile.GetMetafileHeader ((string) null));
		}

		[Fact]
		public void Static_GetMetafileHeader_Filename ()
		{
			string filename = getInFile (WmfPlaceable);
			MetafileHeader header = Metafile.GetMetafileHeader (filename);
			Check_MetafileHeader_WmfPlaceable (header);
		}
	}

	[TestFixture]
	public class MetafileFulltrustTest {

		private Font test_font;

		[TestFixtureSetUp]
		public void FixtureSetUp ()
		{
			try {
				test_font = new Font (FontFamily.GenericMonospace, 12);
			}
			catch (ArgumentException) {
			}
		}

		[Fact]
		public void Static_GetMetafileHeader_IntPtr_Zero ()
		{
			Assert.Throws<ArgumentException> (() => Metafile.GetMetafileHeader (IntPtr.Zero));
		}

		[Fact]
		public void Static_GetMetafileHeader_IntPtr ()
		{
			string filename = MetafileTest.getInFile (MetafileTest.WmfPlaceable);
			using (Metafile mf = new Metafile (filename)) {

				IntPtr hemf = mf.GetHenhmetafile ();
				Assert.True (hemf != IntPtr.Zero, "GetHenhmetafile");

				Assert.Throws<ArgumentException> (() => Metafile.GetMetafileHeader (hemf));
			}
		}

		[Fact]
		public void Metafile_IntPtrBool_Zero ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile (IntPtr.Zero, false));
		}

		[Fact]
		public void Metafile_IntPtrEmfType_Zero ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile (IntPtr.Zero, EmfType.EmfOnly));
		}

		private void CheckEmptyHeader (Metafile mf, EmfType type)
		{
			MetafileHeader mh = mf.GetMetafileHeader ();
			Assert.Equal (0, mh.Bounds.X, "Bounds.X");
			Assert.Equal (0, mh.Bounds.Y, "Bounds.Y");
			Assert.Equal (0, mh.Bounds.Width, "Bounds.Width");
			Assert.Equal (0, mh.Bounds.Height, "Bounds.Height");
			Assert.Equal (0, mh.MetafileSize, "MetafileSize");
			switch (type) {
			case EmfType.EmfOnly:
				Assert.Equal (MetafileType.Emf, mh.Type, "Type");
				break;
			case EmfType.EmfPlusDual:
				Assert.Equal (MetafileType.EmfPlusDual, mh.Type, "Type");
				break;
			case EmfType.EmfPlusOnly:
				Assert.Equal (MetafileType.EmfPlusOnly, mh.Type, "Type");
				break;
			default:
				Assert.Fail ("Unknown EmfType '{0}'", type);
				break;
			}
		}

		private void Metafile_IntPtrEmfType (EmfType type)
		{
			using (Bitmap bmp = new Bitmap (10, 10, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						Metafile mf = new Metafile (hdc, type);
						CheckEmptyHeader (mf, type);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
			}
		}

		[Fact]
		public void Metafile_IntPtrEmfType_Invalid ()
		{
			Assert.Throws<ArgumentException> (() => Metafile_IntPtrEmfType ((EmfType)Int32.MinValue));
		}

		[Fact]
		public void Metafile_IntPtrEmfType_EmfOnly ()
		{
			Metafile_IntPtrEmfType (EmfType.EmfOnly);
		}

		[Fact]
		public void Metafile_IntPtrEmfType_EmfPlusDual ()
		{
			Metafile_IntPtrEmfType (EmfType.EmfPlusDual);
		}

		[Fact]
		public void Metafile_IntPtrEmfType_EmfPlusOnly ()
		{
			Metafile_IntPtrEmfType (EmfType.EmfPlusOnly);
		}

		[Fact]
		public void Metafile_IntPtrRectangle_Zero ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile (IntPtr.Zero, new Rectangle (1, 2, 3, 4)));
		}

		[Fact]
		public void Metafile_IntPtrRectangle_Empty ()
		{
			using (Bitmap bmp = new Bitmap (10, 10, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						Metafile mf = new Metafile (hdc, new Rectangle ());
						CheckEmptyHeader (mf, EmfType.EmfPlusDual);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
			}
		}

		[Fact]
		public void Metafile_IntPtrRectangleF_Zero ()
		{
			Assert.Throws<ArgumentException> (() => new Metafile (IntPtr.Zero, new RectangleF (1, 2, 3, 4)));
		}

		[Fact]
		public void Metafile_IntPtrRectangleF_Empty ()
		{
			using (Bitmap bmp = new Bitmap (10, 10, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						Metafile mf = new Metafile (hdc, new RectangleF ());
						CheckEmptyHeader (mf, EmfType.EmfPlusDual);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
			}
		}

		private void Metafile_StreamEmfType (Stream stream, EmfType type)
		{
			using (Bitmap bmp = new Bitmap (10, 10, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						Metafile mf = new Metafile (stream, hdc, type);
						CheckEmptyHeader (mf, type);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
			}
		}

		[Fact]
		public void Metafile_StreamIntPtrEmfType_Null ()
		{
			Assert.Throws<NullReferenceException> (() => Metafile_StreamEmfType (null, EmfType.EmfOnly));
		}

		[Fact]
		public void Metafile_StreamIntPtrEmfType_EmfOnly ()
		{
			using (MemoryStream ms = new MemoryStream ()) {
				Metafile_StreamEmfType (ms, EmfType.EmfOnly);
			}
		}

		[Fact]
		public void Metafile_StreamIntPtrEmfType_Invalid ()
		{
			using (MemoryStream ms = new MemoryStream ()) {
				Assert.Throws<ArgumentException> (() => Metafile_StreamEmfType (ms, (EmfType)Int32.MinValue));
			}
		}

		private void CreateFilename (EmfType type, bool single)
		{
			string name = String.Format ("{0}-{1}.emf", type, single ? "Single" : "Multiple");
			string filename = Path.Combine (Path.GetTempPath (), name);
			Metafile mf;
			using (Bitmap bmp = new Bitmap (100, 100, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						mf = new Metafile (filename, hdc, type);
						Assert.Equal (0, new FileInfo (filename).Length, "Empty");
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
				long size = 0;
				using (Graphics g = Graphics.FromImage (mf)) {
					g.FillRectangle (Brushes.BlueViolet, 10, 10, 80, 80);
					size = new FileInfo (filename).Length;
					Assert.Equal (0, size, "Still-Empty");
				}
// FIXME / doesn't work on mono yet
//				size = new FileInfo (filename).Length;
//				Assert.True (size > 0, "Non-Empty/GraphicsDisposed");
				if (!single) {
					// can we append stuff ?
					using (Graphics g = Graphics.FromImage (mf)) {
						g.DrawRectangle (Pens.Azure, 10, 10, 80, 80);
						// happily no :)
					}
				}
				mf.Dispose ();
				Assert.Equal (size, new FileInfo (filename).Length, "Non-Empty/MetafileDisposed");
			}
		}

		[Fact]
		public void CreateFilename_SingleGraphics_EmfOnly ()
		{
			CreateFilename (EmfType.EmfOnly, true);
		}

		[Fact]
		public void CreateFilename_SingleGraphics_EmfPlusDual ()
		{
			CreateFilename (EmfType.EmfPlusDual, true);
		}

		[Fact]
		public void CreateFilename_SingleGraphics_EmfPlusOnly ()
		{
			CreateFilename (EmfType.EmfPlusOnly, true);
		}

		[Fact]
		public void CreateFilename_MultipleGraphics_EmfOnly ()
		{
			Assert.Throws<OutOfMemoryException> (() => CreateFilename (EmfType.EmfOnly, false));
		}

		[Fact]
		public void CreateFilename_MultipleGraphics_EmfPlusDual ()
		{
			Assert.Throws<OutOfMemoryException> (() => CreateFilename (EmfType.EmfPlusDual, false));
		}

		[Fact]
		public void CreateFilename_MultipleGraphics_EmfPlusOnly ()
		{
			Assert.Throws<OutOfMemoryException> (() => CreateFilename (EmfType.EmfPlusOnly, false));
		}

		[Fact]
		public void Measure ()
		{
			if (test_font == null)
				Assert.Ignore ("No font family could be found.");

			Metafile mf;
			using (Bitmap bmp = new Bitmap (100, 100, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						mf = new Metafile (hdc, EmfType.EmfPlusOnly);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
				using (Graphics g = Graphics.FromImage (mf)) {
					string text = "this\nis a test";
					CharacterRange[] ranges = new CharacterRange[2];
					ranges[0] = new CharacterRange (0, 5);
					ranges[1] = new CharacterRange (5, 9);

					SizeF size = g.MeasureString (text, test_font);
					Assert.False (size.IsEmpty, "MeasureString");

					StringFormat sf = new StringFormat ();
					sf.FormatFlags = StringFormatFlags.NoClip;
					sf.SetMeasurableCharacterRanges (ranges);

					RectangleF rect = new RectangleF (0, 0, size.Width, size.Height);
					Region[] region = g.MeasureCharacterRanges (text, test_font, rect, sf);
					Assert.Equal (2, region.Length, "MeasureCharacterRanges");
				}
				mf.Dispose ();
			}
		}

		[Fact]
		public void WorldTransforms ()
		{
			Metafile mf;
			using (Bitmap bmp = new Bitmap (100, 100, PixelFormat.Format32bppArgb)) {
				using (Graphics g = Graphics.FromImage (bmp)) {
					IntPtr hdc = g.GetHdc ();
					try {
						mf = new Metafile (hdc, EmfType.EmfPlusOnly);
					}
					finally {
						g.ReleaseHdc (hdc);
					}
				}
				using (Graphics g = Graphics.FromImage (mf)) {
					Assert.True (g.Transform.IsIdentity, "Initial/IsIdentity");
					g.ScaleTransform (2f, 0.5f);
					Assert.False (g.Transform.IsIdentity, "Scale/IsIdentity");
					g.RotateTransform (90);
					g.TranslateTransform (-2, 2);
					Matrix m = g.Transform;
					g.MultiplyTransform (m);
					// check
					float[] elements = g.Transform.Elements;
					Assert.Equal (-1f, elements[0], 0.00001f, "a0");
					Assert.Equal (0f, elements[1], 0.00001f, "a1");
					Assert.Equal (0f, elements[2], 0.00001f, "a2");
					Assert.Equal (-1f, elements[3], 0.00001f, "a3");
					Assert.Equal (-2f, elements[4], 0.00001f, "a4");
					Assert.Equal (-3f, elements[5], 0.00001f, "a5");

					g.Transform = m;
					elements = g.Transform.Elements;
					Assert.Equal (0f, elements[0], 0.00001f, "b0");
					Assert.Equal (0.5f, elements[1], 0.00001f, "b1");
					Assert.Equal (-2f, elements[2], 0.00001f, "b2");
					Assert.Equal (0f, elements[3], 0.00001f, "b3");
					Assert.Equal (-4f, elements[4], 0.00001f, "b4");
					Assert.Equal (-1f, elements[5], 0.00001f, "b5");

					g.ResetTransform ();
					Assert.True (g.Transform.IsIdentity, "Reset/IsIdentity");
				}
				mf.Dispose ();
			}
		}
	}
}

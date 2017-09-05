//
// Copyright (C) 2005,2006 Novell, Inc (http://www.novell.com)
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
// Authors:
//	Jordi Mas i Hernàndez (jordi@ximian.com)
//	Sebastien Pouliot  <sebastien@ximian.com>
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Permissions;
using Xunit;

namespace MonoTests.System.Drawing.Imaging {

	public class ImageFormatTest {

		private static ImageFormat BmpImageFormat = new ImageFormat (new Guid ("b96b3cab-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat EmfImageFormat = new ImageFormat (new Guid ("b96b3cac-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat ExifImageFormat = new ImageFormat (new Guid ("b96b3cb2-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat GifImageFormat = new ImageFormat (new Guid ("b96b3cb0-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat TiffImageFormat = new ImageFormat (new Guid ("b96b3cb1-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat PngImageFormat = new ImageFormat(new Guid("b96b3caf-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat MemoryBmpImageFormat = new ImageFormat (new Guid ("b96b3caa-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat IconImageFormat = new ImageFormat (new Guid ("b96b3cb5-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat JpegImageFormat = new ImageFormat(new Guid("b96b3cae-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat WmfImageFormat = new ImageFormat (new Guid ("b96b3cad-0728-11d3-9d7b-0000f81ef32e"));
		private static ImageFormat CustomImageFormat = new ImageFormat (new Guid ("48749428-316f-496a-ab30-c819a92b3137"));

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void DefaultImageFormats ()
		{
			Assert.Equal (BmpImageFormat.Guid, ImageFormat.Bmp.Guid);
			Assert.Equal (EmfImageFormat.Guid, ImageFormat.Emf.Guid);
			Assert.Equal (ExifImageFormat.Guid, ImageFormat.Exif.Guid);
			Assert.Equal (GifImageFormat.Guid, ImageFormat.Gif.Guid);
			Assert.Equal (TiffImageFormat.Guid, ImageFormat.Tiff.Guid);
			Assert.Equal (PngImageFormat.Guid, ImageFormat.Png.Guid);
			Assert.Equal (MemoryBmpImageFormat.Guid, ImageFormat.MemoryBmp.Guid);
			Assert.Equal (IconImageFormat.Guid, ImageFormat.Icon.Guid);
			Assert.Equal (JpegImageFormat.Guid, ImageFormat.Jpeg.Guid);
			Assert.Equal (WmfImageFormat.Guid, ImageFormat.Wmf.Guid);
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void ToStringTest ()
		{
			Assert.Equal ("[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e]", BmpImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e]", EmfImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cb2-0728-11d3-9d7b-0000f81ef32e]", ExifImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e]", GifImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e]", TiffImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e]", PngImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e]", MemoryBmpImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e]", IconImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e]", JpegImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e]", WmfImageFormat.ToString ());
			Assert.Equal ("[ImageFormat: 48749428-316f-496a-ab30-c819a92b3137]", CustomImageFormat.ToString ());
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void WellKnown_ToString ()
		{
			Assert.Equal ("Bmp", ImageFormat.Bmp.ToString ());
			Assert.Equal ("Emf", ImageFormat.Emf.ToString ());
			Assert.Equal ("Exif", ImageFormat.Exif.ToString ());
			Assert.Equal ("Gif", ImageFormat.Gif.ToString ());
			Assert.Equal ("Tiff", ImageFormat.Tiff.ToString ());
			Assert.Equal ("Png", ImageFormat.Png.ToString ());
			Assert.Equal ("MemoryBMP", ImageFormat.MemoryBmp.ToString ());
			Assert.Equal ("Icon", ImageFormat.Icon.ToString ());
			Assert.Equal ("Jpeg", ImageFormat.Jpeg.ToString ());
			Assert.Equal ("Wmf", ImageFormat.Wmf.ToString ());
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void TestEquals ()
		{
			Assert.True (BmpImageFormat.Equals (BmpImageFormat));
			Assert.True (EmfImageFormat.Equals (EmfImageFormat));
			Assert.True (ExifImageFormat.Equals (ExifImageFormat));
			Assert.True (GifImageFormat.Equals (GifImageFormat));
			Assert.True (TiffImageFormat.Equals (TiffImageFormat));
			Assert.True (PngImageFormat.Equals (PngImageFormat));
			Assert.True (MemoryBmpImageFormat.Equals (MemoryBmpImageFormat));
			Assert.True (IconImageFormat.Equals (IconImageFormat));
			Assert.True (JpegImageFormat.Equals (JpegImageFormat));
			Assert.True (WmfImageFormat.Equals (WmfImageFormat));
			Assert.True (CustomImageFormat.Equals (CustomImageFormat));

			Assert.False (BmpImageFormat.Equals (EmfImageFormat));
			Assert.False (BmpImageFormat.Equals ("Bmp"));
			Assert.False (BmpImageFormat.Equals (BmpImageFormat.ToString ()));
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void TestGetHashCode ()
		{
			Assert.Equal (BmpImageFormat.GetHashCode (), BmpImageFormat.Guid.GetHashCode ());
			Assert.Equal (EmfImageFormat.GetHashCode (), EmfImageFormat.Guid.GetHashCode ());
			Assert.Equal (ExifImageFormat.GetHashCode (), ExifImageFormat.Guid.GetHashCode ());
			Assert.Equal (GifImageFormat.GetHashCode (), GifImageFormat.Guid.GetHashCode ());
			Assert.Equal (TiffImageFormat.GetHashCode (), TiffImageFormat.Guid.GetHashCode ());
			Assert.Equal (PngImageFormat.GetHashCode (), PngImageFormat.Guid.GetHashCode ());
			Assert.Equal (MemoryBmpImageFormat.GetHashCode (), MemoryBmpImageFormat.Guid.GetHashCode ());
			Assert.Equal (IconImageFormat.GetHashCode (), IconImageFormat.Guid.GetHashCode ());
			Assert.Equal (JpegImageFormat.GetHashCode (), JpegImageFormat.Guid.GetHashCode ());
			Assert.Equal (WmfImageFormat.GetHashCode (), WmfImageFormat.Guid.GetHashCode ());
			Assert.Equal (CustomImageFormat.GetHashCode (), CustomImageFormat.Guid.GetHashCode ());
		}
	}
}

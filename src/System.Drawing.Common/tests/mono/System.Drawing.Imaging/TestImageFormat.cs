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

	[TestFixture]
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

		[Fact]
		public void DefaultImageFormats ()
		{
			Assert.Equal (BmpImageFormat.Guid, ImageFormat.Bmp.Guid, "DefaultImageFormats#1");
			Assert.Equal (EmfImageFormat.Guid, ImageFormat.Emf.Guid, "DefaultImageFormats#2");
			Assert.Equal (ExifImageFormat.Guid, ImageFormat.Exif.Guid, "DefaultImageFormats#3");
			Assert.Equal (GifImageFormat.Guid, ImageFormat.Gif.Guid, "DefaultImageFormats#4");
			Assert.Equal (TiffImageFormat.Guid, ImageFormat.Tiff.Guid, "DefaultImageFormats#5");
			Assert.Equal (PngImageFormat.Guid, ImageFormat.Png.Guid, "DefaultImageFormats#6");
			Assert.Equal (MemoryBmpImageFormat.Guid, ImageFormat.MemoryBmp.Guid, "DefaultImageFormats#7");
			Assert.Equal (IconImageFormat.Guid, ImageFormat.Icon.Guid, "DefaultImageFormats#8");
			Assert.Equal (JpegImageFormat.Guid, ImageFormat.Jpeg.Guid, "DefaultImageFormats#9");
			Assert.Equal (WmfImageFormat.Guid, ImageFormat.Wmf.Guid, "DefaultImageFormats#10");
		}

		[Fact]
		public void ToStringTest ()
		{
			Assert.Equal ("[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e]", BmpImageFormat.ToString (),"ToStringTest#1");
			Assert.Equal ("[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e]", EmfImageFormat.ToString (), "ToStringTest#2");
			Assert.Equal ("[ImageFormat: b96b3cb2-0728-11d3-9d7b-0000f81ef32e]", ExifImageFormat.ToString (), "ToStringTest#3");
			Assert.Equal ("[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e]", GifImageFormat.ToString (), "ToStringTest#4");
			Assert.Equal ("[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e]", TiffImageFormat.ToString (), "ToStringTest#5");
			Assert.Equal ("[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e]", PngImageFormat.ToString (), "ToStringTest#6");
			Assert.Equal ("[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e]", MemoryBmpImageFormat.ToString (), "ToStringTest#7");
			Assert.Equal ("[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e]", IconImageFormat.ToString (), "ToStringTest#8");
			Assert.Equal ("[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e]", JpegImageFormat.ToString (), "ToStringTest#9");
			Assert.Equal ("[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e]", WmfImageFormat.ToString (), "ToStringTest#10");
			Assert.Equal ("[ImageFormat: 48749428-316f-496a-ab30-c819a92b3137]", CustomImageFormat.ToString (), "ToStringTest#11");
		}

		[Fact]
		public void WellKnown_ToString ()
		{
			Assert.Equal ("Bmp", ImageFormat.Bmp.ToString (),"ToStringTest#1");
			Assert.Equal ("Emf", ImageFormat.Emf.ToString (), "ToStringTest#2");
			Assert.Equal ("Exif", ImageFormat.Exif.ToString (), "ToStringTest#3");
			Assert.Equal ("Gif", ImageFormat.Gif.ToString (), "ToStringTest#4");
			Assert.Equal ("Tiff", ImageFormat.Tiff.ToString (), "ToStringTest#5");
			Assert.Equal ("Png", ImageFormat.Png.ToString (), "ToStringTest#6");
			Assert.Equal ("MemoryBMP", ImageFormat.MemoryBmp.ToString (), "ToStringTest#7");
			Assert.Equal ("Icon", ImageFormat.Icon.ToString (), "ToStringTest#8");
			Assert.Equal ("Jpeg", ImageFormat.Jpeg.ToString (), "ToStringTest#9");
			Assert.Equal ("Wmf", ImageFormat.Wmf.ToString (), "ToStringTest#10");
		}

		[Fact]
		public void TestEquals ()
		{
			Assert.True (BmpImageFormat.Equals (BmpImageFormat), "Bmp-Bmp");
			Assert.True (EmfImageFormat.Equals (EmfImageFormat), "Emf-Emf");
			Assert.True (ExifImageFormat.Equals (ExifImageFormat), "Exif-Exif");
			Assert.True (GifImageFormat.Equals (GifImageFormat), "Gif-Gif");
			Assert.True (TiffImageFormat.Equals (TiffImageFormat), "Tiff-Tiff");
			Assert.True (PngImageFormat.Equals (PngImageFormat), "Png-Png");
			Assert.True (MemoryBmpImageFormat.Equals (MemoryBmpImageFormat), "MemoryBmp-MemoryBmp");
			Assert.True (IconImageFormat.Equals (IconImageFormat), "Icon-Icon");
			Assert.True (JpegImageFormat.Equals (JpegImageFormat), "Jpeg-Jpeg");
			Assert.True (WmfImageFormat.Equals (WmfImageFormat), "Wmf-Wmf");
			Assert.True (CustomImageFormat.Equals (CustomImageFormat), "Custom-Custom");

			Assert.False (BmpImageFormat.Equals (EmfImageFormat), "Bmp-Emf");
			Assert.False (BmpImageFormat.Equals ("Bmp"), "Bmp-String-1");
			Assert.False (BmpImageFormat.Equals (BmpImageFormat.ToString ()), "Bmp-String-2");
		}

		[Fact]
		public void TestGetHashCode ()
		{
			Assert.Equal (BmpImageFormat.GetHashCode (), BmpImageFormat.Guid.GetHashCode (), "Bmp");
			Assert.Equal (EmfImageFormat.GetHashCode (), EmfImageFormat.Guid.GetHashCode (), "Emf");
			Assert.Equal (ExifImageFormat.GetHashCode (), ExifImageFormat.Guid.GetHashCode (), "Exif");
			Assert.Equal (GifImageFormat.GetHashCode (), GifImageFormat.Guid.GetHashCode (), "Gif");
			Assert.Equal (TiffImageFormat.GetHashCode (), TiffImageFormat.Guid.GetHashCode (), "Tiff");
			Assert.Equal (PngImageFormat.GetHashCode (), PngImageFormat.Guid.GetHashCode (), "Png");
			Assert.Equal (MemoryBmpImageFormat.GetHashCode (), MemoryBmpImageFormat.Guid.GetHashCode (), "MemoryBmp");
			Assert.Equal (IconImageFormat.GetHashCode (), IconImageFormat.Guid.GetHashCode (), "Icon");
			Assert.Equal (JpegImageFormat.GetHashCode (), JpegImageFormat.Guid.GetHashCode (), "Jpeg");
			Assert.Equal (WmfImageFormat.GetHashCode (), WmfImageFormat.Guid.GetHashCode (), "Wmf");
			Assert.Equal (CustomImageFormat.GetHashCode (), CustomImageFormat.Guid.GetHashCode (), "Custom");
		}
	}
}

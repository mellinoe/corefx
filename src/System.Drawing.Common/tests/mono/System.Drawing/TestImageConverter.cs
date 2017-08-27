//
// Tests for System.Drawing.ImageConverter.cs 
//
// Authors:
//	Sanjay Gupta (gsanjay@novell.com)
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004, 2006 Novell, Inc (http://www.novell.com)
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


using Xunit;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Security.Permissions;

namespace MonoTests.System.Drawing
{
	[TestFixture]
	public class ImageConverterTest 
	{
		Image image;		
		ImageConverter imgConv;
		ImageConverter imgConvFrmTD;
		String imageStr;
		byte [] imageBytes;

		[SetUp]
		public void SetUp ()		
		{
			image = Image.FromFile (TestBitmap.getInFile ("bitmaps/almogaver24bits.bmp"));
			imageStr = image.ToString ();
		
			imgConv = new ImageConverter();
			imgConvFrmTD = (ImageConverter) TypeDescriptor.GetConverter (image);
			
			Stream stream = new FileStream (TestBitmap.getInFile ("bitmaps/almogaver24bits1.bmp"), FileMode.Open);
			int length = (int) stream.Length;
			imageBytes = new byte [length];
 			
			try {
				if (stream.Read (imageBytes, 0, length) != length)
					Assert.Fail ("SU#1: Read Failure"); 
			} catch (Exception e) {
				Assert.Fail ("SU#2 Exception thrown while reading. Exception is: "+e.Message);
			} finally {
				stream.Close ();
			}
		
			stream.Close ();

		}

		[Fact]
		public void TestCanConvertFrom ()
		{
			Assert.True (imgConv.CanConvertFrom (typeof (byte [])), "CCF#1");
			Assert.True (imgConv.CanConvertFrom (null, typeof (byte [])), "CCF#1a");
			Assert.True (imgConv.CanConvertFrom (null, imageBytes.GetType ()), "CCF#1b");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (String)), "CCF#2");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (Rectangle)), "CCF#3");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (Point)), "CCF#4");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (PointF)), "CCF#5");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (Size)), "CCF#6");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (SizeF)), "CCF#7");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (Object)), "CCF#8");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (int)), "CCF#9");
			Assert.True (! imgConv.CanConvertFrom (null, typeof (Metafile)), "CCF#10");

			Assert.True (imgConvFrmTD.CanConvertFrom (typeof (byte [])), "CCF#1A");
			Assert.True (imgConvFrmTD.CanConvertFrom (null, typeof (byte [])), "CCF#1aA");
			Assert.True (imgConvFrmTD.CanConvertFrom (null, imageBytes.GetType ()), "CCF#1bA");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (String)), "CCF#2A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (Rectangle)), "CCF#3A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (Point)), "CCF#4A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (PointF)), "CCF#5A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (Size)), "CCF#6A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (SizeF)), "CCF#7A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (Object)), "CCF#8A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (int)), "CCF#9A");
			Assert.True (! imgConvFrmTD.CanConvertFrom (null, typeof (Metafile)), "CCF#10A");

		}

		[Fact]
		public void TestCanConvertTo ()
		{
			Assert.True (imgConv.CanConvertTo (typeof (String)), "CCT#1");
			Assert.True (imgConv.CanConvertTo (null, typeof (String)), "CCT#1a");
			Assert.True (imgConv.CanConvertTo (null, imageStr.GetType ()), "CCT#1b");
			Assert.True (imgConv.CanConvertTo (typeof (byte [])), "CCT#2");
			Assert.True (imgConv.CanConvertTo (null, typeof (byte [])), "CCT#2a");
			Assert.True (imgConv.CanConvertTo (null, imageBytes.GetType ()), "CCT#2b");
			Assert.True (! imgConv.CanConvertTo (null, typeof (Rectangle)), "CCT#3");
			Assert.True (! imgConv.CanConvertTo (null, typeof (Point)), "CCT#4");
			Assert.True (! imgConv.CanConvertTo (null, typeof (PointF)), "CCT#5");
			Assert.True (! imgConv.CanConvertTo (null, typeof (Size)), "CCT#6");
			Assert.True (! imgConv.CanConvertTo (null, typeof (SizeF)), "CCT#7");
			Assert.True (! imgConv.CanConvertTo (null, typeof (Object)), "CCT#8");
			Assert.True (! imgConv.CanConvertTo (null, typeof (int)), "CCT#9");

			Assert.True (imgConvFrmTD.CanConvertTo (typeof (String)), "CCT#1A");
			Assert.True (imgConvFrmTD.CanConvertTo (null, typeof (String)), "CCT#1aA");
			Assert.True (imgConvFrmTD.CanConvertTo (null, imageStr.GetType ()), "CCT#1bA");
			Assert.True (imgConvFrmTD.CanConvertTo (typeof (byte [])), "CCT#2A");
			Assert.True (imgConvFrmTD.CanConvertTo (null, typeof (byte [])), "CCT#2aA");
			Assert.True (imgConvFrmTD.CanConvertTo (null, imageBytes.GetType ()), "CCT#2bA");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (Rectangle)), "CCT#3A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (Point)), "CCT#4A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (PointF)), "CCT#5A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (Size)), "CCT#6A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (SizeF)), "CCT#7A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (Object)), "CCT#8A");
			Assert.True (! imgConvFrmTD.CanConvertTo (null, typeof (int)), "CCT#9A");

		}

		[Fact]
		public void ConvertFrom ()
		{
			Image newImage = (Image) imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, imageBytes);
			
			Assert.Equal (image.Height, newImage.Height, "CF#1");
			Assert.Equal (image.Width, newImage.Width, "CF#1a");

			Assert.Equal ("(none)", imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, null, typeof (string)), "Null/Empty");

			newImage = (Image) imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, imageBytes);

			Assert.Equal (image.Height, newImage.Height, "CF#1A");
			Assert.Equal (image.Width, newImage.Width, "CF#1aA");
		}
		
		[Fact]
		public void ConvertFrom_BadString ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom ("System.Drawing.String"));
		}

		[Fact]
		public void ConvertFrom_BadString_WithCulture ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, "System.Drawing.String"));
		}

		[Fact]
		public void ConvertFrom_Bitmap ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, new Bitmap (20, 20)));
		}

		[Fact]
		public void ConvertFrom_Point ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, new Point (10, 10)));
		}

		[Fact]
		public void ConvertFrom_SizeF ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, new SizeF (10, 10)));
		}

		[Fact]
		public void ConvertFrom_Object ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertFrom (null, CultureInfo.InvariantCulture, new Object ()));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_BadString ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom ("System.Drawing.String"));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_BadString_Culture ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, "System.Drawing.String"));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_Bitmap ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, new Bitmap (20, 20)));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_Point ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, new Point (10, 10)));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_SizeF ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, new SizeF (10, 10)));
		}

		[Fact]
		public void TypeDescriptor_ConvertFrom_Object ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, new Object ()));
		}

		[Fact]
		public void ConvertTo ()
		{
			Assert.Equal (imageStr, (String) imgConv.ConvertTo (null, CultureInfo.InvariantCulture,
				image, typeof (string)), "CT#1");

			Assert.Equal (imageStr, (String) imgConv.ConvertTo (image, typeof (string)), "CT#1a");

			Assert.Equal (imageStr, (String) imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture,
				image, typeof (string)), "CT#1A");

			Assert.Equal (imageStr, (String) imgConvFrmTD.ConvertTo (image, typeof (string)), "CT#1aA");
		}
				
		[Fact]
		[NUnit.Framework.Category ("NotWorking")]
		public void ConvertTo_ByteArray ()
		{
			byte[] newImageBytes = (byte[]) imgConv.ConvertTo (null, CultureInfo.InvariantCulture,
				image, imageBytes.GetType ());

			Assert.Equal (imageBytes.Length, newImageBytes.Length, "CT#2");

			newImageBytes = (byte[]) imgConv.ConvertTo (image, imageBytes.GetType ());
			
			Assert.Equal (imageBytes.Length, newImageBytes.Length, "CT#2a");

			newImageBytes = (byte[]) imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture,
				image, imageBytes.GetType ());

			Assert.Equal (imageBytes.Length, newImageBytes.Length, "CT#2A");

			newImageBytes = (byte[]) imgConvFrmTD.ConvertTo (image, imageBytes.GetType ());
			
			Assert.Equal (imageBytes.Length, newImageBytes.Length, "CT#2aA");
		}

		[Fact]
		public void ConvertTo_Rectangle ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Rectangle)));
		}

		[Fact]
		public void ConvertTo_Image ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, image.GetType ()));
		}

		[Fact]
		public void ConvertTo_Size ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Size)));
		}

		[Fact]
		public void ConvertTo_Bitmap ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Bitmap)));
		}

		[Fact]
		public void ConvertTo_Point ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Point)));
		}

		[Fact]
		public void ConvertTo_Metafile ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Metafile)));
		}

		[Fact]
		public void ConvertTo_Object ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Object)));
		}

		[Fact]
		public void ConvertTo_Int ()
		{
			Assert.Throws<NotSupportedException> (() => imgConv.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (int)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Rectangle ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Rectangle)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Image ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, image.GetType ()));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Size ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Size)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Bitmap ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Bitmap)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Point ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Point)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Metafile ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Metafile)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Object ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (Object)));
		}

		[Fact]
		public void TypeDescriptor_ConvertTo_Int ()
		{
			Assert.Throws<NotSupportedException> (() => imgConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, image, typeof (int)));
		}

		[Fact]
		public void TestGetPropertiesSupported ()
		{
			Assert.True (imgConv.GetPropertiesSupported (), "GPS#1");
			Assert.True (imgConv.GetPropertiesSupported (null), "GPS#2");
		}

		[Fact]
		public void TestGetProperties ()
		{
			int basecount = 1;
			PropertyDescriptorCollection propsColl;

			propsColl = imgConv.GetProperties (null, image, null);
			Assert.Equal (13 + basecount, propsColl.Count, "GP1#1");
			
			propsColl = imgConv.GetProperties (null, image);
			Assert.Equal (6 + basecount, propsColl.Count, "GP1#2");

			propsColl = imgConv.GetProperties (image);
			Assert.Equal (6 + basecount, propsColl.Count, "GP1#3");

			propsColl = TypeDescriptor.GetProperties (typeof (Image));
			Assert.Equal (13 + basecount, propsColl.Count, "GP1#4");
			
			propsColl = imgConvFrmTD.GetProperties (null, image, null);
			Assert.Equal (13 + basecount, propsColl.Count, "GP1#1A");
			
			propsColl = imgConvFrmTD.GetProperties (null, image);
			Assert.Equal (6 + basecount, propsColl.Count, "GP1#2A");

			propsColl = imgConvFrmTD.GetProperties (image);
			Assert.Equal (6 + basecount, propsColl.Count, "GP1#3A");
		}
	}
}

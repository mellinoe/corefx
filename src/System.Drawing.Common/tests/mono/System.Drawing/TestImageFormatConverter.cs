//
// Tests for System.Drawing.ImageFormatConverter.cs 
//
// Authors:
//	Sanjay Gupta (gsanjay@novell.com)
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004,2006 Novell, Inc (http://www.novell.com)
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Security.Permissions;

namespace MonoTests.System.Drawing
{
	[TestFixture]
	public class ImageFormatConverterTest
	{
		ImageFormat imageFmt;		
		ImageFormatConverter imgFmtConv;
		ImageFormatConverter imgFmtConvFrmTD;
		String imageFmtStr;

		[SetUp]
		public void SetUp ()		
		{
			imageFmt = ImageFormat.Bmp; 
			imageFmtStr = imageFmt.ToString ();
		
			imgFmtConv = new ImageFormatConverter();
			imgFmtConvFrmTD = (ImageFormatConverter) TypeDescriptor.GetConverter (imageFmt);			
		}

		[Fact]
		public void TestCanConvertFrom ()
		{
			Assert.True (imgFmtConv.CanConvertFrom (typeof (String)), "CCF#1");
			Assert.True (imgFmtConv.CanConvertFrom (null, typeof (String)), "CCF#1a");
			Assert.True (! imgFmtConv.CanConvertFrom (null, typeof (ImageFormat)), "CCF#2");
			Assert.True (! imgFmtConv.CanConvertFrom (null, typeof (Guid)), "CCF#3");
			Assert.True (! imgFmtConv.CanConvertFrom (null, typeof (Object)), "CCF#4");
			Assert.True (! imgFmtConv.CanConvertFrom (null, typeof (int)), "CCF#5");

			Assert.True (imgFmtConvFrmTD.CanConvertFrom (typeof (String)), "CCF#1A");
			Assert.True (imgFmtConvFrmTD.CanConvertFrom (null, typeof (String)), "CCF#1aA");
			Assert.True (! imgFmtConvFrmTD.CanConvertFrom (null, typeof (ImageFormat)), "CCF#2A");
			Assert.True (! imgFmtConvFrmTD.CanConvertFrom (null, typeof (Guid)), "CCF#3A");
			Assert.True (! imgFmtConvFrmTD.CanConvertFrom (null, typeof (Object)), "CCF#4A");
			Assert.True (! imgFmtConvFrmTD.CanConvertFrom (null, typeof (int)), "CCF#5A");

		}

		[Fact]
		public void TestCanConvertTo ()
		{
			Assert.True (imgFmtConv.CanConvertTo (typeof (String)), "CCT#1");
			Assert.True (imgFmtConv.CanConvertTo (null, typeof (String)), "CCT#1a");
			Assert.True (! imgFmtConv.CanConvertTo (null, typeof (ImageFormat)), "CCT#2");
			Assert.True (! imgFmtConv.CanConvertTo (null, typeof (Guid)), "CCT#3");
			Assert.True (! imgFmtConv.CanConvertTo (null, typeof (Object)), "CCT#4");
			Assert.True (! imgFmtConv.CanConvertTo (null, typeof (int)), "CCT#5");

			Assert.True (imgFmtConvFrmTD.CanConvertTo (typeof (String)), "CCT#1A");
			Assert.True (imgFmtConvFrmTD.CanConvertTo (null, typeof (String)), "CCT#1aA");
			Assert.True (! imgFmtConvFrmTD.CanConvertTo (null, typeof (ImageFormat)), "CCT#2A");
			Assert.True (! imgFmtConvFrmTD.CanConvertTo (null, typeof (Guid)), "CCT#3A");
			Assert.True (! imgFmtConvFrmTD.CanConvertTo (null, typeof (Object)), "CCT#4A");
			Assert.True (! imgFmtConvFrmTD.CanConvertTo (null, typeof (int)), "CCT#5A");
		}

		[Fact]
		public void TestConvertFrom ()
		{
			Assert.Equal (imageFmt, (ImageFormat) imgFmtConv.ConvertFrom (null,
								CultureInfo.InvariantCulture,
								ImageFormat.Bmp.ToString ()), "CF#1");
			
			try {
				imgFmtConv.ConvertFrom ("System.Drawing.String");
				Assert.Fail ("CF#2: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#2");
			}

			try {
				imgFmtConv.ConvertFrom (null, CultureInfo.InvariantCulture,
						   "System.Drawing.String");
				Assert.Fail ("CF#2a: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#2a");
			}

			try {
				imgFmtConv.ConvertFrom (null, CultureInfo.InvariantCulture,
						   ImageFormat.Bmp);
				Assert.Fail ("CF#3: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#3");
			}

			try {
				imgFmtConv.ConvertFrom (null, CultureInfo.InvariantCulture,
						   ImageFormat.Bmp.Guid);
				Assert.Fail ("CF#4: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#4");
			}

			try {
				imgFmtConv.ConvertFrom (null, CultureInfo.InvariantCulture,
						   new Object ());
				Assert.Fail ("CF#5: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#5");
			}

			try {
				imgFmtConv.ConvertFrom (null, CultureInfo.InvariantCulture, 10);
				Assert.Fail ("CF#6: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#6");
			}

			
			Assert.Equal (imageFmt, (ImageFormat) imgFmtConvFrmTD.ConvertFrom (null,
								CultureInfo.InvariantCulture,
								ImageFormat.Bmp.ToString ()), "CF#1A");
			
			try {
				imgFmtConvFrmTD.ConvertFrom ("System.Drawing.String");
				Assert.Fail ("CF#2A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#2A");
			}

			try {
				imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture,
						   "System.Drawing.String");
				Assert.Fail ("CF#2aA: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#2aA");
			}

			try {
				imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture,
						   ImageFormat.Bmp);
				Assert.Fail ("CF#3A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#3A");
			}

			try {
				imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture,
						   ImageFormat.Bmp.Guid);
				Assert.Fail ("CF#4A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#4A");
			}

			try {
				imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture,
						   new Object ());
				Assert.Fail ("CF#5A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#5A");
			}

			try {
				imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, 10);
				Assert.Fail ("CF#6A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CF#6A");
			}
		}

		private ImageFormat ShortName (string s)
		{
			return (ImageFormat) imgFmtConvFrmTD.ConvertFrom (null, CultureInfo.InvariantCulture, s);
		}

		[Fact]
		public void ConvertFrom_ShortName ()
		{
			Assert.Equal (ImageFormat.Bmp, ShortName ("Bmp"), "Bmp");
			Assert.Equal (ImageFormat.Emf, ShortName ("Emf"), "Emf");
			Assert.Equal (ImageFormat.Exif, ShortName ("Exif"), "Exif");
			Assert.Equal (ImageFormat.Gif, ShortName ("Gif"), "Gif");
			Assert.Equal (ImageFormat.Tiff, ShortName ("Tiff"), "Tiff");
			Assert.Equal (ImageFormat.Png, ShortName ("Png"), "Png");
			Assert.Equal (ImageFormat.MemoryBmp, ShortName ("MemoryBmp"), "MemoryBmp");
			Assert.Equal (ImageFormat.Icon, ShortName ("Icon"), "Icon");
			Assert.Equal (ImageFormat.Jpeg, ShortName ("Jpeg"), "Jpeg");
			Assert.Equal (ImageFormat.Wmf, ShortName ("Wmf"), "Wmf");
		}

		private void LongName (ImageFormat f, string s)
		{
			Assert.Equal (f, (ImageFormat) imgFmtConvFrmTD.ConvertFrom (null,
				CultureInfo.InvariantCulture, f.ToString ()), s);
		}

		[Fact]
		[NUnit.Framework.Category ("NotWorking")]
		public void ConvertFrom_LongName ()
		{
			LongName (ImageFormat.Bmp, "Bmp");
			LongName (ImageFormat.Emf, "Emf");
			LongName (ImageFormat.Exif, "Exif");
			LongName (ImageFormat.Gif, "Gif");
			LongName (ImageFormat.Tiff, "Tiff");
			LongName (ImageFormat.Png, "Png");
			LongName (ImageFormat.MemoryBmp, "MemoryBmp");
			LongName (ImageFormat.Icon, "Icon");
			LongName (ImageFormat.Jpeg, "Jpeg");
			LongName (ImageFormat.Wmf, "Wmf");
		}

		[Fact]
		public void TestConvertTo ()
		{
			Assert.Equal (imageFmtStr, (String) imgFmtConv.ConvertTo (null,
								CultureInfo.InvariantCulture,
								imageFmt, typeof (String)), "CT#1");

			Assert.Equal (imageFmtStr, (String) imgFmtConv.ConvertTo (imageFmt, 
									typeof (String)), "CT#1a");
							
			try {
				imgFmtConv.ConvertTo (null, CultureInfo.InvariantCulture, 
						 imageFmt, typeof (ImageFormat));
				Assert.Fail ("CT#2: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#2");
			}

			try {
				imgFmtConv.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (Guid));
				Assert.Fail ("CT#2a: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#2a");
			}

			try {
				imgFmtConv.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (Object));
				Assert.Fail ("CT#3: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#3");
			}

			try {
				imgFmtConv.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (int));
				Assert.Fail ("CT#4: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#4");
			}


			Assert.Equal (imageFmtStr, (String) imgFmtConvFrmTD.ConvertTo (null,
								CultureInfo.InvariantCulture,
								imageFmt, typeof (String)), "CT#1A");

			Assert.Equal (imageFmtStr, (String) imgFmtConvFrmTD.ConvertTo (imageFmt, 
									typeof (String)), "CT#1aA");
							
			try {
				imgFmtConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture, 
						 imageFmt, typeof (ImageFormat));
				Assert.Fail ("CT#2A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#2A");
			}

			try {
				imgFmtConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (Guid));
				Assert.Fail ("CT#2aA: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#2aA");
			}

			try {
				imgFmtConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (Object));
				Assert.Fail ("CT#3A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#3A");
			}

			try {
				imgFmtConvFrmTD.ConvertTo (null, CultureInfo.InvariantCulture,
						 imageFmt, typeof (int));
				Assert.Fail ("CT#4A: must throw NotSupportedException");
			} catch (Exception e) {
				Assert.True (e is NotSupportedException, "CT#4A");
			}
		}

		[Fact]
		public void GetStandardValuesSupported ()
		{
			Assert.True (imgFmtConv.GetStandardValuesSupported (), "GetStandardValuesSupported()");
			Assert.True (imgFmtConv.GetStandardValuesSupported (null), "GetStandardValuesSupported(null)");
		}

		private void CheckStandardValues (string msg, ICollection c)
		{
			bool memorybmp = false;
			bool bmp = false;
			bool emf = false;
			bool wmf = false;
			bool gif = false;
			bool jpeg = false;
			bool png = false;
			bool tiff = false;
			bool exif = false;
			bool icon = false;

			foreach (ImageFormat iformat in c) {
				switch (iformat.Guid.ToString ()) {
				case "b96b3caa-0728-11d3-9d7b-0000f81ef32e":
					memorybmp = true;
					break;
				case "b96b3cab-0728-11d3-9d7b-0000f81ef32e":
					bmp = true;
					break;
				case "b96b3cac-0728-11d3-9d7b-0000f81ef32e":
					emf = true;
					break;
				case "b96b3cad-0728-11d3-9d7b-0000f81ef32e":
					wmf = true;
					break;
				case "b96b3cb0-0728-11d3-9d7b-0000f81ef32e":
					gif = true;
					break;
				case "b96b3cae-0728-11d3-9d7b-0000f81ef32e":
					jpeg = true;
					break;
				case "b96b3caf-0728-11d3-9d7b-0000f81ef32e":
					png = true;
					break;
				case "b96b3cb1-0728-11d3-9d7b-0000f81ef32e":
					tiff = true;
					break;
				case "b96b3cb2-0728-11d3-9d7b-0000f81ef32e":
					exif = true;
					break;
				case "b96b3cb5-0728-11d3-9d7b-0000f81ef32e":
					icon = true;
					break;
				default:
					Assert.Fail ("Unknown GUID {0}", iformat.Guid.ToString ());
					break;
				}
			}
			Assert.True (memorybmp, "MemoryBMP");
			Assert.True (bmp, "Bmp");
			Assert.True (emf, "Emf");
			Assert.True (wmf, "Wmf");
			Assert.True (gif, "Gif");
			Assert.True (jpeg, "Jpeg");
			Assert.True (png, "Png");
			Assert.True (tiff, "Tiff");
			Assert.True (exif, "Exif");
			Assert.True (icon, "Icon");
		}

		[Fact]
		public void GetStandardValues ()
		{
			CheckStandardValues ("(empty)", imgFmtConv.GetStandardValues ());
			CheckStandardValues ("(null)", imgFmtConv.GetStandardValues (null));
		}
	}
}

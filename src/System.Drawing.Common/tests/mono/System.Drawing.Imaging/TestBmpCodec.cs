//
// BMPCodec class testing unit
//
// Authors:
// 	Jordi Mas i Hernàndez (jordi@ximian.com)
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// (C) 2004 Ximian, Inc.  http://www.ximian.com
// Copyright (C) 2004-2007 Novell, Inc (http://www.novell.com)
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
using System.Drawing.Imaging;
using Xunit;
using System.IO;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;

namespace MonoTests.System.Drawing.Imaging {

	[TestFixture]
	public class BmpCodecTest {
		
		/* Get suffix to add to the filename */
		internal string getOutSufix()
		{
			string s;

			int p = (int) Environment.OSVersion.Platform;
			if ((p == 4) || (p == 128) || (p == 6))
				s = "-unix";
			else
				s = "-windows";

			if (Type.GetType ("Mono.Runtime", false) == null)
				s += "-msnet";
			else
				s += "-mono";

			return s;
		}

		/* Get the input directory depending on the runtime*/
		internal string getInFile(string file)
		{
			string sRslt = Path.GetFullPath ("../System.Drawing/" + file);

			if (!File.Exists (sRslt))
				sRslt = "Test/System.Drawing/" + file;

			return sRslt;
		}

		/* Checks bitmap features on a know 1bbp bitmap */
		[Fact]
		public void Bitmap1bitFeatures ()
		{
			string sInFile = getInFile ("bitmaps/almogaver1bit.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				GraphicsUnit unit = GraphicsUnit.World;
				RectangleF rect = bmp.GetBounds (ref unit);

				// ??? why is it a 4bbp ?
				Assert.Equal (PixelFormat.Format4bppIndexed, bmp.PixelFormat);
				Assert.Equal (173, bmp.Width, "bmp.Width");
				Assert.Equal (183, bmp.Height, "bmp.Height");

				Assert.Equal (0, rect.X, "rect.X");
				Assert.Equal (0, rect.Y, "rect.Y");
				Assert.Equal (173, rect.Width, "rect.Width");
				Assert.Equal (183, rect.Height, "rect.Height");

				Assert.Equal (173, bmp.Size.Width, "bmp.Size.Width");
				Assert.Equal (183, bmp.Size.Height, "bmp.Size.Height");
			}
		}

		[Fact]
		public void Bitmap1bitPixels ()
		{
			string sInFile = getInFile ("bitmaps/almogaver1bit.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
#if false
				for (int x = 0; x < bmp.Width; x += 32) {
					for (int y = 0; y < bmp.Height; y += 32)
						Console.WriteLine ("\t\t\t\tAssert.Equal ({0}, bmp.GetPixel ({1}, {2}).ToArgb (), \"{1},{2}\");", bmp.GetPixel (x, y).ToArgb (), x, y);
				}
#else
				// sampling values from a well known bitmap
				Assert.Equal (-1, bmp.GetPixel (0, 0).ToArgb (), "0,0");
				Assert.Equal (-4144960, bmp.GetPixel (0, 32).ToArgb (), "0,32");
				Assert.Equal (-1, bmp.GetPixel (0, 64).ToArgb (), "0,64");
				Assert.Equal (-1, bmp.GetPixel (0, 96).ToArgb (), "0,96");
				Assert.Equal (-4144960, bmp.GetPixel (0, 128).ToArgb (), "0,128");
				Assert.Equal (-1, bmp.GetPixel (0, 160).ToArgb (), "0,160");
				Assert.Equal (-4144960, bmp.GetPixel (32, 0).ToArgb (), "32,0");
				Assert.Equal (-4144960, bmp.GetPixel (32, 32).ToArgb (), "32,32");
				Assert.Equal (-1, bmp.GetPixel (32, 64).ToArgb (), "32,64");
				Assert.Equal (-4144960, bmp.GetPixel (32, 96).ToArgb (), "32,96");
				Assert.Equal (-4144960, bmp.GetPixel (32, 128).ToArgb (), "32,128");
				Assert.Equal (-8355712, bmp.GetPixel (32, 160).ToArgb (), "32,160");
				Assert.Equal (-16777216, bmp.GetPixel (64, 0).ToArgb (), "64,0");
				Assert.Equal (-8355712, bmp.GetPixel (64, 32).ToArgb (), "64,32");
				Assert.Equal (-1, bmp.GetPixel (64, 64).ToArgb (), "64,64");
				Assert.Equal (-16777216, bmp.GetPixel (64, 96).ToArgb (), "64,96");
				Assert.Equal (-8355840, bmp.GetPixel (64, 128).ToArgb (), "64,128");
				Assert.Equal (-16777216, bmp.GetPixel (64, 160).ToArgb (), "64,160");
				Assert.Equal (-4144960, bmp.GetPixel (96, 0).ToArgb (), "96,0");
				Assert.Equal (-8355712, bmp.GetPixel (96, 32).ToArgb (), "96,32");
				Assert.Equal (-16777216, bmp.GetPixel (96, 64).ToArgb (), "96,64");
				Assert.Equal (-4144960, bmp.GetPixel (96, 96).ToArgb (), "96,96");
				Assert.Equal (-8355840, bmp.GetPixel (96, 128).ToArgb (), "96,128");
				Assert.Equal (-16777216, bmp.GetPixel (96, 160).ToArgb (), "96,160");
				Assert.Equal (-1, bmp.GetPixel (128, 0).ToArgb (), "128,0");
				Assert.Equal (-8355712, bmp.GetPixel (128, 32).ToArgb (), "128,32");
				Assert.Equal (-1, bmp.GetPixel (128, 64).ToArgb (), "128,64");
				Assert.Equal (-4144960, bmp.GetPixel (128, 96).ToArgb (), "128,96");
				Assert.Equal (-16777216, bmp.GetPixel (128, 128).ToArgb (), "128,128");
				Assert.Equal (-4144960, bmp.GetPixel (128, 160).ToArgb (), "128,160");
				Assert.Equal (-4144960, bmp.GetPixel (160, 0).ToArgb (), "160,0");
				Assert.Equal (-1, bmp.GetPixel (160, 32).ToArgb (), "160,32");
				Assert.Equal (-4144960, bmp.GetPixel (160, 64).ToArgb (), "160,64");
				Assert.Equal (-4144960, bmp.GetPixel (160, 96).ToArgb (), "160,96");
				Assert.Equal (-4144960, bmp.GetPixel (160, 128).ToArgb (), "160,128");
				Assert.Equal (-8355712, bmp.GetPixel (160, 160).ToArgb (), "160,160");
#endif
			}
		}

		/* Checks bitmap features on a know 8bbp bitmap */
		[Fact]
		public void Bitmap8bitFeatures ()
		{
			string sInFile = getInFile ("bitmaps/almogaver8bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				GraphicsUnit unit = GraphicsUnit.World;
				RectangleF rect = bmp.GetBounds (ref unit);

				Assert.Equal (PixelFormat.Format8bppIndexed, bmp.PixelFormat);
				Assert.Equal (173, bmp.Width, "bmp.Width");
				Assert.Equal (183, bmp.Height, "bmp.Height");

				Assert.Equal (0, rect.X, "rect.X");
				Assert.Equal (0, rect.Y, "rect.Y");
				Assert.Equal (173, rect.Width, "rect.Width");
				Assert.Equal (183, rect.Height, "rect.Height");

				Assert.Equal (173, bmp.Size.Width, "bmp.Size.Width");
				Assert.Equal (183, bmp.Size.Height, "bmp.Size.Height");
			}
		}

		[Fact]
		public void Bitmap8bitPixels ()
		{
			string sInFile = getInFile ("bitmaps/almogaver8bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
#if false
				for (int x = 0; x < bmp.Width; x += 32) {
					for (int y = 0; y < bmp.Height; y += 32)
						Console.WriteLine ("\t\t\t\tAssert.Equal ({0}, bmp.GetPixel ({1}, {2}).ToArgb (), \"{1},{2}\");", bmp.GetPixel (x, y).ToArgb (), x, y);
				}
#else
				// sampling values from a well known bitmap
				Assert.Equal (-1040, bmp.GetPixel (0, 0).ToArgb (), "0,0");
				Assert.Equal (-4137792, bmp.GetPixel (0, 32).ToArgb (), "0,32");
				Assert.Equal (-1040, bmp.GetPixel (0, 64).ToArgb (), "0,64");
				Assert.Equal (-1040, bmp.GetPixel (0, 96).ToArgb (), "0,96");
				Assert.Equal (-4137792, bmp.GetPixel (0, 128).ToArgb (), "0,128");
				Assert.Equal (-1040, bmp.GetPixel (0, 160).ToArgb (), "0,160");
				Assert.Equal (-4137792, bmp.GetPixel (32, 0).ToArgb (), "32,0");
				Assert.Equal (-4137792, bmp.GetPixel (32, 32).ToArgb (), "32,32");
				Assert.Equal (-1040, bmp.GetPixel (32, 64).ToArgb (), "32,64");
				Assert.Equal (-4144960, bmp.GetPixel (32, 96).ToArgb (), "32,96");
				Assert.Equal (-6250304, bmp.GetPixel (32, 128).ToArgb (), "32,128");
				Assert.Equal (-8355712, bmp.GetPixel (32, 160).ToArgb (), "32,160");
				Assert.Equal (-12566464, bmp.GetPixel (64, 0).ToArgb (), "64,0");
				Assert.Equal (-6258560, bmp.GetPixel (64, 32).ToArgb (), "64,32");
				Assert.Equal (-1040, bmp.GetPixel (64, 64).ToArgb (), "64,64");
				Assert.Equal (-16777216, bmp.GetPixel (64, 96).ToArgb (), "64,96");
				Assert.Equal (-8355776, bmp.GetPixel (64, 128).ToArgb (), "64,128");
				Assert.Equal (-16777216, bmp.GetPixel (64, 160).ToArgb (), "64,160");
				Assert.Equal (-4137792, bmp.GetPixel (96, 0).ToArgb (), "96,0");
				Assert.Equal (-8355712, bmp.GetPixel (96, 32).ToArgb (), "96,32");
				Assert.Equal (-12566464, bmp.GetPixel (96, 64).ToArgb (), "96,64");
				Assert.Equal (-2039680, bmp.GetPixel (96, 96).ToArgb (), "96,96");
				Assert.Equal (-4153280, bmp.GetPixel (96, 128).ToArgb (), "96,128");
				Assert.Equal (-12566464, bmp.GetPixel (96, 160).ToArgb (), "96,160");
				Assert.Equal (-1040, bmp.GetPixel (128, 0).ToArgb (), "128,0");
				Assert.Equal (-6258560, bmp.GetPixel (128, 32).ToArgb (), "128,32");
				Assert.Equal (-1040, bmp.GetPixel (128, 64).ToArgb (), "128,64");
				Assert.Equal (-4144960, bmp.GetPixel (128, 96).ToArgb (), "128,96");
				Assert.Equal (-12566464, bmp.GetPixel (128, 128).ToArgb (), "128,128");
				Assert.Equal (-4144960, bmp.GetPixel (128, 160).ToArgb (), "128,160");
				Assert.Equal (-4137792, bmp.GetPixel (160, 0).ToArgb (), "160,0");
				Assert.Equal (-1040, bmp.GetPixel (160, 32).ToArgb (), "160,32");
				Assert.Equal (-4144960, bmp.GetPixel (160, 64).ToArgb (), "160,64");
				Assert.Equal (-4137792, bmp.GetPixel (160, 96).ToArgb (), "160,96");
				Assert.Equal (-4137792, bmp.GetPixel (160, 128).ToArgb (), "160,128");
				Assert.Equal (-8355712, bmp.GetPixel (160, 160).ToArgb (), "160,160");
#endif
			}
		}


		/* Checks bitmap features on a know 24-bits bitmap */
		[Fact]
		public void Bitmap24bitFeatures()
		{
			string sInFile = getInFile ("bitmaps/almogaver24bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				GraphicsUnit unit = GraphicsUnit.World;
				RectangleF rect = bmp.GetBounds (ref unit);

				Assert.Equal (PixelFormat.Format24bppRgb, bmp.PixelFormat);
				Assert.Equal (173, bmp.Width, "bmp.Width");
				Assert.Equal (183, bmp.Height, "bmp.Height");

				Assert.Equal (0, rect.X, "rect.X");
				Assert.Equal (0, rect.Y, "rect.Y");
				Assert.Equal (173, rect.Width, "rect.Width");
				Assert.Equal (183, rect.Height, "rect.Height");

				Assert.Equal (173, bmp.Size.Width, "bmp.Size.Width");
				Assert.Equal (183, bmp.Size.Height, "bmp.Size.Height");
			}
		}

		[Fact]
		public void Bitmap24bitPixels ()
		{
			string sInFile = getInFile ("bitmaps/almogaver24bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
#if false
				for (int x = 0; x < bmp.Width; x += 32) {
					for (int y = 0; y < bmp.Height; y += 32)
						Console.WriteLine ("\t\t\t\tAssert.Equal ({0}, bmp.GetPixel ({1}, {2}).ToArgb (), \"{1},{2}\");", bmp.GetPixel (x, y).ToArgb (), x, y);
				}
#else
				// sampling values from a well known bitmap
				Assert.Equal (-1645353, bmp.GetPixel (0, 32).ToArgb (), "0,32");
				Assert.Equal (-461332, bmp.GetPixel (0, 64).ToArgb (), "0,64");
				Assert.Equal (-330005, bmp.GetPixel (0, 96).ToArgb (), "0,96");
				Assert.Equal (-2237489, bmp.GetPixel (0, 128).ToArgb (), "0,128");
				Assert.Equal (-1251105, bmp.GetPixel (0, 160).ToArgb (), "0,160");
				Assert.Equal (-3024947, bmp.GetPixel (32, 0).ToArgb (), "32,0");
				Assert.Equal (-2699070, bmp.GetPixel (32, 32).ToArgb (), "32,32");
				Assert.Equal (-2366734, bmp.GetPixel (32, 64).ToArgb (), "32,64");
				Assert.Equal (-4538413, bmp.GetPixel (32, 96).ToArgb (), "32,96");
				Assert.Equal (-6116681, bmp.GetPixel (32, 128).ToArgb (), "32,128");
				Assert.Equal (-7369076, bmp.GetPixel (32, 160).ToArgb (), "32,160");
				Assert.Equal (-13024729, bmp.GetPixel (64, 0).ToArgb (), "64,0");
				Assert.Equal (-7174020, bmp.GetPixel (64, 32).ToArgb (), "64,32");
				Assert.Equal (-51, bmp.GetPixel (64, 64).ToArgb (), "64,64");
				Assert.Equal (-16053503, bmp.GetPixel (64, 96).ToArgb (), "64,96");
				Assert.Equal (-8224431, bmp.GetPixel (64, 128).ToArgb (), "64,128");
				Assert.Equal (-16579326, bmp.GetPixel (64, 160).ToArgb (), "64,160");
				Assert.Equal (-2502457, bmp.GetPixel (96, 0).ToArgb (), "96,0");
				Assert.Equal (-9078395, bmp.GetPixel (96, 32).ToArgb (), "96,32");
				Assert.Equal (-12696508, bmp.GetPixel (96, 64).ToArgb (), "96,64");
				Assert.Equal (-70772, bmp.GetPixel (96, 96).ToArgb (), "96,96");
				Assert.Equal (-4346279, bmp.GetPixel (96, 128).ToArgb (), "96,128");
				Assert.Equal (-11583193, bmp.GetPixel (96, 160).ToArgb (), "96,160");
				Assert.Equal (-724763, bmp.GetPixel (128, 0).ToArgb (), "128,0");
				Assert.Equal (-7238268, bmp.GetPixel (128, 32).ToArgb (), "128,32");
				Assert.Equal (-2169612, bmp.GetPixel (128, 64).ToArgb (), "128,64");
				Assert.Equal (-3683883, bmp.GetPixel (128, 96).ToArgb (), "128,96");
				Assert.Equal (-12892867, bmp.GetPixel (128, 128).ToArgb (), "128,128");
				Assert.Equal (-3750464, bmp.GetPixel (128, 160).ToArgb (), "128,160");
				Assert.Equal (-3222844, bmp.GetPixel (160, 0).ToArgb (), "160,0");
				Assert.Equal (-65806, bmp.GetPixel (160, 32).ToArgb (), "160,32");
				Assert.Equal (-2961726, bmp.GetPixel (160, 64).ToArgb (), "160,64");
				Assert.Equal (-2435382, bmp.GetPixel (160, 96).ToArgb (), "160,96");
				Assert.Equal (-2501944, bmp.GetPixel (160, 128).ToArgb (), "160,128");
				Assert.Equal (-9211799, bmp.GetPixel (160, 160).ToArgb (), "160,160");
#endif
			}
		}

		[Fact]
		public void Bitmap24bitData ()
		{
			string sInFile = getInFile ("bitmaps/almogaver24bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				Assert.Equal (-3355456, bmp.GetPixel (163, 1).ToArgb (), "163,1");
				BitmapData data = bmp.LockBits (new Rectangle (0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
				try {
					Assert.Equal (bmp.Height, data.Height, "Height");
					Assert.Equal (bmp.Width, data.Width, "Width");
					Assert.Equal (PixelFormat.Format24bppRgb, data.PixelFormat, "PixelFormat");
					Assert.Equal (520, data.Stride, "Stride");
					int size = data.Height * data.Stride;
					unsafe {
						byte* scan = (byte*) data.Scan0;
#if false
						// 1009 is the first prime after 1000 (so we're not affected by a recurring pattern)
						for (int p = 0; p < size; p += 1009) {
							Console.WriteLine ("\t\t\t\t\t\tAssert.Equal ({0}, *(scan + {1}), \"{1}\");", *(scan + p), p);
						}
#else
						// sampling values from a well known bitmap
						Assert.Equal (217, *(scan + 0), "0");
						Assert.Equal (192, *(scan + 1009), "1009");
						Assert.Equal (210, *(scan + 2018), "2018");
						Assert.Equal (196, *(scan + 3027), "3027");
						Assert.Equal (216, *(scan + 4036), "4036");
						Assert.Equal (215, *(scan + 5045), "5045");
						Assert.Equal (218, *(scan + 6054), "6054");
						Assert.Equal (218, *(scan + 7063), "7063");
						Assert.Equal (95, *(scan + 8072), "8072");
						Assert.Equal (9, *(scan + 9081), "9081");
						Assert.Equal (247, *(scan + 10090), "10090");
						Assert.Equal (161, *(scan + 11099), "11099");
						Assert.Equal (130, *(scan + 12108), "12108");
						Assert.Equal (131, *(scan + 13117), "13117");
						Assert.Equal (175, *(scan + 14126), "14126");
						Assert.Equal (217, *(scan + 15135), "15135");
						Assert.Equal (201, *(scan + 16144), "16144");
						Assert.Equal (183, *(scan + 17153), "17153");
						Assert.Equal (236, *(scan + 18162), "18162");
						Assert.Equal (242, *(scan + 19171), "19171");
						Assert.Equal (125, *(scan + 20180), "20180");
						Assert.Equal (193, *(scan + 21189), "21189");
						Assert.Equal (227, *(scan + 22198), "22198");
						Assert.Equal (44, *(scan + 23207), "23207");
						Assert.Equal (230, *(scan + 24216), "24216");
						Assert.Equal (224, *(scan + 25225), "25225");
						Assert.Equal (164, *(scan + 26234), "26234");
						Assert.Equal (43, *(scan + 27243), "27243");
						Assert.Equal (200, *(scan + 28252), "28252");
						Assert.Equal (255, *(scan + 29261), "29261");
						Assert.Equal (226, *(scan + 30270), "30270");
						Assert.Equal (230, *(scan + 31279), "31279");
						Assert.Equal (178, *(scan + 32288), "32288");
						Assert.Equal (224, *(scan + 33297), "33297");
						Assert.Equal (233, *(scan + 34306), "34306");
						Assert.Equal (212, *(scan + 35315), "35315");
						Assert.Equal (153, *(scan + 36324), "36324");
						Assert.Equal (143, *(scan + 37333), "37333");
						Assert.Equal (215, *(scan + 38342), "38342");
						Assert.Equal (116, *(scan + 39351), "39351");
						Assert.Equal (26, *(scan + 40360), "40360");
						Assert.Equal (28, *(scan + 41369), "41369");
						Assert.Equal (75, *(scan + 42378), "42378");
						Assert.Equal (50, *(scan + 43387), "43387");
						Assert.Equal (244, *(scan + 44396), "44396");
						Assert.Equal (191, *(scan + 45405), "45405");
						Assert.Equal (200, *(scan + 46414), "46414");
						Assert.Equal (197, *(scan + 47423), "47423");
						Assert.Equal (232, *(scan + 48432), "48432");
						Assert.Equal (186, *(scan + 49441), "49441");
						Assert.Equal (210, *(scan + 50450), "50450");
						Assert.Equal (215, *(scan + 51459), "51459");
						Assert.Equal (155, *(scan + 52468), "52468");
						Assert.Equal (56, *(scan + 53477), "53477");
						Assert.Equal (149, *(scan + 54486), "54486");
						Assert.Equal (137, *(scan + 55495), "55495");
						Assert.Equal (141, *(scan + 56504), "56504");
						Assert.Equal (36, *(scan + 57513), "57513");
						Assert.Equal (39, *(scan + 58522), "58522");
						Assert.Equal (25, *(scan + 59531), "59531");
						Assert.Equal (44, *(scan + 60540), "60540");
						Assert.Equal (12, *(scan + 61549), "61549");
						Assert.Equal (161, *(scan + 62558), "62558");
						Assert.Equal (179, *(scan + 63567), "63567");
						Assert.Equal (181, *(scan + 64576), "64576");
						Assert.Equal (165, *(scan + 65585), "65585");
						Assert.Equal (182, *(scan + 66594), "66594");
						Assert.Equal (186, *(scan + 67603), "67603");
						Assert.Equal (201, *(scan + 68612), "68612");
						Assert.Equal (49, *(scan + 69621), "69621");
						Assert.Equal (161, *(scan + 70630), "70630");
						Assert.Equal (140, *(scan + 71639), "71639");
						Assert.Equal (2, *(scan + 72648), "72648");
						Assert.Equal (15, *(scan + 73657), "73657");
						Assert.Equal (33, *(scan + 74666), "74666");
						Assert.Equal (17, *(scan + 75675), "75675");
						Assert.Equal (0, *(scan + 76684), "76684");
						Assert.Equal (47, *(scan + 77693), "77693");
						Assert.Equal (4, *(scan + 78702), "78702");
						Assert.Equal (142, *(scan + 79711), "79711");
						Assert.Equal (151, *(scan + 80720), "80720");
						Assert.Equal (124, *(scan + 81729), "81729");
						Assert.Equal (81, *(scan + 82738), "82738");
						Assert.Equal (214, *(scan + 83747), "83747");
						Assert.Equal (217, *(scan + 84756), "84756");
						Assert.Equal (30, *(scan + 85765), "85765");
						Assert.Equal (185, *(scan + 86774), "86774");
						Assert.Equal (200, *(scan + 87783), "87783");
						Assert.Equal (37, *(scan + 88792), "88792");
						Assert.Equal (2, *(scan + 89801), "89801");
						Assert.Equal (41, *(scan + 90810), "90810");
						Assert.Equal (16, *(scan + 91819), "91819");
						Assert.Equal (0, *(scan + 92828), "92828");
						Assert.Equal (146, *(scan + 93837), "93837");
						Assert.Equal (163, *(scan + 94846), "94846");
#endif
					}
				}
				finally {
					bmp.UnlockBits (data);
				}
			}
		}

		/* Checks bitmap features on a know 32-bits bitmap (codec)*/
		[Fact]
		public void Bitmap32bitFeatures ()
		{
			string sInFile = getInFile ("bitmaps/almogaver32bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				GraphicsUnit unit = GraphicsUnit.World;
				RectangleF rect = bmp.GetBounds (ref unit);

				Assert.Equal (173, bmp.Width, "bmp.Width");
				Assert.Equal (183, bmp.Height, "bmp.Height");

				Assert.Equal (0, rect.X, "rect.X");
				Assert.Equal (0, rect.Y, "rect.Y");
				Assert.Equal (173, rect.Width, "rect.Width");
				Assert.Equal (183, rect.Height, "rect.Height");

				Assert.Equal (173, bmp.Size.Width, "bmp.Size.Width");
				Assert.Equal (183, bmp.Size.Height, "bmp.Size.Height");
			}
		}

		[Fact]
		public void Bitmap32bitPixels ()
		{
			string sInFile = getInFile ("bitmaps/almogaver32bits.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				Assert.Equal (PixelFormat.Format32bppRgb, bmp.PixelFormat, "PixelFormat");
#if false
				for (int x = 0; x < bmp.Width; x += 32) {
					for (int y = 0; y < bmp.Height; y += 32)
						Console.WriteLine ("\t\t\t\tAssert.Equal ({0}, bmp.GetPixel ({1}, {2}).ToArgb (), \"{1},{2}\");", bmp.GetPixel (x, y).ToArgb (), x, y);
				}
#else
				// sampling values from a well known bitmap
				Assert.Equal (-1579559, bmp.GetPixel (0, 0).ToArgb (), "0,0");
				Assert.Equal (-1645353, bmp.GetPixel (0, 32).ToArgb (), "0,32");
				Assert.Equal (-461332, bmp.GetPixel (0, 64).ToArgb (), "0,64");
				Assert.Equal (-330005, bmp.GetPixel (0, 96).ToArgb (), "0,96");
				Assert.Equal (-2237489, bmp.GetPixel (0, 128).ToArgb (), "0,128");
				Assert.Equal (-1251105, bmp.GetPixel (0, 160).ToArgb (), "0,160");
				Assert.Equal (-3024947, bmp.GetPixel (32, 0).ToArgb (), "32,0");
				Assert.Equal (-2699070, bmp.GetPixel (32, 32).ToArgb (), "32,32");
				Assert.Equal (-2366734, bmp.GetPixel (32, 64).ToArgb (), "32,64");
				Assert.Equal (-4538413, bmp.GetPixel (32, 96).ToArgb (), "32,96");
				Assert.Equal (-6116681, bmp.GetPixel (32, 128).ToArgb (), "32,128");
				Assert.Equal (-7369076, bmp.GetPixel (32, 160).ToArgb (), "32,160");
				Assert.Equal (-13024729, bmp.GetPixel (64, 0).ToArgb (), "64,0");
				Assert.Equal (-7174020, bmp.GetPixel (64, 32).ToArgb (), "64,32");
				Assert.Equal (-51, bmp.GetPixel (64, 64).ToArgb (), "64,64");
				Assert.Equal (-16053503, bmp.GetPixel (64, 96).ToArgb (), "64,96");
				Assert.Equal (-8224431, bmp.GetPixel (64, 128).ToArgb (), "64,128");
				Assert.Equal (-16579326, bmp.GetPixel (64, 160).ToArgb (), "64,160");
				Assert.Equal (-2502457, bmp.GetPixel (96, 0).ToArgb (), "96,0");
				Assert.Equal (-9078395, bmp.GetPixel (96, 32).ToArgb (), "96,32");
				Assert.Equal (-12696508, bmp.GetPixel (96, 64).ToArgb (), "96,64");
				Assert.Equal (-70772, bmp.GetPixel (96, 96).ToArgb (), "96,96");
				Assert.Equal (-4346279, bmp.GetPixel (96, 128).ToArgb (), "96,128");
				Assert.Equal (-11583193, bmp.GetPixel (96, 160).ToArgb (), "96,160");
				Assert.Equal (-724763, bmp.GetPixel (128, 0).ToArgb (), "128,0");
				Assert.Equal (-7238268, bmp.GetPixel (128, 32).ToArgb (), "128,32");
				Assert.Equal (-2169612, bmp.GetPixel (128, 64).ToArgb (), "128,64");
				Assert.Equal (-3683883, bmp.GetPixel (128, 96).ToArgb (), "128,96");
				Assert.Equal (-12892867, bmp.GetPixel (128, 128).ToArgb (), "128,128");
				Assert.Equal (-3750464, bmp.GetPixel (128, 160).ToArgb (), "128,160");
				Assert.Equal (-3222844, bmp.GetPixel (160, 0).ToArgb (), "160,0");
				Assert.Equal (-65806, bmp.GetPixel (160, 32).ToArgb (), "160,32");
				Assert.Equal (-2961726, bmp.GetPixel (160, 64).ToArgb (), "160,64");
				Assert.Equal (-2435382, bmp.GetPixel (160, 96).ToArgb (), "160,96");
				Assert.Equal (-2501944, bmp.GetPixel (160, 128).ToArgb (), "160,128");
				Assert.Equal (-9211799, bmp.GetPixel (160, 160).ToArgb (), "160,160");
#endif
			}
		}

		private void Save (PixelFormat original, PixelFormat expected, bool colorCheck) 
		{				
			string sOutFile = String.Format ("linerect{0}-{1}.bmp", getOutSufix (), expected.ToString ());
						
			// Save		
			Bitmap bmp = new Bitmap (100, 100, original);						
			Graphics gr = Graphics.FromImage (bmp);

			using (Pen p = new Pen (Color.BlueViolet, 2)) {
				gr.DrawLine (p, 10.0F, 10.0F, 90.0F, 90.0F);
				gr.DrawRectangle (p, 10.0F, 10.0F, 80.0F, 80.0F);
			}

			try {
				bmp.Save (sOutFile, ImageFormat.Bmp);

				// Load
				using (Bitmap bmpLoad = new Bitmap (sOutFile)) {
					Assert.Equal (expected, bmpLoad.PixelFormat, "PixelFormat");
					if (colorCheck) {
						Color color = bmpLoad.GetPixel (10, 10);
						Assert.Equal (Color.FromArgb (255, 138, 43, 226), color, "BlueViolet");
					}
				}
			}
			finally {
				gr.Dispose ();
				bmp.Dispose ();
				try {
					File.Delete (sOutFile);
				}
				catch {
				}
			}
		}

		[Fact]
		public void Save_24bppRgb ()
		{
			Save (PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, true);
		}

		[Fact]
		public void Save_32bppRgb ()
		{
			Save (PixelFormat.Format32bppRgb, PixelFormat.Format32bppRgb, true);
		}

		[Fact]
		public void Save_32bppArgb ()
		{
			Save (PixelFormat.Format32bppArgb, PixelFormat.Format32bppRgb, true);
		}

		[Fact]
		public void Save_32bppPArgb ()
		{
			Save (PixelFormat.Format32bppPArgb, PixelFormat.Format32bppRgb, true);
		}

		[Fact]
		public void NonInvertedBitmap ()
		{
			// regression check against http://bugzilla.ximian.com/show_bug.cgi?id=80751
			string sInFile = getInFile ("bitmaps/non-inverted.bmp");
			using (Bitmap bmp = new Bitmap (sInFile)) {
				GraphicsUnit unit = GraphicsUnit.World;
				RectangleF rect = bmp.GetBounds (ref unit);

				Assert.Equal (90, bmp.Width, "bmp.Width");
				Assert.Equal (60, bmp.Height, "bmp.Height");

				Assert.Equal (0, rect.X, "rect.X");
				Assert.Equal (0, rect.Y, "rect.Y");
				Assert.Equal (90, rect.Width, "rect.Width");
				Assert.Equal (60, rect.Height, "rect.Height");

				Assert.Equal (90, bmp.Size.Width, "bmp.Size.Width");
				Assert.Equal (60, bmp.Size.Height, "bmp.Size.Height");

				// sampling values from a well known bitmap
				Assert.Equal (-16777216, bmp.GetPixel (12, 21).ToArgb (), "12,21");
				Assert.Equal (-1, bmp.GetPixel (21, 37).ToArgb (), "21,37");
			}
		}
	}
}

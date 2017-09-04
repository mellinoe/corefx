//
// Icon class testing unit
//
// Authors:
//	Gary Barnett <gary.barnett.mono@gmail.com>
// 	Sanjay Gupta <gsanjay@novell.com>
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004,2006-2008 Novell, Inc (http://www.novell.com)
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using Xunit;

namespace MonoTests.System.Drawing {

	public class IconTest : IDisposable {
		
		Icon icon;
		Icon icon16, icon32, icon48, icon64, icon96;
		FileStream fs1;

		static string filename_dll;

		// static ctor are executed outside the Deny
		static IconTest ()
		{
			filename_dll = Assembly.GetExecutingAssembly ().Location;
		}
		
		public IconTest()		
		{
			String path = TestBitmap.getInFile ("bitmaps/smiley.ico");
			icon = new Icon (path);			
			fs1 = new FileStream (path, FileMode.Open);

			icon16 = new Icon (TestBitmap.getInFile ("bitmaps/16x16x16.ico"));
			icon32 = new Icon (TestBitmap.getInFile ("bitmaps/32x32x16.ico"));
			icon48 = new Icon (TestBitmap.getInFile ("bitmaps/48x48x1.ico"));
			icon64 = new Icon (TestBitmap.getInFile ("bitmaps/64x64x256.ico"));
			icon96 = new Icon (TestBitmap.getInFile ("bitmaps/96x96x256.ico"));
		}

		public void Dispose ()
		{
			if (fs1 != null)
				fs1.Close ();
			if (File.Exists ("newIcon.ico"))
				File.Delete ("newIcon.ico");
		}

		[Fact]
		public void TestConstructors ()
		{
			Assert.Equal (32, icon.Height);
			Assert.Equal (32, icon.Width);

			Icon newIcon = new Icon (fs1, 48, 48);
			Assert.Equal (48, newIcon.Height); 			
			Assert.Equal (48, newIcon.Width);

			newIcon = new Icon (icon, 16, 16);
			Assert.Equal (16, newIcon.Height); 			
			Assert.Equal (16, newIcon.Width);
		}

		[Fact]
		public void Constructor_IconNull_Int_Int ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((Icon)null, 32, 32));
		}

		[Fact]
		public void Constructor_Icon_IntNegative_Int ()
		{
			Icon neg = new Icon (icon, -32, 32);
			Assert.Equal (32, neg.Height);
			Assert.Equal (32, neg.Width);
		}

		[Fact]
		public void Constructor_IconNull_Size ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((Icon) null, new Size (32, 32)));
		}

		[Fact]
		public void Constructor_Icon_Size_Negative ()
		{
			Icon neg = new Icon (icon, new Size (-32, -32));
			Assert.Equal (16, neg.Height);
			Assert.Equal (16, neg.Width);
		}

		[Fact]
		public void Constructor_Icon_Int_Int_NonSquare ()
		{
			Icon non_square = new Icon (icon, 32, 16);
			Assert.Equal (32, non_square.Height);
			Assert.Equal (32, non_square.Width);
		}

		[Fact]
		public void Constructor_Icon_GetNormalSizeFromIconWith256 ()
		{
			string filepath = TestBitmap.getInFile ("bitmaps/323511.ico");

			Icon orig = new Icon (filepath);
			Assert.Equal (32,orig.Height);
			Assert.Equal (32,orig.Width);

			Icon ret = new Icon (orig, 48, 48);
			Assert.Equal (48, ret.Height);
			Assert.Equal (48, ret.Width);
		}

		[Fact]
		public void Constructor_Icon_DoesntReturn256Passing0 ()
		{
			string filepath = TestBitmap.getInFile ("bitmaps/323511.ico");
			
			Icon orig = new Icon (filepath);
			Assert.Equal (32,orig.Height);
			Assert.Equal (32,orig.Width);
			
			Icon ret = new Icon (orig, 0, 0);
			Assert.NotEqual (0, ret.Height);
			Assert.NotEqual (0, ret.Width);
		}

		[Fact]
		public void Constructor_Icon_DoesntReturn256Passing1 ()
		{
			string filepath = TestBitmap.getInFile ("bitmaps/323511.ico");
			
			Icon orig = new Icon (filepath);
			Assert.Equal (32,orig.Height);
			Assert.Equal (32,orig.Width);
			
			Icon ret = new Icon (orig, 1, 1);
			Assert.NotEqual (0, ret.Height);
			Assert.NotEqual (0, ret.Width);
		}

		[Fact]
		public void Constructor_StreamNull ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((Stream) null));
		}

		[Fact]
		public void Constructor_StreamNull_Int_Int ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((Stream) null, 32, 32));
		}

		[Fact]
		public void Constructor_StringNull ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((string) null));
		}

		[Fact]
		public void Constructor_TypeNull_String ()
		{
			Assert.Throws<NullReferenceException> (() => new Icon ((Type) null, "mono.ico"));
		}

		[Fact]
		public void Constructor_Type_StringNull ()
		{
			Assert.Throws<ArgumentException> (() => new Icon (typeof (Icon), null));
		}
		[Fact]
		public void Constructor_StreamNull_Size ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((Stream) null, new Size (32, 32)));
		}

		[Fact]
		public void Constructor_StringNull_Size ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((string) null, new Size (32, 32)));
		}

		[Fact]
		public void Constructor_StringNull_Int_Int ()
		{
			Assert.Throws<ArgumentNullException> (() => new Icon ((string) null, 32, 32));
		}

		[Fact]
		public void TestProperties ()
		{
			Assert.Equal (32, icon.Height);
			Assert.Equal (32, icon.Width);
			Assert.Equal (32, icon.Size.Width);
			Assert.Equal (32, icon.Size.Height);
		}

		[Fact]
		public void Clone ()
		{
			Icon clone = (Icon) icon.Clone ();
			Assert.Equal (32, clone.Height);
			Assert.Equal (32, clone.Width);
			Assert.Equal (32, clone.Size.Width);
			Assert.Equal (32, clone.Size.Height);
		}

		[Fact]
		public void CloneHandleIcon ()
		{
			Icon clone = (Icon) Icon.FromHandle (SystemIcons.Hand.Handle).Clone ();
			Assert.Equal (SystemIcons.Hand.Height, clone.Height);
			Assert.Equal (SystemIcons.Hand.Width, clone.Width);
			Assert.Equal (SystemIcons.Hand.Size.Width, clone.Size.Width);
			Assert.Equal (SystemIcons.Hand.Size.Height, clone.Size.Height);
		}

		private void XPIcon (int size)
		{
			// note: the Icon(string,Size) or Icon(string,int,int) doesn't exists under 1.x
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/32bpp.ico"))) {
				using (Icon xp = new Icon (fs, size, size)) {
					Assert.Equal (size, xp.Height);
					Assert.Equal (size, xp.Width);
					Assert.Equal (size, xp.Size.Width);
					Assert.Equal (size, xp.Size.Height);

					Bitmap bmp = xp.ToBitmap ();
					Assert.Equal (size, bmp.Height);
					Assert.Equal (size, bmp.Width);
					Assert.Equal (size, bmp.Size.Width);
					Assert.Equal (size, bmp.Size.Height);
				}
			}
		}

		[Fact]
		public void Icon32bits_XP16 ()
		{
			XPIcon (16);
		}

		[Fact]
		public void Icon32bits_XP32 ()
		{
			XPIcon (32);
		}

		[Fact]
		public void Icon32bits_XP48 ()
		{
			XPIcon (48);
		}

		[Fact]
		public void SelectFromUnusualSize_Small16 ()
		{
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/80509.ico"))) {
				using (Icon xp = new Icon (fs, 16, 16)) {
					Assert.Equal (16, xp.Height);
					Assert.Equal (10, xp.Width);
					Assert.Equal (10, xp.Size.Width);
					Assert.Equal (16, xp.Size.Height);
				}
			}
		}

		[Fact]
		public void SelectFromUnusualSize_Normal32 ()
		{
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/80509.ico"))) {
				using (Icon xp = new Icon (fs, 32, 32)) {
					Assert.Equal (22, xp.Height);
					Assert.Equal (11, xp.Width);
					Assert.Equal (11, xp.Size.Width);
					Assert.Equal (22, xp.Size.Height);
				}
			}
		}

		internal static void SaveAndCompare (string msg, Icon icon, bool alpha)
		{
			using (MemoryStream ms = new MemoryStream ()) {
				icon.Save (ms);
				ms.Position = 0;

				using (Icon loaded = new Icon (ms)) {
					Assert.Equal (icon.Height, loaded.Height);
					Assert.Equal (icon.Width, loaded.Width);

					using (Bitmap expected = icon.ToBitmap ()) {
						using (Bitmap actual = loaded.ToBitmap ()) {
							Assert.Equal (expected.Height, actual.Height);
							Assert.Equal (expected.Width, actual.Width);

							for (int y = 0; y < expected.Height; y++) {
								for (int x = 0; x < expected.Width; x++) {
									Color e = expected.GetPixel (x, y);
									Color a = actual.GetPixel (x, y);
									if (alpha)
										Assert.Equal (e.A, a.A);
									Assert.Equal (e.R, a.R);
									Assert.Equal (e.G, a.G);
									Assert.Equal (e.B, a.B);
								}
							}
						}
					}
				}
			}
		}

		[Fact]
		public void Save ()
		{
			SaveAndCompare ("16", icon16, true);
			SaveAndCompare ("32", icon32, true);
			SaveAndCompare ("48", icon48, true);
			SaveAndCompare ("64", icon64, true);
			SaveAndCompare ("96", icon96, true);
		}

		[Fact] // bug #410608
		public void Save_256 ()
		{
			string filepath = TestBitmap.getInFile ("bitmaps/323511.ico");

			using (Icon icon = new Icon (filepath)) {
				// bug #415809 fixed
				SaveAndCompare ("256", icon, true);
			}

			// binary comparison
			var orig = new MemoryStream (File.ReadAllBytes (filepath));
			var saved = new MemoryStream ();
			using (Icon icon = new Icon (filepath))
				icon.Save (saved);

            Assert.Equal(orig.ToArray(), saved.ToArray());
		}

		[Fact]
		public void Save_Null ()
		{
			Assert.Throws<NullReferenceException> (() => icon.Save (null));
		}

		[Fact]
		public void Icon16ToBitmap ()
		{
			using (Bitmap b = icon16.ToBitmap ()) {
				Assert.Equal (PixelFormat.Format32bppArgb, b.PixelFormat);
				// unlike the GDI+ icon decoder the palette isn't kept
				Assert.Equal (0, b.Palette.Entries.Length);
				Assert.Equal (icon16.Height, b.Height);
				Assert.Equal (icon16.Width, b.Width);
				Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
				Assert.Equal (2, b.Flags);
			}
		}

		[Fact]
		public void Icon32ToBitmap ()
		{
			using (Bitmap b = icon32.ToBitmap ()) {
				Assert.Equal (PixelFormat.Format32bppArgb, b.PixelFormat);
				// unlike the GDI+ icon decoder the palette isn't kept
				Assert.Equal (0, b.Palette.Entries.Length);
				Assert.Equal (icon32.Height, b.Height);
				Assert.Equal (icon32.Width, b.Width);
				Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
				Assert.Equal (2, b.Flags);
			}
		}

		[Fact]
		public void Icon48ToBitmap ()
		{
			using (Bitmap b = icon48.ToBitmap ()) {
				Assert.Equal (PixelFormat.Format32bppArgb, b.PixelFormat);
				// unlike the GDI+ icon decoder the palette isn't kept
				Assert.Equal (0, b.Palette.Entries.Length);
				Assert.Equal (icon48.Height, b.Height);
				Assert.Equal (icon48.Width, b.Width);
				Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
				Assert.Equal (2, b.Flags);
			}
		}

		[Fact]
		public void Icon64ToBitmap ()
		{
			using (Bitmap b = icon64.ToBitmap ()) {
				Assert.Equal (PixelFormat.Format32bppArgb, b.PixelFormat);
				// unlike the GDI+ icon decoder the palette isn't kept
				Assert.Equal (0, b.Palette.Entries.Length);
				Assert.Equal (icon64.Height, b.Height);
				Assert.Equal (icon64.Width, b.Width);
				Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
				Assert.Equal (2, b.Flags);
			}
		}

		[Fact]
		public void Icon96ToBitmap ()
		{
			using (Bitmap b = icon96.ToBitmap ()) {
				Assert.Equal (PixelFormat.Format32bppArgb, b.PixelFormat);
				// unlike the GDI+ icon decoder the palette isn't kept
				Assert.Equal (0, b.Palette.Entries.Length);
				Assert.Equal (icon96.Height, b.Height);
				Assert.Equal (icon96.Width, b.Width);
				Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
				Assert.Equal (2, b.Flags);
			}
		}

		[Fact] // bug #415581
		public void Icon256ToBitmap ()
		{
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/415581.ico"))) {
				Icon icon = new Icon (fs, 48, 48);
				using (Bitmap b = icon.ToBitmap ()) {
					Assert.Equal (0, b.Palette.Entries.Length);
					Assert.Equal (48, b.Height);
					Assert.Equal (48, b.Width);
					Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
					Assert.Equal (2, b.Flags);
				}
				icon.Dispose ();
			}

			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/415581.ico"))) {
				Icon icon = new Icon (fs, 256, 256);
				using (Bitmap b = icon.ToBitmap ()) {
					Assert.Equal (0, b.Palette.Entries.Length);
					Assert.Equal (48, b.Height);
					Assert.Equal (48, b.Width);
					Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
					Assert.Equal (2, b.Flags);
				}
			}
		}

		[Fact]
		public void Icon256ToBitmap_Request0 ()
		{
			// 415581.ico has 2 images, the 256 and 48
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/415581.ico"))) {
				Icon icon = new Icon (fs, 0, 0);
				using (Bitmap b = icon.ToBitmap ()) {
					Assert.Equal (0, b.Palette.Entries.Length);
					Assert.Equal (48, b.Height);
					Assert.Equal (48, b.Width);
					Assert.True (b.RawFormat.Equals (ImageFormat.MemoryBmp));
					Assert.Equal (2, b.Flags);
				}
			}
		}

		[Fact]
		public void Only256InFile ()
		{
			using (FileStream fs = File.OpenRead (TestBitmap.getInFile ("bitmaps/only256.ico"))) {
				Assert.Throws<Win32Exception> (() => new Icon (fs, 0, 0));
			}
		}


		[Fact]
		public void ExtractAssociatedIcon_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => Icon.ExtractAssociatedIcon (null));
		}

		[Fact]
		public void ExtractAssociatedIcon_Empty ()
		{
			Assert.Throws<ArgumentException> (() => Icon.ExtractAssociatedIcon (String.Empty));
		}

		[Fact]
		public void ExtractAssociatedIcon_DoesNotExists ()
		{
			Assert.Throws<FileNotFoundException> (() => Icon.ExtractAssociatedIcon ("does-not-exists.png"));
		}

		private static bool RunningOnUnix {
			get {
				int p = (int) Environment.OSVersion.Platform;

				return (p == 4) || (p == 6) || (p == 128);
			}
		}
	}

	public class IconFullTrustTest {
		[Fact]
		public void ExtractAssociatedIcon ()
		{
			string filename_dll = Assembly.GetExecutingAssembly ().Location;
			Assert.NotNull (Icon.ExtractAssociatedIcon (filename_dll));
		}

		[Fact]
		public void HandleRoundtrip ()
		{
			IntPtr handle;
			using (Icon icon = new Icon (TestBitmap.getInFile ("bitmaps/16x16x16.ico"))) {
				Assert.Equal (16, icon.Height);
				Assert.Equal (16, icon.Width);
				handle = icon.Handle;
				using (Icon icon2 = Icon.FromHandle (handle)) {
					Assert.Equal (16, icon2.Height);
					Assert.Equal (16, icon2.Width);
					Assert.Equal (handle, icon2.Handle);
					IconTest.SaveAndCompare ("Handle", icon2, false);
				}
			}
			// unlike other cases (HICON, HBITMAP) handle DOESN'T survives original icon disposal
			// commented / using freed memory is risky ;-)
			/*using (Icon icon3 = Icon.FromHandle (handle)) {
				Assert.Equal (0, icon3.Height);
				Assert.Equal (0, icon3.Width);
				Assert.Equal (handle, icon3.Handle);
			}*/
		}

		[Fact]
		public void CreateMultipleIconFromSameHandle ()
		{
			IntPtr handle;
			using (Icon icon = new Icon (TestBitmap.getInFile ("bitmaps/16x16x16.ico"))) {
				Assert.Equal (16, icon.Height);
				Assert.Equal (16, icon.Width);
				handle = icon.Handle;
				using (Icon icon2 = Icon.FromHandle (handle)) {
					Assert.Equal (16, icon2.Height);
					Assert.Equal (16, icon2.Width);
					Assert.Equal (handle, icon2.Handle);
					IconTest.SaveAndCompare ("Handle2", icon2, false);
				}
				using (Icon icon3 = Icon.FromHandle (handle)) {
					Assert.Equal (16, icon3.Height);
					Assert.Equal (16, icon3.Width);
					Assert.Equal (handle, icon3.Handle);
					IconTest.SaveAndCompare ("Handle3", icon3, false);
				}
			}
			// unlike other cases (HICON, HBITMAP) handle DOESN'T survives original icon disposal
			// commented / using freed memory is risky ;-)
		}

		[Fact]
		public void HiconRoundtrip ()
		{
			IntPtr handle;
			using (Icon icon = new Icon (TestBitmap.getInFile ("bitmaps/16x16x16.ico"))) {
				Assert.Equal (16, icon.Height);
				Assert.Equal (16, icon.Width);
				handle = icon.ToBitmap ().GetHicon ();
			}
			// HICON survives
			using (Icon icon2 = Icon.FromHandle (handle)) {
				Assert.Equal (16, icon2.Height);
				Assert.Equal (16, icon2.Width);
				Assert.Equal (handle, icon2.Handle);
				IconTest.SaveAndCompare ("HICON", icon2, false);
			}
		}

		[Fact]
		public void CreateMultipleIconFromSameHICON ()
		{
			IntPtr handle;
			using (Icon icon = new Icon (TestBitmap.getInFile ("bitmaps/16x16x16.ico"))) {
				Assert.Equal (16, icon.Height);
				Assert.Equal (16, icon.Width);
				handle = icon.ToBitmap ().GetHicon ();
			}
			// HICON survives
			using (Icon icon2 = Icon.FromHandle (handle)) {
				Assert.Equal (16, icon2.Height);
				Assert.Equal (16, icon2.Width);
				Assert.Equal (handle, icon2.Handle);
				IconTest.SaveAndCompare ("HICON2", icon2, false);
			}
			using (Icon icon3 = Icon.FromHandle (handle)) {
				Assert.Equal (16, icon3.Height);
				Assert.Equal (16, icon3.Width);
				Assert.Equal (handle, icon3.Handle);
				IconTest.SaveAndCompare ("HICON", icon3, false);
			}
		}
	}
}

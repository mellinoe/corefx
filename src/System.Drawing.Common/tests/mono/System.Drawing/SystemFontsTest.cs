//
// Tests for System.Drawing.SystemFontsTest
//
// Authors:
//	Gert Driesen  <drieseng@users.sourceforge.net>
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2006-2007 Novell, Inc (http://www.novell.com)
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

using Xunit;

namespace MonoTests.System.Drawing {

	[TestFixture]
	public class SystemFontsTest {

		// avoid lots of failures if no fonts are available (e.g. headless systems)
		static bool font_available;

		[TestFixtureSetUp]
		public void FixtureSetUp ()
		{
			try {
				Font f = SystemFonts.DefaultFont;
				font_available = true;
			}
			catch (ArgumentException) {
				font_available = false;
			}
		}

		[SetUp]
		public void SetUp ()
		{
			if (!font_available)
				Assert.Ignore ("No font family could be found.");
		}

		[Fact]
		public void DefaultFont ()
		{
			Font f = SystemFonts.DefaultFont;
			Assert.False (f.Bold, "#1");

			Assert.Equal (true, f.IsSystemFont, "#3");
			Assert.False (f.Italic, "#4");
			Assert.Equal (8.25, f.Size, 0.01, "#6");
			Assert.Equal (8.25, f.SizeInPoints, 0.01, "#7");
			Assert.False (f.Strikeout, "#8");
			Assert.False (f.Underline, "#9");
			Assert.Equal (GraphicsUnit.Point, f.Unit, "#10");
		}

		[Fact]
		[Category ("NotWorking")] // on Unix mapping is done to Bitstream Vera Sans
		public void DefaultFont_Names ()
		{
			Font f = SystemFonts.DefaultFont;
			Assert.Equal ("Microsoft Sans Serif", f.FontFamily.Name, "#1");
			Assert.Equal ("Microsoft Sans Serif", f.Name, "#2");
		}

		[Fact]
		public void SystemFontName ()
		{
			Assert.Equal ("CaptionFont", SystemFonts.CaptionFont.SystemFontName, "CaptionFont");
			Assert.Equal ("DefaultFont", SystemFonts.DefaultFont.SystemFontName, "DefaultFont");
			Assert.Equal ("DialogFont", SystemFonts.DialogFont.SystemFontName, "DialogFont");
			Assert.Equal ("IconTitleFont", SystemFonts.IconTitleFont.SystemFontName, "IconTitleFont");
			Assert.Equal ("MenuFont", SystemFonts.MenuFont.SystemFontName, "MenuFont");
			Assert.Equal ("MessageBoxFont", SystemFonts.MessageBoxFont.SystemFontName, "MessageBoxFont");
			Assert.Equal ("SmallCaptionFont", SystemFonts.SmallCaptionFont.SystemFontName, "SmallCaptionFont");
			Assert.Equal ("StatusFont", SystemFonts.StatusFont.SystemFontName, "StatusFont");
		}

		[Fact]
		public void GetFontByName ()
		{
			Assert.Equal ("CaptionFont", SystemFonts.GetFontByName ("CaptionFont").SystemFontName, "CaptionFont");
			Assert.Equal ("DefaultFont", SystemFonts.GetFontByName ("DefaultFont").SystemFontName, "DefaultFont");
			Assert.Equal ("DialogFont", SystemFonts.GetFontByName ("DialogFont").SystemFontName, "DialogFont");
			Assert.Equal ("IconTitleFont", SystemFonts.GetFontByName ("IconTitleFont").SystemFontName, "IconTitleFont");
			Assert.Equal ("MenuFont", SystemFonts.GetFontByName ("MenuFont").SystemFontName, "MenuFont");
			Assert.Equal ("MessageBoxFont", SystemFonts.GetFontByName ("MessageBoxFont").SystemFontName, "MessageBoxFont");
			Assert.Equal ("SmallCaptionFont", SystemFonts.GetFontByName ("SmallCaptionFont").SystemFontName, "SmallCaptionFont");
			Assert.Equal ("StatusFont", SystemFonts.GetFontByName ("StatusFont").SystemFontName, "StatusFont");
		}

		[Fact]
		public void GetFontByName_Invalid ()
		{
			Assert.Null (SystemFonts.GetFontByName (null), "null");
			Assert.Null (SystemFonts.GetFontByName (String.Empty), "Empty");
			Assert.Null (SystemFonts.GetFontByName ("defaultfont"), "lowercase");
			Assert.Null (SystemFonts.GetFontByName ("DEFAULTFONT"), "UPPERCASE");
		}

		[Fact]
		public void Same ()
		{
			Font f1 = SystemFonts.CaptionFont;
			Font f2 = SystemFonts.CaptionFont;
			Assert.False (Object.ReferenceEquals (f1, f2), "property-property");
			f2 = SystemFonts.GetFontByName ("CaptionFont");
			Assert.False (Object.ReferenceEquals (f1, f2), "property-GetFontByName");
		}

		[Fact]
		public void Dispose_Instance ()
		{
			Font f1 = SystemFonts.CaptionFont;
			float height = f1.GetHeight (72f);
			f1.Dispose ();
			Assert.Throws<ArgumentException> (() => f1.GetHeight (72f));
		}

		[Fact]
		public void Dispose_Property ()
		{
			float height = SystemFonts.CaptionFont.GetHeight (72f);
			SystemFonts.CaptionFont.Dispose ();
			Assert.Equal (height, SystemFonts.CaptionFont.GetHeight (72f), "height");
		}
	}
}


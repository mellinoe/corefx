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

	public class SystemFontsTest {

		[Fact]
		public void DefaultFont ()
		{
			Font f = SystemFonts.DefaultFont;
			Assert.False (f.Bold);

			Assert.Equal (true, f.IsSystemFont);
			Assert.False (f.Italic);
			Assert.Equal (8.25, f.Size, 2);
			Assert.Equal (8.25, f.SizeInPoints, 2);
			Assert.False (f.Strikeout);
			Assert.False (f.Underline);
			Assert.Equal (GraphicsUnit.Point, f.Unit);
		}

		[Fact]
		public void SystemFontName ()
		{
			Assert.Equal ("CaptionFont", SystemFonts.CaptionFont.SystemFontName);
			Assert.Equal ("DefaultFont", SystemFonts.DefaultFont.SystemFontName);
			Assert.Equal ("DialogFont", SystemFonts.DialogFont.SystemFontName);
			Assert.Equal ("IconTitleFont", SystemFonts.IconTitleFont.SystemFontName);
			Assert.Equal ("MenuFont", SystemFonts.MenuFont.SystemFontName);
			Assert.Equal ("MessageBoxFont", SystemFonts.MessageBoxFont.SystemFontName);
			Assert.Equal ("SmallCaptionFont", SystemFonts.SmallCaptionFont.SystemFontName);
			Assert.Equal ("StatusFont", SystemFonts.StatusFont.SystemFontName);
		}

		[Fact]
		public void GetFontByName ()
		{
			Assert.Equal ("CaptionFont", SystemFonts.GetFontByName ("CaptionFont").SystemFontName);
			Assert.Equal ("DefaultFont", SystemFonts.GetFontByName ("DefaultFont").SystemFontName);
			Assert.Equal ("DialogFont", SystemFonts.GetFontByName ("DialogFont").SystemFontName);
			Assert.Equal ("IconTitleFont", SystemFonts.GetFontByName ("IconTitleFont").SystemFontName);
			Assert.Equal ("MenuFont", SystemFonts.GetFontByName ("MenuFont").SystemFontName);
			Assert.Equal ("MessageBoxFont", SystemFonts.GetFontByName ("MessageBoxFont").SystemFontName);
			Assert.Equal ("SmallCaptionFont", SystemFonts.GetFontByName ("SmallCaptionFont").SystemFontName);
			Assert.Equal ("StatusFont", SystemFonts.GetFontByName ("StatusFont").SystemFontName);
		}

		[Fact]
		public void GetFontByName_Invalid ()
		{
			Assert.Null (SystemFonts.GetFontByName (null));
			Assert.Null (SystemFonts.GetFontByName (String.Empty));
			Assert.Null (SystemFonts.GetFontByName ("defaultfont"));
			Assert.Null (SystemFonts.GetFontByName ("DEFAULTFONT"));
		}

		[Fact]
		public void Same ()
		{
			Font f1 = SystemFonts.CaptionFont;
			Font f2 = SystemFonts.CaptionFont;
			Assert.False (Object.ReferenceEquals (f1, f2));
			f2 = SystemFonts.GetFontByName ("CaptionFont");
			Assert.False (Object.ReferenceEquals (f1, f2));
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
			Assert.Equal (height, SystemFonts.CaptionFont.GetHeight (72f));
		}
	}
}


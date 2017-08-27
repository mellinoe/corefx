//
// Tests for System.Drawing.Drawing2D.ColorBlend.cs
//
// Authors:
//	Ravindra (rkumar@novell.com)
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;

namespace MonoTests.System.Drawing.Drawing2D 
{
	[TestFixture]	
	public class ColorBlendTest {

		[Fact]
		public void TestConstructors ()
		{
			ColorBlend cb1 = new ColorBlend (1);
			Assert.Equal (1, cb1.Colors.Length, "Colors");
			Assert.Equal (1, cb1.Positions.Length, "Positions");
		}

		[Fact]
		public void TestProperties () 
		{
			ColorBlend cb1 = new ColorBlend (1);
			float[] positions = {0.0F, 0.5F, 1.0F};
			Color[] colors = {Color.Red, Color.White, Color.Black};
			cb1.Colors = colors;
			cb1.Positions = positions;

			// size match
			Assert.Equal (colors[0], cb1.Colors[0], "c0");
			Assert.Equal (colors[1], cb1.Colors[1], "c1");
			Assert.Equal (colors[2], cb1.Colors[2], "c2");
			Assert.Equal (positions[0], cb1.Positions[0], "p0");
			Assert.Equal (positions[1], cb1.Positions[1], "p1");
			Assert.Equal (positions[2], cb1.Positions[2], "p2");
		}

		[Fact]
		public void ColorBlend_Empty ()
		{
			ColorBlend cb = new ColorBlend ();
			Assert.Equal (1, cb.Colors.Length, "Colors");
			Assert.True (cb.Colors[0].IsEmpty, "C0");
			Assert.Equal (1, cb.Positions.Length, "Positions");
			Assert.Equal (0f, cb.Positions[0], "P0");
		}

		[Fact]
		public void ColorBlend_Zero ()
		{
			ColorBlend cb = new ColorBlend (0);
			Assert.Equal (0, cb.Colors.Length, "Colors");
			Assert.Equal (0, cb.Positions.Length, "Positions");
		}

		[Fact]
		public void MismatchSizes ()
		{
			ColorBlend cb = new ColorBlend ();

			cb.Colors = new Color[16];
			Assert.Equal (16, cb.Colors.Length, "Colors");

			cb.Positions = new float[1];
			Assert.Equal (1, cb.Positions.Length, "Positions");
		}

		[Fact]
		public void ColorBlend_Negative ()
		{
			Assert.Throws<OverflowException> (() => new ColorBlend (-1));
		}

		[Fact]
		public void ColorBlend_Lots ()
		{
			ColorBlend cb = new ColorBlend (1000);
			Assert.Equal (1000, cb.Colors.Length, "Colors");
			Assert.Equal (1000, cb.Positions.Length, "Positions");
		}
	}
}

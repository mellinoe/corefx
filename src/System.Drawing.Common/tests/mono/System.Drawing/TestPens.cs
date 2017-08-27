// Tests for System.Drawing.Pens.cs
//
// Author:
//     Ravindra (rkumar@novell.com)
//

//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
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

namespace MonoTests.System.Drawing
{
	[TestFixture]
	public class PensTest
	{
		[SetUp]
		public void SetUp () { }

		[TearDown]
		public void TearDown () { }
		
		[Fact]
		public void TestEquals ()
		{
			Pen pen1 = Pens.Blue;
			Pen pen2 = Pens.Blue;
			
			Assert.Equal (true, pen1.Equals (pen2),  "Equals");
		}

		[Fact]
		public void TestAliceBlue ()
		{
			Pen pen = Pens.AliceBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P1#1");
			Assert.Equal (pen.Color, Color.AliceBlue, "P1#2");

			try {
				pen.Color = Color.AliceBlue;
				Assert.Fail ("P1#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P1#3");
			}
		}

		[Fact]
		public void TestAntiqueWhite ()
		{
			Pen pen = Pens.AntiqueWhite;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P2#1");
			Assert.Equal (pen.Color, Color.AntiqueWhite, "P2#2");

			try {
				pen.Color = Color.AntiqueWhite;
				Assert.Fail ("P2#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P2#3");
			}
		}

		[Fact]
		public void TestAqua ()
		{
			Pen pen = Pens.Aqua;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P3#1");
			Assert.Equal (pen.Color, Color.Aqua, "P3#2");

			try {
				pen.Color = Color.Aqua;
				Assert.Fail ("P3#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P3#3");
			}
		}

		[Fact]
		public void TestAquamarine ()
		{
			Pen pen = Pens.Aquamarine;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P4#1");
			Assert.Equal (pen.Color, Color.Aquamarine, "P4#2");

			try {
				pen.Color = Color.Aquamarine;
				Assert.Fail ("P4#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P4#3");
			}
		}

		[Fact]
		public void TestAzure ()
		{
			Pen pen = Pens.Azure;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P5#1");
			Assert.Equal (pen.Color, Color.Azure, "P5#2");

			try {
				pen.Color = Color.Azure;
				Assert.Fail ("P5#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P5#3");
			}
		}

		[Fact]
		public void TestBeige ()
		{
			Pen pen = Pens.Beige;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P6#1");
			Assert.Equal (pen.Color, Color.Beige, "P6#2");

			try {
				pen.Color = Color.Beige;
				Assert.Fail ("P6#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P6#3");
			}
		}

		[Fact]
		public void TestBisque ()
		{
			Pen pen = Pens.Bisque;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P7#1");
			Assert.Equal (pen.Color, Color.Bisque, "P7#2");

			try {
				pen.Color = Color.Bisque;
				Assert.Fail ("P7#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P7#3");
			}
		}

		[Fact]
		public void TestBlack ()
		{
			Pen pen = Pens.Black;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P8#1");
			Assert.Equal (pen.Color, Color.Black, "P8#2");

			try {
				pen.Color = Color.Black;
				Assert.Fail ("P8#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P8#3");
			}
		}

		[Fact]
		public void TestBlanchedAlmond ()
		{
			Pen pen = Pens.BlanchedAlmond;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P9#1");
			Assert.Equal (pen.Color, Color.BlanchedAlmond, "P9#2");

			try {
				pen.Color = Color.BlanchedAlmond;
				Assert.Fail ("P9#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P9#3");
			}
		}

		[Fact]
		public void TestBlue ()
		{
			Pen pen = Pens.Blue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P10#1");
			Assert.Equal (pen.Color, Color.Blue, "P10#2");

			try {
				pen.Color = Color.Blue;
				Assert.Fail ("P10#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P10#3");
			}
		}

		[Fact]
		public void TestBlueViolet ()
		{
			Pen pen = Pens.BlueViolet;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P11#1");
			Assert.Equal (pen.Color, Color.BlueViolet, "P11#2");

			try {
				pen.Color = Color.BlueViolet;
				Assert.Fail ("P11#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P11#3");
			}
		}

		[Fact]
		public void TestBrown ()
		{
			Pen pen = Pens.Brown;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P12#1");
			Assert.Equal (pen.Color, Color.Brown, "P12#2");

			try {
				pen.Color = Color.Brown;
				Assert.Fail ("P12#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P12#3");
			}
		}

		[Fact]
		public void TestBurlyWood ()
		{
			Pen pen = Pens.BurlyWood;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P13#1");
			Assert.Equal (pen.Color, Color.BurlyWood, "P13#2");

			try {
				pen.Color = Color.BurlyWood;
				Assert.Fail ("P13#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P13#3");
			}
		}

		[Fact]
		public void TestCadetBlue ()
		{
			Pen pen = Pens.CadetBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P14#1");
			Assert.Equal (pen.Color, Color.CadetBlue, "P14#2");

			try {
				pen.Color = Color.CadetBlue;
				Assert.Fail ("P14#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P14#3");
			}
		}

		[Fact]
		public void TestChartreuse ()
		{
			Pen pen = Pens.Chartreuse;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P15#1");
			Assert.Equal (pen.Color, Color.Chartreuse, "P15#2");

			try {
				pen.Color = Color.Chartreuse;
				Assert.Fail ("P15#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P15#3");
			}
		}

		[Fact]
		public void TestChocolate ()
		{
			Pen pen = Pens.Chocolate;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P16#1");
			Assert.Equal (pen.Color, Color.Chocolate, "P16#2");

			try {
				pen.Color = Color.Chocolate;
				Assert.Fail ("P16#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P16#3");
			}
		}

		[Fact]
		public void TestCoral ()
		{
			Pen pen = Pens.Coral;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P17#1");
			Assert.Equal (pen.Color, Color.Coral, "P17#2");

			try {
				pen.Color = Color.Coral;
				Assert.Fail ("P17#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P17#3");
			}
		}

		[Fact]
		public void TestCornflowerBlue ()
		{
			Pen pen = Pens.CornflowerBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P18#1");
			Assert.Equal (pen.Color, Color.CornflowerBlue, "P18#2");

			try {
				pen.Color = Color.CornflowerBlue;
				Assert.Fail ("P18#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P18#3");
			}
		}

		[Fact]
		public void TestCornsilk ()
		{
			Pen pen = Pens.Cornsilk;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P19#1");
			Assert.Equal (pen.Color, Color.Cornsilk, "P19#2");

			try {
				pen.Color = Color.Cornsilk;
				Assert.Fail ("P19#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P19#3");
			}
		}

		[Fact]
		public void TestCrimson ()
		{
			Pen pen = Pens.Crimson;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P20#1");
			Assert.Equal (pen.Color, Color.Crimson, "P20#2");

			try {
				pen.Color = Color.Crimson;
				Assert.Fail ("P20#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P20#3");
			}
		}

		[Fact]
		public void TestCyan ()
		{
			Pen pen = Pens.Cyan;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P21#1");
			Assert.Equal (pen.Color, Color.Cyan, "P21#2");

			try {
				pen.Color = Color.Cyan;
				Assert.Fail ("P21#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P21#3");
			}
		}

		[Fact]
		public void TestDarkBlue ()
		{
			Pen pen = Pens.DarkBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P22#1");
			Assert.Equal (pen.Color, Color.DarkBlue, "P22#2");

			try {
				pen.Color = Color.DarkBlue;
				Assert.Fail ("P22#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P22#3");
			}
		}

		[Fact]
		public void TestDarkCyan ()
		{
			Pen pen = Pens.DarkCyan;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P23#1");
			Assert.Equal (pen.Color, Color.DarkCyan, "P23#2");

			try {
				pen.Color = Color.DarkCyan;
				Assert.Fail ("P23#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P23#3");
			}
		}

		[Fact]
		public void TestDarkGoldenrod ()
		{
			Pen pen = Pens.DarkGoldenrod;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P24#1");
			Assert.Equal (pen.Color, Color.DarkGoldenrod, "P24#2");

			try {
				pen.Color = Color.DarkGoldenrod;
				Assert.Fail ("P24#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P24#3");
			}
		}

		[Fact]
		public void TestDarkGray ()
		{
			Pen pen = Pens.DarkGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P25#1");
			Assert.Equal (pen.Color, Color.DarkGray, "P25#2");

			try {
				pen.Color = Color.DarkGray;
				Assert.Fail ("P25#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P25#3");
			}
		}

		[Fact]
		public void TestDarkGreen ()
		{
			Pen pen = Pens.DarkGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P26#1");
			Assert.Equal (pen.Color, Color.DarkGreen, "P26#2");

			try {
				pen.Color = Color.DarkGreen;
				Assert.Fail ("P26#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P26#3");
			}
		}

		[Fact]
		public void TestDarkKhaki ()
		{
			Pen pen = Pens.DarkKhaki;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P27#1");
			Assert.Equal (pen.Color, Color.DarkKhaki, "P27#2");

			try {
				pen.Color = Color.DarkKhaki;
				Assert.Fail ("P27#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P27#3");
			}
		}

		[Fact]
		public void TestDarkMagenta ()
		{
			Pen pen = Pens.DarkMagenta;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P28#1");
			Assert.Equal (pen.Color, Color.DarkMagenta, "P28#2");

			try {
				pen.Color = Color.DarkMagenta;
				Assert.Fail ("P28#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P28#3");
			}
		}

		[Fact]
		public void TestDarkOliveGreen ()
		{
			Pen pen = Pens.DarkOliveGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P29#1");
			Assert.Equal (pen.Color, Color.DarkOliveGreen, "P29#2");

			try {
				pen.Color = Color.DarkOliveGreen;
				Assert.Fail ("P29#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P29#3");
			}
		}

		[Fact]
		public void TestDarkOrange ()
		{
			Pen pen = Pens.DarkOrange;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P30#1");
			Assert.Equal (pen.Color, Color.DarkOrange, "P30#2");

			try {
				pen.Color = Color.DarkOrange;
				Assert.Fail ("P30#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P30#3");
			}
		}

		[Fact]
		public void TestDarkOrchid ()
		{
			Pen pen = Pens.DarkOrchid;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P31#1");
			Assert.Equal (pen.Color, Color.DarkOrchid, "P31#2");

			try {
				pen.Color = Color.DarkOrchid;
				Assert.Fail ("P31#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P31#3");
			}
		}

		[Fact]
		public void TestDarkRed ()
		{
			Pen pen = Pens.DarkRed;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P32#1");
			Assert.Equal (pen.Color, Color.DarkRed, "P32#2");

			try {
				pen.Color = Color.DarkRed;
				Assert.Fail ("P32#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P32#3");
			}
		}

		[Fact]
		public void TestDarkSalmon ()
		{
			Pen pen = Pens.DarkSalmon;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P33#1");
			Assert.Equal (pen.Color, Color.DarkSalmon, "P33#2");

			try {
				pen.Color = Color.DarkSalmon;
				Assert.Fail ("P33#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P33#3");
			}
		}

		[Fact]
		public void TestDarkSeaGreen ()
		{
			Pen pen = Pens.DarkSeaGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P34#1");
			Assert.Equal (pen.Color, Color.DarkSeaGreen, "P34#2");

			try {
				pen.Color = Color.DarkSeaGreen;
				Assert.Fail ("P34#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P34#3");
			}
		}

		[Fact]
		public void TestDarkSlateBlue ()
		{
			Pen pen = Pens.DarkSlateBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P35#1");
			Assert.Equal (pen.Color, Color.DarkSlateBlue, "P35#2");

			try {
				pen.Color = Color.DarkSlateBlue;
				Assert.Fail ("P35#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P35#3");
			}
		}

		[Fact]
		public void TestDarkSlateGray ()
		{
			Pen pen = Pens.DarkSlateGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P36#1");
			Assert.Equal (pen.Color, Color.DarkSlateGray, "P36#2");

			try {
				pen.Color = Color.DarkSlateGray;
				Assert.Fail ("P36#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P36#3");
			}
		}

		[Fact]
		public void TestDarkTurquoise ()
		{
			Pen pen = Pens.DarkTurquoise;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P37#1");
			Assert.Equal (pen.Color, Color.DarkTurquoise, "P37#2");

			try {
				pen.Color = Color.DarkTurquoise;
				Assert.Fail ("P37#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P37#3");
			}
		}

		[Fact]
		public void TestDarkViolet ()
		{
			Pen pen = Pens.DarkViolet;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P38#1");
			Assert.Equal (pen.Color, Color.DarkViolet, "P38#2");

			try {
				pen.Color = Color.DarkViolet;
				Assert.Fail ("P38#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P38#3");
			}
		}

		[Fact]
		public void TestDeepPink ()
		{
			Pen pen = Pens.DeepPink;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P39#1");
			Assert.Equal (pen.Color, Color.DeepPink, "P39#2");

			try {
				pen.Color = Color.DeepPink;
				Assert.Fail ("P39#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P39#3");
			}
		}

		[Fact]
		public void TestDeepSkyBlue ()
		{
			Pen pen = Pens.DeepSkyBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P40#1");
			Assert.Equal (pen.Color, Color.DeepSkyBlue, "P40#2");

			try {
				pen.Color = Color.DeepSkyBlue;
				Assert.Fail ("P40#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P40#3");
			}
		}

		[Fact]
		public void TestDimGray ()
		{
			Pen pen = Pens.DimGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P41#1");
			Assert.Equal (pen.Color, Color.DimGray, "P41#2");

			try {
				pen.Color = Color.DimGray;
				Assert.Fail ("P41#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P41#3");
			}
		}

		[Fact]
		public void TestDodgerBlue ()
		{
			Pen pen = Pens.DodgerBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P42#1");
			Assert.Equal (pen.Color, Color.DodgerBlue, "P42#2");

			try {
				pen.Color = Color.DodgerBlue;
				Assert.Fail ("P42#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P42#3");
			}
		}

		[Fact]
		public void TestFirebrick ()
		{
			Pen pen = Pens.Firebrick;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P43#1");
			Assert.Equal (pen.Color, Color.Firebrick, "P43#2");

			try {
				pen.Color = Color.Firebrick;
				Assert.Fail ("P43#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P43#3");
			}
		}

		[Fact]
		public void TestFloralWhite ()
		{
			Pen pen = Pens.FloralWhite;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P44#1");
			Assert.Equal (pen.Color, Color.FloralWhite, "P44#2");

			try {
				pen.Color = Color.FloralWhite;
				Assert.Fail ("P44#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P44#3");
			}
		}

		[Fact]
		public void TestForestGreen ()
		{
			Pen pen = Pens.ForestGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P45#1");
			Assert.Equal (pen.Color, Color.ForestGreen, "P45#2");

			try {
				pen.Color = Color.ForestGreen;
				Assert.Fail ("P45#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P45#3");
			}
		}

		[Fact]
		public void TestFuchsia ()
		{
			Pen pen = Pens.Fuchsia;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P46#1");
			Assert.Equal (pen.Color, Color.Fuchsia, "P46#2");

			try {
				pen.Color = Color.Fuchsia;
				Assert.Fail ("P46#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P46#3");
			}
		}

		[Fact]
		public void TestGainsboro ()
		{
			Pen pen = Pens.Gainsboro;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P47#1");
			Assert.Equal (pen.Color, Color.Gainsboro, "P47#2");

			try {
				pen.Color = Color.Gainsboro;
				Assert.Fail ("P47#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P47#3");
			}
		}

		[Fact]
		public void TestGhostWhite ()
		{
			Pen pen = Pens.GhostWhite;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P48#1");
			Assert.Equal (pen.Color, Color.GhostWhite, "P48#2");

			try {
				pen.Color = Color.GhostWhite;
				Assert.Fail ("P48#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P48#3");
			}
		}

		[Fact]
		public void TestGold ()
		{
			Pen pen = Pens.Gold;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P49#1");
			Assert.Equal (pen.Color, Color.Gold, "P49#2");

			try {
				pen.Color = Color.Gold;
				Assert.Fail ("P49#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P49#3");
			}
		}

		[Fact]
		public void TestGoldenrod ()
		{
			Pen pen = Pens.Goldenrod;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P50#1");
			Assert.Equal (pen.Color, Color.Goldenrod, "P50#2");

			try {
				pen.Color = Color.Goldenrod;
				Assert.Fail ("P50#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P50#3");
			}
		}

		[Fact]
		public void TestGray ()
		{
			Pen pen = Pens.Gray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P51#1");
			Assert.Equal (pen.Color, Color.Gray, "P51#2");

			try {
				pen.Color = Color.Gray;
				Assert.Fail ("P51#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P51#3");
			}
		}

		[Fact]
		public void TestGreen ()
		{
			Pen pen = Pens.Green;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P52#1");
			Assert.Equal (pen.Color, Color.Green, "P52#2");

			try {
				pen.Color = Color.Green;
				Assert.Fail ("P52#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P52#3");
			}
		}

		[Fact]
		public void TestGreenYellow ()
		{
			Pen pen = Pens.GreenYellow;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P53#1");
			Assert.Equal (pen.Color, Color.GreenYellow, "P53#2");

			try {
				pen.Color = Color.GreenYellow;
				Assert.Fail ("P53#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P53#3");
			}
		}

		[Fact]
		public void TestHoneydew ()
		{
			Pen pen = Pens.Honeydew;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P54#1");
			Assert.Equal (pen.Color, Color.Honeydew, "P54#2");

			try {
				pen.Color = Color.Honeydew;
				Assert.Fail ("P54#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P54#3");
			}
		}

		[Fact]
		public void TestHotPink ()
		{
			Pen pen = Pens.HotPink;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P55#1");
			Assert.Equal (pen.Color, Color.HotPink, "P55#2");

			try {
				pen.Color = Color.HotPink;
				Assert.Fail ("P55#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P55#3");
			}
		}

		[Fact]
		public void TestIndianRed ()
		{
			Pen pen = Pens.IndianRed;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P56#1");
			Assert.Equal (pen.Color, Color.IndianRed, "P56#2");

			try {
				pen.Color = Color.IndianRed;
				Assert.Fail ("P56#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P56#3");
			}
		}

		[Fact]
		public void TestIndigo ()
		{
			Pen pen = Pens.Indigo;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P57#1");
			Assert.Equal (pen.Color, Color.Indigo, "P57#2");

			try {
				pen.Color = Color.Indigo;
				Assert.Fail ("P57#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P57#3");
			}
		}

		[Fact]
		public void TestIvory ()
		{
			Pen pen = Pens.Ivory;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P58#1");
			Assert.Equal (pen.Color, Color.Ivory, "P58#2");

			try {
				pen.Color = Color.Ivory;
				Assert.Fail ("P58#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P58#3");
			}
		}

		[Fact]
		public void TestKhaki ()
		{
			Pen pen = Pens.Khaki;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P59#1");
			Assert.Equal (pen.Color, Color.Khaki, "P59#2");

			try {
				pen.Color = Color.Khaki;
				Assert.Fail ("P59#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P59#3");
			}
		}

		[Fact]
		public void TestLavender ()
		{
			Pen pen = Pens.Lavender;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P60#1");
			Assert.Equal (pen.Color, Color.Lavender, "P60#2");

			try {
				pen.Color = Color.Lavender;
				Assert.Fail ("P60#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P60#3");
			}
		}

		[Fact]
		public void TestLavenderBlush ()
		{
			Pen pen = Pens.LavenderBlush;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P61#1");
			Assert.Equal (pen.Color, Color.LavenderBlush, "P61#2");

			try {
				pen.Color = Color.LavenderBlush;
				Assert.Fail ("P61#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P61#3");
			}
		}

		[Fact]
		public void TestLawnGreen ()
		{
			Pen pen = Pens.LawnGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P62#1");
			Assert.Equal (pen.Color, Color.LawnGreen, "P62#2");

			try {
				pen.Color = Color.LawnGreen;
				Assert.Fail ("P62#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P62#3");
			}
		}

		[Fact]
		public void TestLemonChiffon ()
		{
			Pen pen = Pens.LemonChiffon;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P63#1");
			Assert.Equal (pen.Color, Color.LemonChiffon, "P63#2");

			try {
				pen.Color = Color.LemonChiffon;
				Assert.Fail ("P63#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P63#3");
			}
		}

		[Fact]
		public void TestLightBlue ()
		{
			Pen pen = Pens.LightBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P64#1");
			Assert.Equal (pen.Color, Color.LightBlue, "P64#2");

			try {
				pen.Color = Color.LightBlue;
				Assert.Fail ("P64#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P64#3");
			}
		}

		[Fact]
		public void TestLightCoral ()
		{
			Pen pen = Pens.LightCoral;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P65#1");
			Assert.Equal (pen.Color, Color.LightCoral, "P65#2");

			try {
				pen.Color = Color.LightCoral;
				Assert.Fail ("P65#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P65#3");
			}
		}

		[Fact]
		public void TestLightCyan ()
		{
			Pen pen = Pens.LightCyan;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P66#1");
			Assert.Equal (pen.Color, Color.LightCyan, "P66#2");

			try {
				pen.Color = Color.LightCyan;
				Assert.Fail ("P66#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P66#3");
			}
		}

		[Fact]
		public void TestLightGoldenrodYellow ()
		{
			Pen pen = Pens.LightGoldenrodYellow;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P67#1");
			Assert.Equal (pen.Color, Color.LightGoldenrodYellow, "P67#2");

			try {
				pen.Color = Color.LightGoldenrodYellow;
				Assert.Fail ("P67#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P67#3");
			}
		}

		[Fact]
		public void TestLightGray ()
		{
			Pen pen = Pens.LightGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P68#1");
			Assert.Equal (pen.Color, Color.LightGray, "P68#2");

			try {
				pen.Color = Color.LightGray;
				Assert.Fail ("P68#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P68#3");
			}
		}

		[Fact]
		public void TestLightGreen ()
		{
			Pen pen = Pens.LightGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P69#1");
			Assert.Equal (pen.Color, Color.LightGreen, "P69#2");

			try {
				pen.Color = Color.LightGreen;
				Assert.Fail ("P69#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P69#3");
			}
		}

		[Fact]
		public void TestLightPink ()
		{
			Pen pen = Pens.LightPink;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P70#1");
			Assert.Equal (pen.Color, Color.LightPink, "P70#2");

			try {
				pen.Color = Color.LightPink;
				Assert.Fail ("P70#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P70#3");
			}
		}

		[Fact]
		public void TestLightSalmon ()
		{
			Pen pen = Pens.LightSalmon;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P71#1");
			Assert.Equal (pen.Color, Color.LightSalmon, "P71#2");

			try {
				pen.Color = Color.LightSalmon;
				Assert.Fail ("P71#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P71#3");
			}
		}

		[Fact]
		public void TestLightSeaGreen ()
		{
			Pen pen = Pens.LightSeaGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P72#1");
			Assert.Equal (pen.Color, Color.LightSeaGreen, "P72#2");

			try {
				pen.Color = Color.LightSeaGreen;
				Assert.Fail ("P72#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P72#3");
			}
		}

		[Fact]
		public void TestLightSkyBlue ()
		{
			Pen pen = Pens.LightSkyBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P73#1");
			Assert.Equal (pen.Color, Color.LightSkyBlue, "P73#2");

			try {
				pen.Color = Color.LightSkyBlue;
				Assert.Fail ("P73#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P73#3");
			}
		}

		[Fact]
		public void TestLightSlateGray ()
		{
			Pen pen = Pens.LightSlateGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P74#1");
			Assert.Equal (pen.Color, Color.LightSlateGray, "P74#2");

			try {
				pen.Color = Color.LightSlateGray;
				Assert.Fail ("P74#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P74#3");
			}
		}

		[Fact]
		public void TestLightSteelBlue ()
		{
			Pen pen = Pens.LightSteelBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P75#1");
			Assert.Equal (pen.Color, Color.LightSteelBlue, "P75#2");

			try {
				pen.Color = Color.LightSteelBlue;
				Assert.Fail ("P75#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P75#3");
			}
		}

		[Fact]
		public void TestLightYellow ()
		{
			Pen pen = Pens.LightYellow;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P76#1");
			Assert.Equal (pen.Color, Color.LightYellow, "P76#2");

			try {
				pen.Color = Color.LightYellow;
				Assert.Fail ("P76#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P76#3");
			}
		}

		[Fact]
		public void TestLime ()
		{
			Pen pen = Pens.Lime;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P77#1");
			Assert.Equal (pen.Color, Color.Lime, "P77#2");

			try {
				pen.Color = Color.Lime;
				Assert.Fail ("P77#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P77#3");
			}
		}

		[Fact]
		public void TestLimeGreen ()
		{
			Pen pen = Pens.LimeGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P78#1");
			Assert.Equal (pen.Color, Color.LimeGreen, "P78#2");

			try {
				pen.Color = Color.LimeGreen;
				Assert.Fail ("P78#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P78#3");
			}
		}

		[Fact]
		public void TestLinen ()
		{
			Pen pen = Pens.Linen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P79#1");
			Assert.Equal (pen.Color, Color.Linen, "P79#2");

			try {
				pen.Color = Color.Linen;
				Assert.Fail ("P79#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P79#3");
			}
		}

		[Fact]
		public void TestMagenta ()
		{
			Pen pen = Pens.Magenta;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P80#1");
			Assert.Equal (pen.Color, Color.Magenta, "P80#2");

			try {
				pen.Color = Color.Magenta;
				Assert.Fail ("P80#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P80#3");
			}
		}

		[Fact]
		public void TestMaroon ()
		{
			Pen pen = Pens.Maroon;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P81#1");
			Assert.Equal (pen.Color, Color.Maroon, "P81#2");

			try {
				pen.Color = Color.Maroon;
				Assert.Fail ("P81#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P81#3");
			}
		}

		[Fact]
		public void TestMediumAquamarine ()
		{
			Pen pen = Pens.MediumAquamarine;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P82#1");
			Assert.Equal (pen.Color, Color.MediumAquamarine, "P82#2");

			try {
				pen.Color = Color.MediumAquamarine;
				Assert.Fail ("P82#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P82#3");
			}
		}

		[Fact]
		public void TestMediumBlue ()
		{
			Pen pen = Pens.MediumBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P83#1");
			Assert.Equal (pen.Color, Color.MediumBlue, "P83#2");

			try {
				pen.Color = Color.MediumBlue;
				Assert.Fail ("P83#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P83#3");
			}
		}

		[Fact]
		public void TestMediumOrchid ()
		{
			Pen pen = Pens.MediumOrchid;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P84#1");
			Assert.Equal (pen.Color, Color.MediumOrchid, "P84#2");

			try {
				pen.Color = Color.MediumOrchid;
				Assert.Fail ("P84#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P84#3");
			}
		}

		[Fact]
		public void TestMediumPurple ()
		{
			Pen pen = Pens.MediumPurple;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P85#1");
			Assert.Equal (pen.Color, Color.MediumPurple, "P85#2");

			try {
				pen.Color = Color.MediumPurple;
				Assert.Fail ("P85#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P85#3");
			}
		}

		[Fact]
		public void TestMediumSeaGreen ()
		{
			Pen pen = Pens.MediumSeaGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P86#1");
			Assert.Equal (pen.Color, Color.MediumSeaGreen, "P86#2");

			try {
				pen.Color = Color.MediumSeaGreen;
				Assert.Fail ("P86#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P86#3");
			}
		}

		[Fact]
		public void TestMediumSlateBlue ()
		{
			Pen pen = Pens.MediumSlateBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P87#1");
			Assert.Equal (pen.Color, Color.MediumSlateBlue, "P87#2");

			try {
				pen.Color = Color.MediumSlateBlue;
				Assert.Fail ("P87#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P87#3");
			}
		}

		[Fact]
		public void TestMediumSpringGreen ()
		{
			Pen pen = Pens.MediumSpringGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P88#1");
			Assert.Equal (pen.Color, Color.MediumSpringGreen, "P88#2");

			try {
				pen.Color = Color.MediumSpringGreen;
				Assert.Fail ("P88#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P88#3");
			}
		}

		[Fact]
		public void TestMediumTurquoise ()
		{
			Pen pen = Pens.MediumTurquoise;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P89#1");
			Assert.Equal (pen.Color, Color.MediumTurquoise, "P89#2");

			try {
				pen.Color = Color.MediumTurquoise;
				Assert.Fail ("P89#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P89#3");
			}
		}

		[Fact]
		public void TestMediumVioletRed ()
		{
			Pen pen = Pens.MediumVioletRed;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P90#1");
			Assert.Equal (pen.Color, Color.MediumVioletRed, "P90#2");

			try {
				pen.Color = Color.MediumVioletRed;
				Assert.Fail ("P90#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P90#3");
			}
		}

		[Fact]
		public void TestMidnightBlue ()
		{
			Pen pen = Pens.MidnightBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P91#1");
			Assert.Equal (pen.Color, Color.MidnightBlue, "P91#2");

			try {
				pen.Color = Color.MidnightBlue;
				Assert.Fail ("P91#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P91#3");
			}
		}

		[Fact]
		public void TestMintCream ()
		{
			Pen pen = Pens.MintCream;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P92#1");
			Assert.Equal (pen.Color, Color.MintCream, "P92#2");

			try {
				pen.Color = Color.MintCream;
				Assert.Fail ("P92#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P92#3");
			}
		}

		[Fact]
		public void TestMistyRose ()
		{
			Pen pen = Pens.MistyRose;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P93#1");
			Assert.Equal (pen.Color, Color.MistyRose, "P93#2");

			try {
				pen.Color = Color.MistyRose;
				Assert.Fail ("P93#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P93#3");
			}
		}

		[Fact]
		public void TestMoccasin ()
		{
			Pen pen = Pens.Moccasin;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P94#1");
			Assert.Equal (pen.Color, Color.Moccasin, "P94#2");

			try {
				pen.Color = Color.Moccasin;
				Assert.Fail ("P94#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P94#3");
			}
		}

		[Fact]
		public void TestNavajoWhite ()
		{
			Pen pen = Pens.NavajoWhite;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P95#1");
			Assert.Equal (pen.Color, Color.NavajoWhite, "P95#2");

			try {
				pen.Color = Color.NavajoWhite;
				Assert.Fail ("P95#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P95#3");
			}
		}

		[Fact]
		public void TestNavy ()
		{
			Pen pen = Pens.Navy;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P96#1");
			Assert.Equal (pen.Color, Color.Navy, "P96#2");

			try {
				pen.Color = Color.Navy;
				Assert.Fail ("P96#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P96#3");
			}
		}

		[Fact]
		public void TestOldLace ()
		{
			Pen pen = Pens.OldLace;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P97#1");
			Assert.Equal (pen.Color, Color.OldLace, "P97#2");

			try {
				pen.Color = Color.OldLace;
				Assert.Fail ("P97#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P97#3");
			}
		}

		[Fact]
		public void TestOlive ()
		{
			Pen pen = Pens.Olive;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P98#1");
			Assert.Equal (pen.Color, Color.Olive, "P98#2");

			try {
				pen.Color = Color.Olive;
				Assert.Fail ("P98#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P98#3");
			}
		}

		[Fact]
		public void TestOliveDrab ()
		{
			Pen pen = Pens.OliveDrab;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P99#1");
			Assert.Equal (pen.Color, Color.OliveDrab, "P99#2");

			try {
				pen.Color = Color.OliveDrab;
				Assert.Fail ("P99#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P99#3");
			}
		}

		[Fact]
		public void TestOrange ()
		{
			Pen pen = Pens.Orange;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P100#1");
			Assert.Equal (pen.Color, Color.Orange, "P100#2");

			try {
				pen.Color = Color.Orange;
				Assert.Fail ("P100#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P100#3");
			}
		}

		[Fact]
		public void TestOrangeRed ()
		{
			Pen pen = Pens.OrangeRed;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P101#1");
			Assert.Equal (pen.Color, Color.OrangeRed, "P101#2");

			try {
				pen.Color = Color.OrangeRed;
				Assert.Fail ("P101#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P101#3");
			}
		}

		[Fact]
		public void TestOrchid ()
		{
			Pen pen = Pens.Orchid;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P102#1");
			Assert.Equal (pen.Color, Color.Orchid, "P102#2");

			try {
				pen.Color = Color.Orchid;
				Assert.Fail ("P102#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P102#3");
			}
		}

		[Fact]
		public void TestPaleGoldenrod ()
		{
			Pen pen = Pens.PaleGoldenrod;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P103#1");
			Assert.Equal (pen.Color, Color.PaleGoldenrod, "P103#2");

			try {
				pen.Color = Color.PaleGoldenrod;
				Assert.Fail ("P103#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P103#3");
			}
		}

		[Fact]
		public void TestPaleGreen ()
		{
			Pen pen = Pens.PaleGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P104#1");
			Assert.Equal (pen.Color, Color.PaleGreen, "P104#2");

			try {
				pen.Color = Color.PaleGreen;
				Assert.Fail ("P104#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P104#3");
			}
		}

		[Fact]
		public void TestPaleTurquoise ()
		{
			Pen pen = Pens.PaleTurquoise;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P105#1");
			Assert.Equal (pen.Color, Color.PaleTurquoise, "P105#2");

			try {
				pen.Color = Color.PaleTurquoise;
				Assert.Fail ("P105#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P105#3");
			}
		}

		[Fact]
		public void TestPaleVioletRed ()
		{
			Pen pen = Pens.PaleVioletRed;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P106#1");
			Assert.Equal (pen.Color, Color.PaleVioletRed, "P106#2");

			try {
				pen.Color = Color.PaleVioletRed;
				Assert.Fail ("P106#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P106#3");
			}
		}

		[Fact]
		public void TestPapayaWhip ()
		{
			Pen pen = Pens.PapayaWhip;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P107#1");
			Assert.Equal (pen.Color, Color.PapayaWhip, "P107#2");

			try {
				pen.Color = Color.PapayaWhip;
				Assert.Fail ("P107#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P107#3");
			}
		}

		[Fact]
		public void TestPeachPuff ()
		{
			Pen pen = Pens.PeachPuff;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P108#1");
			Assert.Equal (pen.Color, Color.PeachPuff, "P108#2");

			try {
				pen.Color = Color.PeachPuff;
				Assert.Fail ("P108#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P108#3");
			}
		}

		[Fact]
		public void TestPeru ()
		{
			Pen pen = Pens.Peru;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P109#1");
			Assert.Equal (pen.Color, Color.Peru, "P109#2");

			try {
				pen.Color = Color.Peru;
				Assert.Fail ("P109#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P109#3");
			}
		}

		[Fact]
		public void TestPink ()
		{
			Pen pen = Pens.Pink;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P110#1");
			Assert.Equal (pen.Color, Color.Pink, "P110#2");

			try {
				pen.Color = Color.Pink;
				Assert.Fail ("P110#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P110#3");
			}
		}

		[Fact]
		public void TestPlum ()
		{
			Pen pen = Pens.Plum;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P111#1");
			Assert.Equal (pen.Color, Color.Plum, "P111#2");

			try {
				pen.Color = Color.Plum;
				Assert.Fail ("P111#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P111#3");
			}
		}

		[Fact]
		public void TestPowderBlue ()
		{
			Pen pen = Pens.PowderBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P112#1");
			Assert.Equal (pen.Color, Color.PowderBlue, "P112#2");

			try {
				pen.Color = Color.PowderBlue;
				Assert.Fail ("P112#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P112#3");
			}
		}

		[Fact]
		public void TestPurple ()
		{
			Pen pen = Pens.Purple;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P113#1");
			Assert.Equal (pen.Color, Color.Purple, "P113#2");

			try {
				pen.Color = Color.Purple;
				Assert.Fail ("P113#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P113#3");
			}
		}

		[Fact]
		public void TestRed ()
		{
			Pen pen = Pens.Red;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P114#1");
			Assert.Equal (pen.Color, Color.Red, "P114#2");

			try {
				pen.Color = Color.Red;
				Assert.Fail ("P114#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P114#3");
			}
		}

		[Fact]
		public void TestRosyBrown ()
		{
			Pen pen = Pens.RosyBrown;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P115#1");
			Assert.Equal (pen.Color, Color.RosyBrown, "P115#2");

			try {
				pen.Color = Color.RosyBrown;
				Assert.Fail ("P115#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P115#3");
			}
		}

		[Fact]
		public void TestRoyalBlue ()
		{
			Pen pen = Pens.RoyalBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P116#1");
			Assert.Equal (pen.Color, Color.RoyalBlue, "P116#2");

			try {
				pen.Color = Color.RoyalBlue;
				Assert.Fail ("P116#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P116#3");
			}
		}

		[Fact]
		public void TestSaddleBrown ()
		{
			Pen pen = Pens.SaddleBrown;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P117#1");
			Assert.Equal (pen.Color, Color.SaddleBrown, "P117#2");

			try {
				pen.Color = Color.SaddleBrown;
				Assert.Fail ("P117#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P117#3");
			}
		}

		[Fact]
		public void TestSalmon ()
		{
			Pen pen = Pens.Salmon;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P118#1");
			Assert.Equal (pen.Color, Color.Salmon, "P118#2");

			try {
				pen.Color = Color.Salmon;
				Assert.Fail ("P118#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P118#3");
			}
		}

		[Fact]
		public void TestSandyBrown ()
		{
			Pen pen = Pens.SandyBrown;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P119#1");
			Assert.Equal (pen.Color, Color.SandyBrown, "P119#2");

			try {
				pen.Color = Color.SandyBrown;
				Assert.Fail ("P119#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P119#3");
			}
		}

		[Fact]
		public void TestSeaGreen ()
		{
			Pen pen = Pens.SeaGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P120#1");
			Assert.Equal (pen.Color, Color.SeaGreen, "P120#2");

			try {
				pen.Color = Color.SeaGreen;
				Assert.Fail ("P120#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P120#3");
			}
		}

		[Fact]
		public void TestSeaShell ()
		{
			Pen pen = Pens.SeaShell;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P121#1");
			Assert.Equal (pen.Color, Color.SeaShell, "P121#2");

			try {
				pen.Color = Color.SeaShell;
				Assert.Fail ("P121#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P121#3");
			}
		}

		[Fact]
		public void TestSienna ()
		{
			Pen pen = Pens.Sienna;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P122#1");
			Assert.Equal (pen.Color, Color.Sienna, "P122#2");

			try {
				pen.Color = Color.Sienna;
				Assert.Fail ("P122#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P122#3");
			}
		}

		[Fact]
		public void TestSilver ()
		{
			Pen pen = Pens.Silver;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P123#1");
			Assert.Equal (pen.Color, Color.Silver, "P123#2");

			try {
				pen.Color = Color.Silver;
				Assert.Fail ("P123#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P123#3");
			}
		}

		[Fact]
		public void TestSkyBlue ()
		{
			Pen pen = Pens.SkyBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P124#1");
			Assert.Equal (pen.Color, Color.SkyBlue, "P124#2");

			try {
				pen.Color = Color.SkyBlue;
				Assert.Fail ("P124#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P124#3");
			}
		}

		[Fact]
		public void TestSlateBlue ()
		{
			Pen pen = Pens.SlateBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P125#1");
			Assert.Equal (pen.Color, Color.SlateBlue, "P125#2");

			try {
				pen.Color = Color.SlateBlue;
				Assert.Fail ("P125#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P125#3");
			}
		}

		[Fact]
		public void TestSlateGray ()
		{
			Pen pen = Pens.SlateGray;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P126#1");
			Assert.Equal (pen.Color, Color.SlateGray, "P126#2");

			try {
				pen.Color = Color.SlateGray;
				Assert.Fail ("P126#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P126#3");
			}
		}

		[Fact]
		public void TestSnow ()
		{
			Pen pen = Pens.Snow;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P127#1");
			Assert.Equal (pen.Color, Color.Snow, "P127#2");

			try {
				pen.Color = Color.Snow;
				Assert.Fail ("P127#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P127#3");
			}
		}

		[Fact]
		public void TestSpringGreen ()
		{
			Pen pen = Pens.SpringGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P128#1");
			Assert.Equal (pen.Color, Color.SpringGreen, "P128#2");

			try {
				pen.Color = Color.SpringGreen;
				Assert.Fail ("P128#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P128#3");
			}
		}

		[Fact]
		public void TestSteelBlue ()
		{
			Pen pen = Pens.SteelBlue;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P129#1");
			Assert.Equal (pen.Color, Color.SteelBlue, "P129#2");

			try {
				pen.Color = Color.SteelBlue;
				Assert.Fail ("P129#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P129#3");
			}
		}

		[Fact]
		public void TestTan ()
		{
			Pen pen = Pens.Tan;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P130#1");
			Assert.Equal (pen.Color, Color.Tan, "P130#2");

			try {
				pen.Color = Color.Tan;
				Assert.Fail ("P130#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P130#3");
			}
		}

		[Fact]
		public void TestTeal ()
		{
			Pen pen = Pens.Teal;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P131#1");
			Assert.Equal (pen.Color, Color.Teal, "P131#2");

			try {
				pen.Color = Color.Teal;
				Assert.Fail ("P131#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P131#3");
			}
		}

		[Fact]
		public void TestThistle ()
		{
			Pen pen = Pens.Thistle;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P132#1");
			Assert.Equal (pen.Color, Color.Thistle, "P132#2");

			try {
				pen.Color = Color.Thistle;
				Assert.Fail ("P132#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P132#3");
			}
		}

		[Fact]
		public void TestTomato ()
		{
			Pen pen = Pens.Tomato;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P133#1");
			Assert.Equal (pen.Color, Color.Tomato, "P133#2");

			try {
				pen.Color = Color.Tomato;
				Assert.Fail ("P133#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P133#3");
			}
		}

		[Fact]
		public void TestTransparent ()
		{
			Pen pen = Pens.Transparent;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P134#1");
			Assert.Equal (pen.Color, Color.Transparent, "P134#2");

			try {
				pen.Color = Color.Transparent;
				Assert.Fail ("P134#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P134#3");
			}
		}

		[Fact]
		public void TestTurquoise ()
		{
			Pen pen = Pens.Turquoise;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P135#1");
			Assert.Equal (pen.Color, Color.Turquoise, "P135#2");

			try {
				pen.Color = Color.Turquoise;
				Assert.Fail ("P135#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P135#3");
			}
		}

		[Fact]
		public void TestViolet ()
		{
			Pen pen = Pens.Violet;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P136#1");
			Assert.Equal (pen.Color, Color.Violet, "P136#2");

			try {
				pen.Color = Color.Violet;
				Assert.Fail ("P136#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P136#3");
			}
		}

		[Fact]
		public void TestWheat ()
		{
			Pen pen = Pens.Wheat;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P137#1");
			Assert.Equal (pen.Color, Color.Wheat, "P137#2");

			try {
				pen.Color = Color.Wheat;
				Assert.Fail ("P137#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P137#3");
			}
		}

		[Fact]
		public void TestWhite ()
		{
			Pen pen = Pens.White;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P138#1");
			Assert.Equal (pen.Color, Color.White, "P138#2");

			try {
				pen.Color = Color.White;
				Assert.Fail ("P138#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P138#3");
			}
		}

		[Fact]
		public void TestWhiteSmoke ()
		{
			Pen pen = Pens.WhiteSmoke;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P139#1");
			Assert.Equal (pen.Color, Color.WhiteSmoke, "P139#2");

			try {
				pen.Color = Color.WhiteSmoke;
				Assert.Fail ("P139#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P139#3");
			}
		}

		[Fact]
		public void TestYellow ()
		{
			Pen pen = Pens.Yellow;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P140#1");
			Assert.Equal (pen.Color, Color.Yellow, "P140#2");

			try {
				pen.Color = Color.Yellow;
				Assert.Fail ("P140#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P140#3");
			}
		}

		[Fact]
		public void TestYellowGreen ()
		{
			Pen pen = Pens.YellowGreen;
			Assert.Equal (pen.PenType, PenType.SolidColor, "P141#1");
			Assert.Equal (pen.Color, Color.YellowGreen, "P141#2");

			try {
				pen.Color = Color.YellowGreen;
				Assert.Fail ("P141#3: must throw ArgumentException");
			} catch (ArgumentException) {
				Assert.True (true, "P141#3");
			}
		}
	}
}

// Following code was used to generate the test methods above
//
//Type type = typeof (Pens);
//PropertyInfo [] properties = type.GetProperties ();
//int count = 1;
//foreach (PropertyInfo property in properties) {
//	Console.WriteLine();
//	Console.WriteLine("\t\t[Fact]");
//	Console.WriteLine("\t\tpublic void Test" + property.Name + " ()");
//	Console.WriteLine("\t\t{");
//	Console.WriteLine("\t\t\tPen pen = Pens." + property.Name + ";");
//	Console.WriteLine("\t\t\tAssertEquals (\"P" + count + "#1\", pen.PenType, PenType.SolidColor);");
//	Console.WriteLine("\t\t\tAssertEquals (\"P" + count + "#2\", pen.Color, Color." + property.Name + ");\n");
//
//	Console.WriteLine("\t\t\ttry {");
//	Console.WriteLine("\t\t\t\tpen.Color = Color." + property.Name + ";");
//	Console.WriteLine("\t\t\t\tAssert.Fail (\"P" + count + "#3: must throw ArgumentException\");");
//	Console.WriteLine("\t\t\t} catch (ArgumentException) {");
//	Console.WriteLine("\t\t\t\tAssert.True (\"P" + count + "#3\", true);");
//	Console.WriteLine("\t\t\t}");
//	Console.WriteLine("\t\t}");
//	count++;
//}

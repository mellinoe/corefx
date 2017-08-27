//
// Tests for System.Drawing.Brushes.cs
//
// Authors:
//	Ravindra (rkumar@novell.com)
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
using System.Security.Permissions;

namespace MonoTests.System.Drawing {

	[TestFixture]
	public class BrushesTest {

		[Fact]
		public void Equality ()
		{
			Brush brush1 = Brushes.Blue;
			Brush brush2 = Brushes.Blue;
			Assert.True (brush1.Equals (brush2), "Equals");
			Assert.True (Object.ReferenceEquals (brush1, brush2), "ReferenceEquals");
		}

		[Fact]
		public void Dispose ()
		{
			Brushes.YellowGreen.Dispose ();
			// a "normal" SolidBrush would throw an ArgumentException here
			Assert.Throws<ArgumentException> (() => Brushes.YellowGreen.Clone ());
			// and it is! so watch your brushes ;-)
		}

		[Fact]
		public void Properties ()
		{
			Brush br;
			SolidBrush solid;

			br = Brushes.Transparent;
			Assert.True ((br is SolidBrush), "P1#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Transparent, solid.Color, "P1#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P1#3");
			Assert.Equal (Color.Red, (Brushes.Transparent as SolidBrush).Color, "P1#4");
			solid.Color = Color.Transparent; // revert to correct color (for other unit tests)

			br = Brushes.AliceBlue;
			Assert.True ((br is SolidBrush), "P2#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.AliceBlue, solid.Color, "P2#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P2#3");
			Assert.Equal (Color.Red, (Brushes.AliceBlue as SolidBrush).Color, "P2#4");
			solid.Color = Color.AliceBlue; // revert to correct color (for other unit tests)

			br = Brushes.AntiqueWhite;
			Assert.True ((br is SolidBrush), "P3#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.AntiqueWhite, solid.Color, "P3#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P3#3");
			Assert.Equal (Color.Red, (Brushes.AntiqueWhite as SolidBrush).Color, "P3#4");
			solid.Color = Color.AntiqueWhite; // revert to correct color (for other unit tests)

			br = Brushes.Aqua;
			Assert.True ((br is SolidBrush), "P4#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Aqua, solid.Color, "P4#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P4#3");
			Assert.Equal (Color.Red, (Brushes.Aqua as SolidBrush).Color, "P4#4");
			solid.Color = Color.Aqua; // revert to correct color (for other unit tests)

			br = Brushes.Aquamarine;
			Assert.True ((br is SolidBrush), "P5#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Aquamarine, solid.Color, "P5#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P5#3");
			Assert.Equal (Color.Red, (Brushes.Aquamarine as SolidBrush).Color, "P5#4");
			solid.Color = Color.Aquamarine; // revert to correct color (for other unit tests)

			br = Brushes.Azure;
			Assert.True ((br is SolidBrush), "P6#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Azure, solid.Color, "P6#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P6#3");
			Assert.Equal (Color.Red, (Brushes.Azure as SolidBrush).Color, "P6#4");
			solid.Color = Color.Azure; // revert to correct color (for other unit tests)

			br = Brushes.Beige;
			Assert.True ((br is SolidBrush), "P7#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Beige, solid.Color, "P7#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P7#3");
			Assert.Equal (Color.Red, (Brushes.Beige as SolidBrush).Color, "P7#4");
			solid.Color = Color.Beige; // revert to correct color (for other unit tests)

			br = Brushes.Bisque;
			Assert.True ((br is SolidBrush), "P8#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Bisque, solid.Color, "P8#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P8#3");
			Assert.Equal (Color.Red, (Brushes.Bisque as SolidBrush).Color, "P8#4");
			solid.Color = Color.Bisque; // revert to correct color (for other unit tests)

			br = Brushes.Black;
			Assert.True ((br is SolidBrush), "P9#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Black, solid.Color, "P9#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P9#3");
			Assert.Equal (Color.Red, (Brushes.Black as SolidBrush).Color, "P9#4");
			solid.Color = Color.Black; // revert to correct color (for other unit tests)

			br = Brushes.BlanchedAlmond;
			Assert.True ((br is SolidBrush), "P10#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.BlanchedAlmond, solid.Color, "P10#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P10#3");
			Assert.Equal (Color.Red, (Brushes.BlanchedAlmond as SolidBrush).Color, "P10#4");
			solid.Color = Color.BlanchedAlmond; // revert to correct color (for other unit tests)

			br = Brushes.Blue;
			Assert.True ((br is SolidBrush), "P11#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Blue, solid.Color, "P11#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P11#3");
			Assert.Equal (Color.Red, (Brushes.Blue as SolidBrush).Color, "P11#4");
			solid.Color = Color.Blue; // revert to correct color (for other unit tests)

			br = Brushes.BlueViolet;
			Assert.True ((br is SolidBrush), "P12#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.BlueViolet, solid.Color, "P12#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P12#3");
			Assert.Equal (Color.Red, (Brushes.BlueViolet as SolidBrush).Color, "P12#4");
			solid.Color = Color.BlueViolet; // revert to correct color (for other unit tests)

			br = Brushes.Brown;
			Assert.True ((br is SolidBrush), "P13#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Brown, solid.Color, "P13#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P13#3");
			Assert.Equal (Color.Red, (Brushes.Brown as SolidBrush).Color, "P13#4");
			solid.Color = Color.Brown; // revert to correct color (for other unit tests)

			br = Brushes.BurlyWood;
			Assert.True ((br is SolidBrush), "P14#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.BurlyWood, solid.Color, "P14#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P14#3");
			Assert.Equal (Color.Red, (Brushes.BurlyWood as SolidBrush).Color, "P14#4");
			solid.Color = Color.BurlyWood; // revert to correct color (for other unit tests)

			br = Brushes.CadetBlue;
			Assert.True ((br is SolidBrush), "P15#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.CadetBlue, solid.Color, "P15#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P15#3");
			Assert.Equal (Color.Red, (Brushes.CadetBlue as SolidBrush).Color, "P15#4");
			solid.Color = Color.CadetBlue; // revert to correct color (for other unit tests)

			br = Brushes.Chartreuse;
			Assert.True ((br is SolidBrush), "P16#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Chartreuse, solid.Color, "P16#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P16#3");
			Assert.Equal (Color.Red, (Brushes.Chartreuse as SolidBrush).Color, "P16#4");
			solid.Color = Color.Chartreuse; // revert to correct color (for other unit tests)

			br = Brushes.Chocolate;
			Assert.True ((br is SolidBrush), "P17#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Chocolate, solid.Color, "P17#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P17#3");
			Assert.Equal (Color.Red, (Brushes.Chocolate as SolidBrush).Color, "P17#4");
			solid.Color = Color.Chocolate; // revert to correct color (for other unit tests)

			br = Brushes.Coral;
			Assert.True ((br is SolidBrush), "P18#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Coral, solid.Color, "P18#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P18#3");
			Assert.Equal (Color.Red, (Brushes.Coral as SolidBrush).Color, "P18#4");
			solid.Color = Color.Coral; // revert to correct color (for other unit tests)

			br = Brushes.CornflowerBlue;
			Assert.True ((br is SolidBrush), "P19#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.CornflowerBlue, solid.Color, "P19#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P19#3");
			Assert.Equal (Color.Red, (Brushes.CornflowerBlue as SolidBrush).Color, "P19#4");
			solid.Color = Color.CornflowerBlue; // revert to correct color (for other unit tests)

			br = Brushes.Cornsilk;
			Assert.True ((br is SolidBrush), "P20#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Cornsilk, solid.Color, "P20#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P20#3");
			Assert.Equal (Color.Red, (Brushes.Cornsilk as SolidBrush).Color, "P20#4");
			solid.Color = Color.Cornsilk; // revert to correct color (for other unit tests)

			br = Brushes.Crimson;
			Assert.True ((br is SolidBrush), "P21#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Crimson, solid.Color, "P21#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P21#3");
			Assert.Equal (Color.Red, (Brushes.Crimson as SolidBrush).Color, "P21#4");
			solid.Color = Color.Crimson; // revert to correct color (for other unit tests)

			br = Brushes.Cyan;
			Assert.True ((br is SolidBrush), "P22#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Cyan, solid.Color, "P22#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P22#3");
			Assert.Equal (Color.Red, (Brushes.Cyan as SolidBrush).Color, "P22#4");
			solid.Color = Color.Cyan; // revert to correct color (for other unit tests)

			br = Brushes.DarkBlue;
			Assert.True ((br is SolidBrush), "P23#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkBlue, solid.Color, "P23#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P23#3");
			Assert.Equal (Color.Red, (Brushes.DarkBlue as SolidBrush).Color, "P23#4");
			solid.Color = Color.DarkBlue; // revert to correct color (for other unit tests)

			br = Brushes.DarkCyan;
			Assert.True ((br is SolidBrush), "P24#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkCyan, solid.Color, "P24#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P24#3");
			Assert.Equal (Color.Red, (Brushes.DarkCyan as SolidBrush).Color, "P24#4");
			solid.Color = Color.DarkCyan; // revert to correct color (for other unit tests)

			br = Brushes.DarkGoldenrod;
			Assert.True ((br is SolidBrush), "P25#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkGoldenrod, solid.Color, "P25#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P25#3");
			Assert.Equal (Color.Red, (Brushes.DarkGoldenrod as SolidBrush).Color, "P25#4");
			solid.Color = Color.DarkGoldenrod; // revert to correct color (for other unit tests)

			br = Brushes.DarkGray;
			Assert.True ((br is SolidBrush), "P26#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkGray, solid.Color, "P26#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P26#3");
			Assert.Equal (Color.Red, (Brushes.DarkGray as SolidBrush).Color, "P26#4");
			solid.Color = Color.DarkGray; // revert to correct color (for other unit tests)

			br = Brushes.DarkGreen;
			Assert.True ((br is SolidBrush), "P27#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkGreen, solid.Color, "P27#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P27#3");
			Assert.Equal (Color.Red, (Brushes.DarkGreen as SolidBrush).Color, "P27#4");
			solid.Color = Color.DarkGreen; // revert to correct color (for other unit tests)

			br = Brushes.DarkKhaki;
			Assert.True ((br is SolidBrush), "P28#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkKhaki, solid.Color, "P28#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P28#3");
			Assert.Equal (Color.Red, (Brushes.DarkKhaki as SolidBrush).Color, "P28#4");
			solid.Color = Color.DarkKhaki; // revert to correct color (for other unit tests)

			br = Brushes.DarkMagenta;
			Assert.True ((br is SolidBrush), "P29#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkMagenta, solid.Color, "P29#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P29#3");
			Assert.Equal (Color.Red, (Brushes.DarkMagenta as SolidBrush).Color, "P29#4");
			solid.Color = Color.DarkMagenta; // revert to correct color (for other unit tests)

			br = Brushes.DarkOliveGreen;
			Assert.True ((br is SolidBrush), "P30#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkOliveGreen, solid.Color, "P30#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P30#3");
			Assert.Equal (Color.Red, (Brushes.DarkOliveGreen as SolidBrush).Color, "P30#4");
			solid.Color = Color.DarkOliveGreen; // revert to correct color (for other unit tests)

			br = Brushes.DarkOrange;
			Assert.True ((br is SolidBrush), "P31#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkOrange, solid.Color, "P31#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P31#3");
			Assert.Equal (Color.Red, (Brushes.DarkOrange as SolidBrush).Color, "P31#4");
			solid.Color = Color.DarkOrange; // revert to correct color (for other unit tests)

			br = Brushes.DarkOrchid;
			Assert.True ((br is SolidBrush), "P32#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkOrchid, solid.Color, "P32#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P32#3");
			Assert.Equal (Color.Red, (Brushes.DarkOrchid as SolidBrush).Color, "P32#4");
			solid.Color = Color.DarkOrchid; // revert to correct color (for other unit tests)

			br = Brushes.DarkRed;
			Assert.True ((br is SolidBrush), "P33#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkRed, solid.Color, "P33#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P33#3");
			Assert.Equal (Color.Red, (Brushes.DarkRed as SolidBrush).Color, "P33#4");
			solid.Color = Color.DarkRed; // revert to correct color (for other unit tests)

			br = Brushes.DarkSalmon;
			Assert.True ((br is SolidBrush), "P34#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkSalmon, solid.Color, "P34#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P34#3");
			Assert.Equal (Color.Red, (Brushes.DarkSalmon as SolidBrush).Color, "P34#4");
			solid.Color = Color.DarkSalmon; // revert to correct color (for other unit tests)

			br = Brushes.DarkSeaGreen;
			Assert.True ((br is SolidBrush), "P35#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkSeaGreen, solid.Color, "P35#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P35#3");
			Assert.Equal (Color.Red, (Brushes.DarkSeaGreen as SolidBrush).Color, "P35#4");
			solid.Color = Color.DarkSeaGreen; // revert to correct color (for other unit tests)

			br = Brushes.DarkSlateBlue;
			Assert.True ((br is SolidBrush), "P36#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkSlateBlue, solid.Color, "P36#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P36#3");
			Assert.Equal (Color.Red, (Brushes.DarkSlateBlue as SolidBrush).Color, "P36#4");
			solid.Color = Color.DarkSlateBlue; // revert to correct color (for other unit tests)

			br = Brushes.DarkSlateGray;
			Assert.True ((br is SolidBrush), "P37#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkSlateGray, solid.Color, "P37#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P37#3");
			Assert.Equal (Color.Red, (Brushes.DarkSlateGray as SolidBrush).Color, "P37#4");
			solid.Color = Color.DarkSlateGray; // revert to correct color (for other unit tests)

			br = Brushes.DarkTurquoise;
			Assert.True ((br is SolidBrush), "P38#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkTurquoise, solid.Color, "P38#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P38#3");
			Assert.Equal (Color.Red, (Brushes.DarkTurquoise as SolidBrush).Color, "P38#4");
			solid.Color = Color.DarkTurquoise; // revert to correct color (for other unit tests)

			br = Brushes.DarkViolet;
			Assert.True ((br is SolidBrush), "P39#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DarkViolet, solid.Color, "P39#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P39#3");
			Assert.Equal (Color.Red, (Brushes.DarkViolet as SolidBrush).Color, "P39#4");
			solid.Color = Color.DarkViolet; // revert to correct color (for other unit tests)

			br = Brushes.DeepPink;
			Assert.True ((br is SolidBrush), "P40#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DeepPink, solid.Color, "P40#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P40#3");
			Assert.Equal (Color.Red, (Brushes.DeepPink as SolidBrush).Color, "P40#4");
			solid.Color = Color.DeepPink; // revert to correct color (for other unit tests)

			br = Brushes.DeepSkyBlue;
			Assert.True ((br is SolidBrush), "P41#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DeepSkyBlue, solid.Color, "P41#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P41#3");
			Assert.Equal (Color.Red, (Brushes.DeepSkyBlue as SolidBrush).Color, "P41#4");
			solid.Color = Color.DeepSkyBlue; // revert to correct color (for other unit tests)

			br = Brushes.DimGray;
			Assert.True ((br is SolidBrush), "P42#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DimGray, solid.Color, "P42#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P42#3");
			Assert.Equal (Color.Red, (Brushes.DimGray as SolidBrush).Color, "P42#4");
			solid.Color = Color.DimGray; // revert to correct color (for other unit tests)

			br = Brushes.DodgerBlue;
			Assert.True ((br is SolidBrush), "P43#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.DodgerBlue, solid.Color, "P43#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P43#3");
			Assert.Equal (Color.Red, (Brushes.DodgerBlue as SolidBrush).Color, "P43#4");
			solid.Color = Color.DodgerBlue; // revert to correct color (for other unit tests)

			br = Brushes.Firebrick;
			Assert.True ((br is SolidBrush), "P44#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Firebrick, solid.Color, "P44#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P44#3");
			Assert.Equal (Color.Red, (Brushes.Firebrick as SolidBrush).Color, "P44#4");
			solid.Color = Color.Firebrick; // revert to correct color (for other unit tests)

			br = Brushes.FloralWhite;
			Assert.True ((br is SolidBrush), "P45#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.FloralWhite, solid.Color, "P45#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P45#3");
			Assert.Equal (Color.Red, (Brushes.FloralWhite as SolidBrush).Color, "P45#4");
			solid.Color = Color.FloralWhite; // revert to correct color (for other unit tests)

			br = Brushes.ForestGreen;
			Assert.True ((br is SolidBrush), "P46#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.ForestGreen, solid.Color, "P46#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P46#3");
			Assert.Equal (Color.Red, (Brushes.ForestGreen as SolidBrush).Color, "P46#4");
			solid.Color = Color.ForestGreen; // revert to correct color (for other unit tests)

			br = Brushes.Fuchsia;
			Assert.True ((br is SolidBrush), "P47#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Fuchsia, solid.Color, "P47#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P47#3");
			Assert.Equal (Color.Red, (Brushes.Fuchsia as SolidBrush).Color, "P47#4");
			solid.Color = Color.Fuchsia; // revert to correct color (for other unit tests)

			br = Brushes.Gainsboro;
			Assert.True ((br is SolidBrush), "P48#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Gainsboro, solid.Color, "P48#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P48#3");
			Assert.Equal (Color.Red, (Brushes.Gainsboro as SolidBrush).Color, "P48#4");
			solid.Color = Color.Gainsboro; // revert to correct color (for other unit tests)

			br = Brushes.GhostWhite;
			Assert.True ((br is SolidBrush), "P49#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.GhostWhite, solid.Color, "P49#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P49#3");
			Assert.Equal (Color.Red, (Brushes.GhostWhite as SolidBrush).Color, "P49#4");
			solid.Color = Color.GhostWhite; // revert to correct color (for other unit tests)

			br = Brushes.Gold;
			Assert.True ((br is SolidBrush), "P50#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Gold, solid.Color, "P50#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P50#3");
			Assert.Equal (Color.Red, (Brushes.Gold as SolidBrush).Color, "P50#4");
			solid.Color = Color.Gold; // revert to correct color (for other unit tests)

			br = Brushes.Goldenrod;
			Assert.True ((br is SolidBrush), "P51#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Goldenrod, solid.Color, "P51#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P51#3");
			Assert.Equal (Color.Red, (Brushes.Goldenrod as SolidBrush).Color, "P51#4");
			solid.Color = Color.Goldenrod; // revert to correct color (for other unit tests)

			br = Brushes.Gray;
			Assert.True ((br is SolidBrush), "P52#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Gray, solid.Color, "P52#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P52#3");
			Assert.Equal (Color.Red, (Brushes.Gray as SolidBrush).Color, "P52#4");
			solid.Color = Color.Gray; // revert to correct color (for other unit tests)

			br = Brushes.Green;
			Assert.True ((br is SolidBrush), "P53#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Green, solid.Color, "P53#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P53#3");
			Assert.Equal (Color.Red, (Brushes.Green as SolidBrush).Color, "P53#4");
			solid.Color = Color.Green; // revert to correct color (for other unit tests)

			br = Brushes.GreenYellow;
			Assert.True ((br is SolidBrush), "P54#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.GreenYellow, solid.Color, "P54#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P54#3");
			Assert.Equal (Color.Red, (Brushes.GreenYellow as SolidBrush).Color, "P54#4");
			solid.Color = Color.GreenYellow; // revert to correct color (for other unit tests)

			br = Brushes.Honeydew;
			Assert.True ((br is SolidBrush), "P55#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Honeydew, solid.Color, "P55#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P55#3");
			Assert.Equal (Color.Red, (Brushes.Honeydew as SolidBrush).Color, "P55#4");
			solid.Color = Color.Honeydew; // revert to correct color (for other unit tests)

			br = Brushes.HotPink;
			Assert.True ((br is SolidBrush), "P56#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.HotPink, solid.Color, "P56#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P56#3");
			Assert.Equal (Color.Red, (Brushes.HotPink as SolidBrush).Color, "P56#4");
			solid.Color = Color.HotPink; // revert to correct color (for other unit tests)

			br = Brushes.IndianRed;
			Assert.True ((br is SolidBrush), "P57#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.IndianRed, solid.Color, "P57#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P57#3");
			Assert.Equal (Color.Red, (Brushes.IndianRed as SolidBrush).Color, "P57#4");
			solid.Color = Color.IndianRed; // revert to correct color (for other unit tests)

			br = Brushes.Indigo;
			Assert.True ((br is SolidBrush), "P58#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Indigo, solid.Color, "P58#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P58#3");
			Assert.Equal (Color.Red, (Brushes.Indigo as SolidBrush).Color, "P58#4");
			solid.Color = Color.Indigo; // revert to correct color (for other unit tests)

			br = Brushes.Ivory;
			Assert.True ((br is SolidBrush), "P59#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Ivory, solid.Color, "P59#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P59#3");
			Assert.Equal (Color.Red, (Brushes.Ivory as SolidBrush).Color, "P59#4");
			solid.Color = Color.Ivory; // revert to correct color (for other unit tests)

			br = Brushes.Khaki;
			Assert.True ((br is SolidBrush), "P60#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Khaki, solid.Color, "P60#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P60#3");
			Assert.Equal (Color.Red, (Brushes.Khaki as SolidBrush).Color, "P60#4");
			solid.Color = Color.Khaki; // revert to correct color (for other unit tests)

			br = Brushes.Lavender;
			Assert.True ((br is SolidBrush), "P61#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Lavender, solid.Color, "P61#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P61#3");
			Assert.Equal (Color.Red, (Brushes.Lavender as SolidBrush).Color, "P61#4");
			solid.Color = Color.Lavender; // revert to correct color (for other unit tests)

			br = Brushes.LavenderBlush;
			Assert.True ((br is SolidBrush), "P62#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LavenderBlush, solid.Color, "P62#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P62#3");
			Assert.Equal (Color.Red, (Brushes.LavenderBlush as SolidBrush).Color, "P62#4");
			solid.Color = Color.LavenderBlush; // revert to correct color (for other unit tests)

			br = Brushes.LawnGreen;
			Assert.True ((br is SolidBrush), "P63#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LawnGreen, solid.Color, "P63#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P63#3");
			Assert.Equal (Color.Red, (Brushes.LawnGreen as SolidBrush).Color, "P63#4");
			solid.Color = Color.LawnGreen; // revert to correct color (for other unit tests)

			br = Brushes.LemonChiffon;
			Assert.True ((br is SolidBrush), "P64#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LemonChiffon, solid.Color, "P64#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P64#3");
			Assert.Equal (Color.Red, (Brushes.LemonChiffon as SolidBrush).Color, "P64#4");
			solid.Color = Color.LemonChiffon; // revert to correct color (for other unit tests)

			br = Brushes.LightBlue;
			Assert.True ((br is SolidBrush), "P65#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightBlue, solid.Color, "P65#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P65#3");
			Assert.Equal (Color.Red, (Brushes.LightBlue as SolidBrush).Color, "P65#4");
			solid.Color = Color.LightBlue; // revert to correct color (for other unit tests)

			br = Brushes.LightCoral;
			Assert.True ((br is SolidBrush), "P66#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightCoral, solid.Color, "P66#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P66#3");
			Assert.Equal (Color.Red, (Brushes.LightCoral as SolidBrush).Color, "P66#4");
			solid.Color = Color.LightCoral; // revert to correct color (for other unit tests)

			br = Brushes.LightCyan;
			Assert.True ((br is SolidBrush), "P67#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightCyan, solid.Color, "P67#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P67#3");
			Assert.Equal (Color.Red, (Brushes.LightCyan as SolidBrush).Color, "P67#4");
			solid.Color = Color.LightCyan; // revert to correct color (for other unit tests)

			br = Brushes.LightGoldenrodYellow;
			Assert.True ((br is SolidBrush), "P68#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightGoldenrodYellow, solid.Color, "P68#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P68#3");
			Assert.Equal (Color.Red, (Brushes.LightGoldenrodYellow as SolidBrush).Color, "P68#4");
			solid.Color = Color.LightGoldenrodYellow; // revert to correct color (for other unit tests)

			br = Brushes.LightGreen;
			Assert.True ((br is SolidBrush), "P69#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightGreen, solid.Color, "P69#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P69#3");
			Assert.Equal (Color.Red, (Brushes.LightGreen as SolidBrush).Color, "P69#4");
			solid.Color = Color.LightGreen; // revert to correct color (for other unit tests)

			br = Brushes.LightGray;
			Assert.True ((br is SolidBrush), "P70#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightGray, solid.Color, "P70#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P70#3");
			Assert.Equal (Color.Red, (Brushes.LightGray as SolidBrush).Color, "P70#4");
			solid.Color = Color.LightGray; // revert to correct color (for other unit tests)

			br = Brushes.LightPink;
			Assert.True ((br is SolidBrush), "P71#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightPink, solid.Color, "P71#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P71#3");
			Assert.Equal (Color.Red, (Brushes.LightPink as SolidBrush).Color, "P71#4");
			solid.Color = Color.LightPink; // revert to correct color (for other unit tests)

			br = Brushes.LightSalmon;
			Assert.True ((br is SolidBrush), "P72#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightSalmon, solid.Color, "P72#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P72#3");
			Assert.Equal (Color.Red, (Brushes.LightSalmon as SolidBrush).Color, "P72#4");
			solid.Color = Color.LightSalmon; // revert to correct color (for other unit tests)

			br = Brushes.LightSeaGreen;
			Assert.True ((br is SolidBrush), "P73#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightSeaGreen, solid.Color, "P73#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P73#3");
			Assert.Equal (Color.Red, (Brushes.LightSeaGreen as SolidBrush).Color, "P73#4");
			solid.Color = Color.LightSeaGreen; // revert to correct color (for other unit tests)

			br = Brushes.LightSkyBlue;
			Assert.True ((br is SolidBrush), "P74#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightSkyBlue, solid.Color, "P74#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P74#3");
			Assert.Equal (Color.Red, (Brushes.LightSkyBlue as SolidBrush).Color, "P74#4");
			solid.Color = Color.LightSkyBlue; // revert to correct color (for other unit tests)

			br = Brushes.LightSlateGray;
			Assert.True ((br is SolidBrush), "P75#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightSlateGray, solid.Color, "P75#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P75#3");
			Assert.Equal (Color.Red, (Brushes.LightSlateGray as SolidBrush).Color, "P75#4");
			solid.Color = Color.LightSlateGray; // revert to correct color (for other unit tests)

			br = Brushes.LightSteelBlue;
			Assert.True ((br is SolidBrush), "P76#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightSteelBlue, solid.Color, "P76#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P76#3");
			Assert.Equal (Color.Red, (Brushes.LightSteelBlue as SolidBrush).Color, "P76#4");
			solid.Color = Color.LightSteelBlue; // revert to correct color (for other unit tests)

			br = Brushes.LightYellow;
			Assert.True ((br is SolidBrush), "P77#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LightYellow, solid.Color, "P77#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P77#3");
			Assert.Equal (Color.Red, (Brushes.LightYellow as SolidBrush).Color, "P77#4");
			solid.Color = Color.LightYellow; // revert to correct color (for other unit tests)

			br = Brushes.Lime;
			Assert.True ((br is SolidBrush), "P78#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Lime, solid.Color, "P78#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P78#3");
			Assert.Equal (Color.Red, (Brushes.Lime as SolidBrush).Color, "P78#4");
			solid.Color = Color.Lime; // revert to correct color (for other unit tests)

			br = Brushes.LimeGreen;
			Assert.True ((br is SolidBrush), "P79#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.LimeGreen, solid.Color, "P79#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P79#3");
			Assert.Equal (Color.Red, (Brushes.LimeGreen as SolidBrush).Color, "P79#4");
			solid.Color = Color.LimeGreen; // revert to correct color (for other unit tests)

			br = Brushes.Linen;
			Assert.True ((br is SolidBrush), "P80#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Linen, solid.Color, "P80#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P80#3");
			Assert.Equal (Color.Red, (Brushes.Linen as SolidBrush).Color, "P80#4");
			solid.Color = Color.Linen; // revert to correct color (for other unit tests)

			br = Brushes.Magenta;
			Assert.True ((br is SolidBrush), "P81#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Magenta, solid.Color, "P81#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P81#3");
			Assert.Equal (Color.Red, (Brushes.Magenta as SolidBrush).Color, "P81#4");
			solid.Color = Color.Magenta; // revert to correct color (for other unit tests)

			br = Brushes.Maroon;
			Assert.True ((br is SolidBrush), "P82#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Maroon, solid.Color, "P82#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P82#3");
			Assert.Equal (Color.Red, (Brushes.Maroon as SolidBrush).Color, "P82#4");
			solid.Color = Color.Maroon; // revert to correct color (for other unit tests)

			br = Brushes.MediumAquamarine;
			Assert.True ((br is SolidBrush), "P83#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumAquamarine, solid.Color, "P83#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P83#3");
			Assert.Equal (Color.Red, (Brushes.MediumAquamarine as SolidBrush).Color, "P83#4");
			solid.Color = Color.MediumAquamarine; // revert to correct color (for other unit tests)

			br = Brushes.MediumBlue;
			Assert.True ((br is SolidBrush), "P84#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumBlue, solid.Color, "P84#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P84#3");
			Assert.Equal (Color.Red, (Brushes.MediumBlue as SolidBrush).Color, "P84#4");
			solid.Color = Color.MediumBlue; // revert to correct color (for other unit tests)

			br = Brushes.MediumOrchid;
			Assert.True ((br is SolidBrush), "P85#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumOrchid, solid.Color, "P85#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P85#3");
			Assert.Equal (Color.Red, (Brushes.MediumOrchid as SolidBrush).Color, "P85#4");
			solid.Color = Color.MediumOrchid; // revert to correct color (for other unit tests)

			br = Brushes.MediumPurple;
			Assert.True ((br is SolidBrush), "P86#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumPurple, solid.Color, "P86#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P86#3");
			Assert.Equal (Color.Red, (Brushes.MediumPurple as SolidBrush).Color, "P86#4");
			solid.Color = Color.MediumPurple; // revert to correct color (for other unit tests)

			br = Brushes.MediumSeaGreen;
			Assert.True ((br is SolidBrush), "P87#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumSeaGreen, solid.Color, "P87#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P87#3");
			Assert.Equal (Color.Red, (Brushes.MediumSeaGreen as SolidBrush).Color, "P87#4");
			solid.Color = Color.MediumSeaGreen; // revert to correct color (for other unit tests)

			br = Brushes.MediumSlateBlue;
			Assert.True ((br is SolidBrush), "P88#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumSlateBlue, solid.Color, "P88#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P88#3");
			Assert.Equal (Color.Red, (Brushes.MediumSlateBlue as SolidBrush).Color, "P88#4");
			solid.Color = Color.MediumSlateBlue; // revert to correct color (for other unit tests)

			br = Brushes.MediumSpringGreen;
			Assert.True ((br is SolidBrush), "P89#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumSpringGreen, solid.Color, "P89#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P89#3");
			Assert.Equal (Color.Red, (Brushes.MediumSpringGreen as SolidBrush).Color, "P89#4");
			solid.Color = Color.MediumSpringGreen; // revert to correct color (for other unit tests)

			br = Brushes.MediumTurquoise;
			Assert.True ((br is SolidBrush), "P90#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumTurquoise, solid.Color, "P90#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P90#3");
			Assert.Equal (Color.Red, (Brushes.MediumTurquoise as SolidBrush).Color, "P90#4");
			solid.Color = Color.MediumTurquoise; // revert to correct color (for other unit tests)

			br = Brushes.MediumVioletRed;
			Assert.True ((br is SolidBrush), "P91#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MediumVioletRed, solid.Color, "P91#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P91#3");
			Assert.Equal (Color.Red, (Brushes.MediumVioletRed as SolidBrush).Color, "P91#4");
			solid.Color = Color.MediumVioletRed; // revert to correct color (for other unit tests)

			br = Brushes.MidnightBlue;
			Assert.True ((br is SolidBrush), "P92#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MidnightBlue, solid.Color, "P92#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P92#3");
			Assert.Equal (Color.Red, (Brushes.MidnightBlue as SolidBrush).Color, "P92#4");
			solid.Color = Color.MidnightBlue; // revert to correct color (for other unit tests)

			br = Brushes.MintCream;
			Assert.True ((br is SolidBrush), "P93#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MintCream, solid.Color, "P93#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P93#3");
			Assert.Equal (Color.Red, (Brushes.MintCream as SolidBrush).Color, "P93#4");
			solid.Color = Color.MintCream; // revert to correct color (for other unit tests)

			br = Brushes.MistyRose;
			Assert.True ((br is SolidBrush), "P94#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.MistyRose, solid.Color, "P94#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P94#3");
			Assert.Equal (Color.Red, (Brushes.MistyRose as SolidBrush).Color, "P94#4");
			solid.Color = Color.MistyRose; // revert to correct color (for other unit tests)

			br = Brushes.Moccasin;
			Assert.True ((br is SolidBrush), "P95#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Moccasin, solid.Color, "P95#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P95#3");
			Assert.Equal (Color.Red, (Brushes.Moccasin as SolidBrush).Color, "P95#4");
			solid.Color = Color.Moccasin; // revert to correct color (for other unit tests)

			br = Brushes.NavajoWhite;
			Assert.True ((br is SolidBrush), "P96#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.NavajoWhite, solid.Color, "P96#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P96#3");
			Assert.Equal (Color.Red, (Brushes.NavajoWhite as SolidBrush).Color, "P96#4");
			solid.Color = Color.NavajoWhite; // revert to correct color (for other unit tests)

			br = Brushes.Navy;
			Assert.True ((br is SolidBrush), "P97#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Navy, solid.Color, "P97#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P97#3");
			Assert.Equal (Color.Red, (Brushes.Navy as SolidBrush).Color, "P97#4");
			solid.Color = Color.Navy; // revert to correct color (for other unit tests)

			br = Brushes.OldLace;
			Assert.True ((br is SolidBrush), "P98#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.OldLace, solid.Color, "P98#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P98#3");
			Assert.Equal (Color.Red, (Brushes.OldLace as SolidBrush).Color, "P98#4");
			solid.Color = Color.OldLace; // revert to correct color (for other unit tests)

			br = Brushes.Olive;
			Assert.True ((br is SolidBrush), "P99#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Olive, solid.Color, "P99#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P99#3");
			Assert.Equal (Color.Red, (Brushes.Olive as SolidBrush).Color, "P99#4");
			solid.Color = Color.Olive; // revert to correct color (for other unit tests)

			br = Brushes.OliveDrab;
			Assert.True ((br is SolidBrush), "P100#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.OliveDrab, solid.Color, "P100#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P100#3");
			Assert.Equal (Color.Red, (Brushes.OliveDrab as SolidBrush).Color, "P100#4");
			solid.Color = Color.OliveDrab; // revert to correct color (for other unit tests)

			br = Brushes.Orange;
			Assert.True ((br is SolidBrush), "P101#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Orange, solid.Color, "P101#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P101#3");
			Assert.Equal (Color.Red, (Brushes.Orange as SolidBrush).Color, "P101#4");
			solid.Color = Color.Orange; // revert to correct color (for other unit tests)

			br = Brushes.OrangeRed;
			Assert.True ((br is SolidBrush), "P102#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.OrangeRed, solid.Color, "P102#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P102#3");
			Assert.Equal (Color.Red, (Brushes.OrangeRed as SolidBrush).Color, "P102#4");
			solid.Color = Color.OrangeRed; // revert to correct color (for other unit tests)

			br = Brushes.Orchid;
			Assert.True ((br is SolidBrush), "P103#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Orchid, solid.Color, "P103#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P103#3");
			Assert.Equal (Color.Red, (Brushes.Orchid as SolidBrush).Color, "P103#4");
			solid.Color = Color.Orchid; // revert to correct color (for other unit tests)

			br = Brushes.PaleGoldenrod;
			Assert.True ((br is SolidBrush), "P104#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PaleGoldenrod, solid.Color, "P104#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P104#3");
			Assert.Equal (Color.Red, (Brushes.PaleGoldenrod as SolidBrush).Color, "P104#4");
			solid.Color = Color.PaleGoldenrod; // revert to correct color (for other unit tests)

			br = Brushes.PaleGreen;
			Assert.True ((br is SolidBrush), "P105#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PaleGreen, solid.Color, "P105#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P105#3");
			Assert.Equal (Color.Red, (Brushes.PaleGreen as SolidBrush).Color, "P105#4");
			solid.Color = Color.PaleGreen; // revert to correct color (for other unit tests)

			br = Brushes.PaleTurquoise;
			Assert.True ((br is SolidBrush), "P106#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PaleTurquoise, solid.Color, "P106#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P106#3");
			Assert.Equal (Color.Red, (Brushes.PaleTurquoise as SolidBrush).Color, "P106#4");
			solid.Color = Color.PaleTurquoise; // revert to correct color (for other unit tests)

			br = Brushes.PaleVioletRed;
			Assert.True ((br is SolidBrush), "P107#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PaleVioletRed, solid.Color, "P107#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P107#3");
			Assert.Equal (Color.Red, (Brushes.PaleVioletRed as SolidBrush).Color, "P107#4");
			solid.Color = Color.PaleVioletRed; // revert to correct color (for other unit tests)

			br = Brushes.PapayaWhip;
			Assert.True ((br is SolidBrush), "P108#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PapayaWhip, solid.Color, "P108#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P108#3");
			Assert.Equal (Color.Red, (Brushes.PapayaWhip as SolidBrush).Color, "P108#4");
			solid.Color = Color.PapayaWhip; // revert to correct color (for other unit tests)

			br = Brushes.PeachPuff;
			Assert.True ((br is SolidBrush), "P109#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PeachPuff, solid.Color, "P109#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P109#3");
			Assert.Equal (Color.Red, (Brushes.PeachPuff as SolidBrush).Color, "P109#4");
			solid.Color = Color.PeachPuff; // revert to correct color (for other unit tests)

			br = Brushes.Peru;
			Assert.True ((br is SolidBrush), "P110#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Peru, solid.Color, "P110#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P110#3");
			Assert.Equal (Color.Red, (Brushes.Peru as SolidBrush).Color, "P110#4");
			solid.Color = Color.Peru; // revert to correct color (for other unit tests)

			br = Brushes.Pink;
			Assert.True ((br is SolidBrush), "P111#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Pink, solid.Color, "P111#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P111#3");
			Assert.Equal (Color.Red, (Brushes.Pink as SolidBrush).Color, "P111#4");
			solid.Color = Color.Pink; // revert to correct color (for other unit tests)

			br = Brushes.Plum;
			Assert.True ((br is SolidBrush), "P112#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Plum, solid.Color, "P112#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P112#3");
			Assert.Equal (Color.Red, (Brushes.Plum as SolidBrush).Color, "P112#4");
			solid.Color = Color.Plum; // revert to correct color (for other unit tests)

			br = Brushes.PowderBlue;
			Assert.True ((br is SolidBrush), "P113#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.PowderBlue, solid.Color, "P113#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P113#3");
			Assert.Equal (Color.Red, (Brushes.PowderBlue as SolidBrush).Color, "P113#4");
			solid.Color = Color.PowderBlue; // revert to correct color (for other unit tests)

			br = Brushes.Purple;
			Assert.True ((br is SolidBrush), "P114#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Purple, solid.Color, "P114#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P114#3");
			Assert.Equal (Color.Red, (Brushes.Purple as SolidBrush).Color, "P114#4");
			solid.Color = Color.Purple; // revert to correct color (for other unit tests)

			br = Brushes.Red;
			Assert.True ((br is SolidBrush), "P115#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Red, solid.Color, "P115#2");
			solid.Color = Color.White;
			Assert.Equal (Color.White, solid.Color, "P115#3");
			Assert.Equal (Color.White, (Brushes.Red as SolidBrush).Color, "P115#4");
			solid.Color = Color.Red; // revert to correct color (for other unit tests)

			br = Brushes.RosyBrown;
			Assert.True ((br is SolidBrush), "P116#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.RosyBrown, solid.Color, "P116#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P116#3");
			Assert.Equal (Color.Red, (Brushes.RosyBrown as SolidBrush).Color, "P116#4");
			solid.Color = Color.RosyBrown; // revert to correct color (for other unit tests)

			br = Brushes.RoyalBlue;
			Assert.True ((br is SolidBrush), "P117#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.RoyalBlue, solid.Color, "P117#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P117#3");
			Assert.Equal (Color.Red, (Brushes.RoyalBlue as SolidBrush).Color, "P117#4");
			solid.Color = Color.RoyalBlue; // revert to correct color (for other unit tests)

			br = Brushes.SaddleBrown;
			Assert.True ((br is SolidBrush), "P118#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SaddleBrown, solid.Color, "P118#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P118#3");
			Assert.Equal (Color.Red, (Brushes.SaddleBrown as SolidBrush).Color, "P118#4");
			solid.Color = Color.SaddleBrown; // revert to correct color (for other unit tests)

			br = Brushes.Salmon;
			Assert.True ((br is SolidBrush), "P119#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Salmon, solid.Color, "P119#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P119#3");
			Assert.Equal (Color.Red, (Brushes.Salmon as SolidBrush).Color, "P119#4");
			solid.Color = Color.Salmon; // revert to correct color (for other unit tests)

			br = Brushes.SandyBrown;
			Assert.True ((br is SolidBrush), "P120#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SandyBrown, solid.Color, "P120#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P120#3");
			Assert.Equal (Color.Red, (Brushes.SandyBrown as SolidBrush).Color, "P120#4");
			solid.Color = Color.SandyBrown; // revert to correct color (for other unit tests)

			br = Brushes.SeaGreen;
			Assert.True ((br is SolidBrush), "P121#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SeaGreen, solid.Color, "P121#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P121#3");
			Assert.Equal (Color.Red, (Brushes.SeaGreen as SolidBrush).Color, "P121#4");
			solid.Color = Color.SeaGreen; // revert to correct color (for other unit tests)

			br = Brushes.SeaShell;
			Assert.True ((br is SolidBrush), "P122#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SeaShell, solid.Color, "P122#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P122#3");
			Assert.Equal (Color.Red, (Brushes.SeaShell as SolidBrush).Color, "P122#4");
			solid.Color = Color.SeaShell; // revert to correct color (for other unit tests)

			br = Brushes.Sienna;
			Assert.True ((br is SolidBrush), "P123#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Sienna, solid.Color, "P123#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P123#3");
			Assert.Equal (Color.Red, (Brushes.Sienna as SolidBrush).Color, "P123#4");
			solid.Color = Color.Sienna; // revert to correct color (for other unit tests)

			br = Brushes.Silver;
			Assert.True ((br is SolidBrush), "P124#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Silver, solid.Color, "P124#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P124#3");
			Assert.Equal (Color.Red, (Brushes.Silver as SolidBrush).Color, "P124#4");
			solid.Color = Color.Silver; // revert to correct color (for other unit tests)

			br = Brushes.SkyBlue;
			Assert.True ((br is SolidBrush), "P125#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SkyBlue, solid.Color, "P125#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P125#3");
			Assert.Equal (Color.Red, (Brushes.SkyBlue as SolidBrush).Color, "P125#4");
			solid.Color = Color.SkyBlue; // revert to correct color (for other unit tests)

			br = Brushes.SlateBlue;
			Assert.True ((br is SolidBrush), "P126#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SlateBlue, solid.Color, "P126#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P126#3");
			Assert.Equal (Color.Red, (Brushes.SlateBlue as SolidBrush).Color, "P126#4");
			solid.Color = Color.SlateBlue; // revert to correct color (for other unit tests)

			br = Brushes.SlateGray;
			Assert.True ((br is SolidBrush), "P127#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SlateGray, solid.Color, "P127#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P127#3");
			Assert.Equal (Color.Red, (Brushes.SlateGray as SolidBrush).Color, "P127#4");
			solid.Color = Color.SlateGray; // revert to correct color (for other unit tests)

			br = Brushes.Snow;
			Assert.True ((br is SolidBrush), "P128#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Snow, solid.Color, "P128#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P128#3");
			Assert.Equal (Color.Red, (Brushes.Snow as SolidBrush).Color, "P128#4");
			solid.Color = Color.Snow; // revert to correct color (for other unit tests)

			br = Brushes.SpringGreen;
			Assert.True ((br is SolidBrush), "P129#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SpringGreen, solid.Color, "P129#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P129#3");
			Assert.Equal (Color.Red, (Brushes.SpringGreen as SolidBrush).Color, "P129#4");
			solid.Color = Color.SpringGreen; // revert to correct color (for other unit tests)

			br = Brushes.SteelBlue;
			Assert.True ((br is SolidBrush), "P130#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.SteelBlue, solid.Color, "P130#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P130#3");
			Assert.Equal (Color.Red, (Brushes.SteelBlue as SolidBrush).Color, "P130#4");
			solid.Color = Color.SteelBlue; // revert to correct color (for other unit tests)

			br = Brushes.Tan;
			Assert.True ((br is SolidBrush), "P131#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Tan, solid.Color, "P131#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P131#3");
			Assert.Equal (Color.Red, (Brushes.Tan as SolidBrush).Color, "P131#4");
			solid.Color = Color.Tan; // revert to correct color (for other unit tests)

			br = Brushes.Teal;
			Assert.True ((br is SolidBrush), "P132#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Teal, solid.Color, "P132#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P132#3");
			Assert.Equal (Color.Red, (Brushes.Teal as SolidBrush).Color, "P132#4");
			solid.Color = Color.Teal; // revert to correct color (for other unit tests)

			br = Brushes.Thistle;
			Assert.True ((br is SolidBrush), "P133#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Thistle, solid.Color, "P133#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P133#3");
			Assert.Equal (Color.Red, (Brushes.Thistle as SolidBrush).Color, "P133#4");
			solid.Color = Color.Thistle; // revert to correct color (for other unit tests)

			br = Brushes.Tomato;
			Assert.True ((br is SolidBrush), "P134#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Tomato, solid.Color, "P134#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P134#3");
			Assert.Equal (Color.Red, (Brushes.Tomato as SolidBrush).Color, "P134#4");
			solid.Color = Color.Tomato; // revert to correct color (for other unit tests)

			br = Brushes.Turquoise;
			Assert.True ((br is SolidBrush), "P135#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Turquoise, solid.Color, "P135#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P135#3");
			Assert.Equal (Color.Red, (Brushes.Turquoise as SolidBrush).Color, "P135#4");
			solid.Color = Color.Turquoise; // revert to correct color (for other unit tests)

			br = Brushes.Violet;
			Assert.True ((br is SolidBrush), "P136#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Violet, solid.Color, "P136#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P136#3");
			Assert.Equal (Color.Red, (Brushes.Violet as SolidBrush).Color, "P136#4");
			solid.Color = Color.Violet; // revert to correct color (for other unit tests)

			br = Brushes.Wheat;
			Assert.True ((br is SolidBrush), "P137#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Wheat, solid.Color, "P137#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P137#3");
			Assert.Equal (Color.Red, (Brushes.Wheat as SolidBrush).Color, "P137#4");
			solid.Color = Color.Wheat; // revert to correct color (for other unit tests)

			br = Brushes.White;
			Assert.True ((br is SolidBrush), "P138#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.White, solid.Color, "P138#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P138#3");
			Assert.Equal (Color.Red, (Brushes.White as SolidBrush).Color, "P138#4");
			solid.Color = Color.White; // revert to correct color (for other unit tests)

			br = Brushes.WhiteSmoke;
			Assert.True ((br is SolidBrush), "P139#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.WhiteSmoke, solid.Color, "P139#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P139#3");
			Assert.Equal (Color.Red, (Brushes.WhiteSmoke as SolidBrush).Color, "P139#4");
			solid.Color = Color.WhiteSmoke; // revert to correct color (for other unit tests)

			br = Brushes.Yellow;
			Assert.True ((br is SolidBrush), "P140#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.Yellow, solid.Color, "P140#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P140#3");
			Assert.Equal (Color.Red, (Brushes.Yellow as SolidBrush).Color, "P140#4");
			solid.Color = Color.Yellow; // revert to correct color (for other unit tests)

			/* YellowGreen is broken by "destructive" Dispose test
			br = Brushes.YellowGreen;
			Assert.True ((br is SolidBrush), "P141#1");
			solid = (SolidBrush) br;
			Assert.Equal (Color.YellowGreen, solid.Color, "P141#2");
			solid.Color = Color.Red;
			Assert.Equal (Color.Red, solid.Color, "P141#3");
			Assert.Equal (Color.Red, (Brushes.YellowGreen as SolidBrush).Color, "P141#4");
			solid.Color = Color.YellowGreen; // revert to correct color (for other unit tests)
			*/
		}
	}
}

// Following code was used to generate the TestProperties method.
/*
using System;
using System.Drawing;
using System.Reflection;
class Program {
	static void Main ()
	{
		Type type = typeof (Brushes);
		PropertyInfo[] properties = type.GetProperties ();
		int count = 1;
		foreach (PropertyInfo property in properties) {
			Console.WriteLine("\n\t\t\tbr = Brushes." + property.Name + ";");
			Console.WriteLine("\t\t\tAssert.True ((br is SolidBrush), \"P" + count + "#1\");");
			Console.WriteLine("\t\t\tsolid = (SolidBrush) br;");
			Console.WriteLine("\t\t\tAssert.Equal (Color." + property.Name + ", solid.Color, \"P" + count + "#2\");");

			if (property.Name != "Red") {
				Console.WriteLine("\t\t\tsolid.Color = Color.Red;");
				Console.WriteLine("\t\t\tAssert.Equal (Color.Red, solid.Color, \"P" + count + "#3\");");
				Console.WriteLine("\t\t\tAssert.Equal (Color.Red, (Brushes." + property.Name + " as SolidBrush).Color, \"P" + count + "#4\");");
			} else {
				Console.WriteLine("\t\t\tsolid.Color = Color.White;");
				Console.WriteLine("\t\t\tAssert.Equal (Color.White, solid.Color, \"P" + count + "#3\");");
				Console.WriteLine("\t\t\tAssert.Equal (Color.White, (Brushes." + property.Name + " as SolidBrush).Color, \"P" + count + "#4\");");
			}
			Console.WriteLine("\t\t\tsolid.Color = Color." + property.Name + "; // revert to correct color (for other unit tests)");
			count++;
		}
	}
}
 */

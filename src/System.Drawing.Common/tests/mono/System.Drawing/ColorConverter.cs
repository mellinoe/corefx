//
// ColorConverter class testing unit
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Security.Permissions;

using Xunit;

namespace MonoTests.System.Drawing {

	[TestFixture]
	public class ColorConverterTest {

		Color col;
		Color colnamed;
		ColorConverter colconv;
		String colStr;
		String colStrInvariant;
		String colnamedStr;

		[SetUp]
		public void SetUp () {
			col = Color.FromArgb (10, 20, 30);
			colStr = string.Format ("10{0} 20{0} 30", CultureInfo.CurrentCulture.TextInfo.ListSeparator);
			colStrInvariant = string.Format ("10{0} 20{0} 30", CultureInfo.InvariantCulture.TextInfo.ListSeparator);

			colnamed = Color.ForestGreen;
			colnamedStr = "ForestGreen";

			colconv = (ColorConverter) TypeDescriptor.GetConverter (col);
		}

		[Fact]
		public void CanConvertFrom () {
			Assert.True (colconv.CanConvertFrom (typeof (String)), "CCF#1");
			Assert.True (colconv.CanConvertFrom (null, typeof (String)), "CCF#1a");
			Assert.False (colconv.CanConvertFrom (null, typeof (Rectangle)), "CCF#2");
			Assert.False (colconv.CanConvertFrom (null, typeof (RectangleF)), "CCF#3");
			Assert.False (colconv.CanConvertFrom (null, typeof (Point)), "CCF#4");
			Assert.False (colconv.CanConvertFrom (null, typeof (PointF)), "CCF#5");
			Assert.False (colconv.CanConvertFrom (null, typeof (Color)), "CCF#6");
			Assert.False (colconv.CanConvertFrom (null, typeof (SizeF)), "CCF#7");
			Assert.False (colconv.CanConvertFrom (null, typeof (Object)), "CCF#8");
			Assert.False ( colconv.CanConvertFrom (null, typeof (int)), "CCF#9");
			Assert.True (colconv.CanConvertFrom (null, typeof (InstanceDescriptor)), "CCF#10");
		}

		[Fact]
		public void CanConvertTo () {
			Assert.True (colconv.CanConvertTo (typeof (String)), "CCT#1");
			Assert.True (colconv.CanConvertTo (null, typeof (String)), "CCT#1a");
			Assert.False (colconv.CanConvertTo (null, typeof (Rectangle)), "CCT#2");
			Assert.False (colconv.CanConvertTo (null, typeof (RectangleF)), "CCT#3");
			Assert.False (colconv.CanConvertTo (null, typeof (Point)), "CCT#4");
			Assert.False (colconv.CanConvertTo (null, typeof (PointF)), "CCT#5");
			Assert.False (colconv.CanConvertTo (null, typeof (Color)), "CCT#6");
			Assert.False (colconv.CanConvertTo (null, typeof (SizeF)), "CCT#7");
			Assert.False (colconv.CanConvertTo (null, typeof (Object)), "CCT#8");
			Assert.False (colconv.CanConvertTo (null, typeof (int)), "CCT#9");
			Assert.True (colconv.CanConvertTo (typeof (InstanceDescriptor)), "CCT#10");
		}

		[Fact]
		public void ConvertFrom ()
		{
			Color color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"#0x23190A44");
			Assert.Equal (35, color.A, "CF1#1");
			Assert.Equal (25, color.R, "CF1#2");
			Assert.Equal (10, color.G, "CF1#3");
			Assert.Equal (68, color.B, "CF1#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"#0X190A44");
			Assert.Equal (0, color.A, "CF2#1");
			Assert.Equal (25, color.R, "CF2#2");
			Assert.Equal (10, color.G, "CF2#3");
			Assert.Equal (68, color.B, "CF2#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"0x190A44");
			Assert.Equal (255, color.A, "CF3#1");
			Assert.Equal (25, color.R, "CF3#2");
			Assert.Equal (10, color.G, "CF3#3");
			Assert.Equal (68, color.B, "CF3#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"0X190A44");
			Assert.Equal (255, color.A, "CF4#1");
			Assert.Equal (25, color.R, "CF4#2");
			Assert.Equal (10, color.G, "CF4#3");
			Assert.Equal (68, color.B, "CF4#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"111111");
			Assert.Equal (0, color.A, "CF5#1");
			Assert.Equal (1, color.R, "CF5#2");
			Assert.Equal (178, color.G, "CF5#3");
			Assert.Equal (7, color.B, "CF5#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"10");
			Assert.Equal (0, color.A, "CF6#1");
			Assert.Equal (0, color.R, "CF6#2");
			Assert.Equal (0, color.G, "CF6#3");
			Assert.Equal (10, color.B, "CF6#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"0");
			Assert.Equal (0, color.A, "CF7#1");
			Assert.Equal (0, color.R, "CF7#2");
			Assert.Equal (0, color.G, "CF7#3");
			Assert.Equal (0, color.B, "CF7#4");


			Assert.Equal (col, (Color) colconv.ConvertFrom (null,
				CultureInfo.InvariantCulture, colStrInvariant), "CF#1");
			Assert.Equal (colnamed, (Color) colconv.ConvertFrom (null,
				CultureInfo.InvariantCulture, colnamedStr), "CF#2");

			Assert.Equal (Color.Empty, colconv.ConvertFrom (string.Empty), "CF#3");
			Assert.Equal (Color.Empty, colconv.ConvertFrom (" "), "CF#4");
			Assert.Equal (Color.Red, colconv.ConvertFrom ("Red"), "CF#5");
			Assert.Equal (Color.Red, colconv.ConvertFrom (" Red "), "CF#6");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"0x123");
			Assert.Equal (0, color.A, "CF8#1");
			Assert.Equal (0, color.R, "CF8#2");
			Assert.Equal (1, color.G, "CF8#3");
			Assert.Equal (35, color.B, "CF8#4");

			color = (Color) colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"#123");
			Assert.Equal (0, color.A, "CF9#1");
			Assert.Equal (0, color.R, "CF9#2");
			Assert.Equal (1, color.G, "CF9#3");
			Assert.Equal (35, color.B, "CF9#4");
		}

		[Fact]
		public void ConvertFrom_x1 ()
		{
			Assert.Throws<ArgumentException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture, "10, 20"));
		}

		[Fact]
		public void ConvertFrom_x2 ()
		{
			Assert.Throws<ArgumentException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture, "-10, 20, 30"));
		}

		[Fact]
		public void ConvertFrom_x3 ()
		{
			Assert.Throws<ArgumentException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
					"1, 1, 1, 1, 1"));
		}

		[Fact]
		public void ConvertFrom_x4 ()
		{
			Assert.Throws<Exception> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
				"*1, 1"));
		}

		[Fact]
		public void ConvertFrom_x5 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
					new Point (10, 10)));
		}

		[Fact]
		public void ConvertFrom_x6 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
					new PointF (10, 10)));
		}

		[Fact]
		public void ConvertFrom_x7 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
					new Size (10, 10)));
		}

		[Fact]
		public void ConvertFrom_x8 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture,
					new SizeF (10, 10)));
		}

		[Fact]
		public void ConvertFrom_x9 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertFrom (null, CultureInfo.InvariantCulture, 0x10));
		}

		[Fact]
		public void ConvertFrom_CultureNull ()
		{
			Color color = (Color) colconv.ConvertFrom (null, null, "#0x23190A44");
			Assert.Equal (35, color.A, "A");
			Assert.Equal (25, color.R, "R");
			Assert.Equal (10, color.G, "G");
			Assert.Equal (68, color.B, "B");
		}

		[Fact]
		public void ConvertTo ()
		{
			Assert.Equal (colStrInvariant, colconv.ConvertTo (null, CultureInfo.InvariantCulture,
				Color.FromArgb (10, 20, 30), typeof (String)), "CT#1");
			Assert.Equal (colStrInvariant, colconv.ConvertTo (null, CultureInfo.InvariantCulture,
				Color.FromArgb (255, 10, 20, 30), typeof (String)), "CT#2");
			Assert.Equal ("10, 20, 30, 40", colconv.ConvertTo (null, CultureInfo.InvariantCulture,
				Color.FromArgb (10, 20, 30, 40), typeof (String)), "CT#3");
			Assert.Equal (colnamedStr, colconv.ConvertTo (null, CultureInfo.InvariantCulture,
				colnamed, typeof (String)), "CT#4");

			Assert.Equal (string.Empty, colconv.ConvertTo (Color.Empty, typeof (string)), "CT#5");
			Assert.Equal ("Red", colconv.ConvertTo (Color.Red, typeof (string)), "CT#6");
			Assert.Equal (string.Empty, colconv.ConvertTo (null, typeof (string)), "CT#7");
			Assert.Equal ("test", colconv.ConvertTo ("test", typeof (string)), "CT#8");
		}

		[Fact]
		public void ConvertTo_x1 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertTo (null, CultureInfo.InvariantCulture, col,
					typeof (Color)));
		}

		[Fact]
		public void ConvertTo_x2 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertTo (null, CultureInfo.InvariantCulture, col,
					typeof (SizeF)));
		}

		[Fact]
		public void ConvertTo_x3 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertTo (null, CultureInfo.InvariantCulture, col,
					typeof (Point)));
		}

		[Fact]
		public void ConvertTo_x4 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertTo (null, CultureInfo.InvariantCulture, col,
					typeof (PointF)));
		}

		[Fact]
		public void ConvertTo_x5 ()
		{
			Assert.Throws<NotSupportedException> (() => colconv.ConvertTo (null, CultureInfo.InvariantCulture, col,
					typeof (int)));
		}

		[Fact]
		public void GetCreateInstanceSupported ()
		{
			Assert.True (!colconv.GetCreateInstanceSupported (), "GCIS#1");
			Assert.True (!colconv.GetCreateInstanceSupported (null), "GCIS#2");
		}

		[Fact]
		public void CreateInstance ()
		{
			Hashtable ht = new Hashtable ();
			ht.Add ("R", 10); ht.Add ("G", 20); ht.Add ("B", 30);

			Assert.Equal (null, colconv.CreateInstance (ht), "CI#1");

			ht.Add ("Name", "ForestGreen");

			Assert.Equal (null, colconv.CreateInstance (null, ht), "CI#2");
		}

		[Fact]
		public void GetPropertiesSupported ()
		{
			Assert.True (!colconv.GetPropertiesSupported (), "GPS#1");
			Assert.True (!colconv.GetPropertiesSupported (null), "GPS#2");
		}

		[Fact]
		public void GetProperties ()
		{
			Attribute [] attrs;

			Assert.Equal (null, colconv.GetProperties (col), "GP1#1");

			Assert.Equal (null, colconv.GetProperties (null, col, null), "GP2#1");

			attrs = Attribute.GetCustomAttributes (typeof (Color), true);
			Assert.Equal (null, colconv.GetProperties (null, col, attrs), "GP3#5");
		}

		[Fact]
		public void ConvertFromInvariantString_string ()
		{
			Assert.Equal (col, colconv.ConvertFromInvariantString (colStrInvariant), "CFISS#1");
			Assert.Equal (colnamed, colconv.ConvertFromInvariantString (colnamedStr), "CFISS#2");
		}

		[Fact]
		public void ConvertFromInvariantString_InvalidComponentCount ()
		{
			Assert.Throws<ArgumentException> (() => colconv.ConvertFromInvariantString ("1, 2, 3, 4, 5"));
		}

		[Fact]
		public void ConvertFromInvariantString_InvalidNumber ()
		{
			try {
				colconv.ConvertFromInvariantString ("hello");
				Assert.Fail ("#1");
			} catch (Exception ex) {
				Assert.Equal (typeof (Exception), ex.GetType (), "#2");
				Assert.NotNull (ex.InnerException, "#3");
				Assert.Equal (typeof (FormatException), ex.InnerException.GetType (), "#3");
			}
		}

		[Fact]
		public void ConvertFromString_string ()
		{
			Assert.Equal (col, colconv.ConvertFromString (colStr), "CFSS#1");
			Assert.Equal (colnamed, colconv.ConvertFromString (colnamedStr), "CFSS#2");
		}

		[Fact]
		public void ConvertFromString_InvalidComponentCount ()
		{
			CultureInfo culture = CultureInfo.CurrentCulture;
			Assert.Throws<ArgumentException> (() => colconv.ConvertFromString (string.Format (culture,
				"1{0} 2{0} 3{0} 4{0} 5", culture.TextInfo.ListSeparator[0])));
		}

		[Fact]
		public void ConvertFromString_InvalidNumber ()
		{
			try {
				colconv.ConvertFromString ("hello");
				Assert.Fail ("#1");
			} catch (Exception ex) {
				Assert.Equal (typeof (Exception), ex.GetType (), "#2");
				Assert.NotNull (ex.InnerException, "#3");
				Assert.Equal (typeof (FormatException), ex.InnerException.GetType (), "#3");
			}
		}

		[Fact]
		public void ConvertToInvariantString_string () {
			Assert.Equal (colStrInvariant, colconv.ConvertToInvariantString (col), "CFISS#1");
			Assert.Equal (colnamedStr, colconv.ConvertToInvariantString (colnamed), "CFISS#2");
		}

		[Fact]
		public void ConvertToString_string () {
			Assert.Equal (colStr, colconv.ConvertToString (col), "CFISS#1");
			Assert.Equal (colnamedStr, colconv.ConvertToString (colnamed), "CFISS#3");
		}

		[Fact]
		public void GetStandardValuesSupported () {
			Assert.True (colconv.GetStandardValuesSupported ());
		}

		[Fact]
		public void GetStandardValues () {
			Assert.Equal ((int)KnownColor.MenuHighlight, colconv.GetStandardValues ().Count);
			Assert.Equal ((int)KnownColor.MenuHighlight, colconv.GetStandardValues (null).Count);			
		}

		[Fact]
		public void GetStandardValuesExclusive () {
			Assert.Equal (false, colconv.GetStandardValuesExclusive ());
		}

		[Fact]
		public void ConvertFromString_FromHtml_PoundTooLarge ()
		{
			Assert.Throws<Exception> (() => colconv.ConvertFromString ("#100000000"));
		}
	}
}


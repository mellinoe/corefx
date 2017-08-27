//
// Copyright (C) 2004-2005 Novell, Inc (http://www.novell.com)
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
// Author:
//
//	Jordi Mas i Hernandez, jordimash@gmail.com
//

using Xunit;
using System;
using System.IO;
using System.Drawing.Printing;
using System.Security;
using System.Security.Permissions;

namespace MonoTests.System.Drawing.Printing {

	public class PrinterUnitConvertTest
	{
		static int n = 100, r;

		[Fact]
		public void ConvertFromDisplay ()
		{
			r = PrinterUnitConvert.Convert (n, PrinterUnit.Display,
				PrinterUnit.Display);

			Assert.Equal (100, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.Display,
				PrinterUnit.HundredthsOfAMillimeter);

			Assert.Equal (2540, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.Display,
				PrinterUnit.TenthsOfAMillimeter);

			Assert.Equal (254, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.Display,
				PrinterUnit.ThousandthsOfAnInch);

			Assert.Equal (1000, r);
		}

		[Fact]
		public void ConvertFromHundredthsOfAMillimeter ()
		{
			r = PrinterUnitConvert.Convert (n, PrinterUnit.HundredthsOfAMillimeter,
				PrinterUnit.Display);

			Assert.Equal (4, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.HundredthsOfAMillimeter,
				PrinterUnit.HundredthsOfAMillimeter);

			Assert.Equal (100, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.HundredthsOfAMillimeter,
				PrinterUnit.TenthsOfAMillimeter);

			Assert.Equal (10, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.HundredthsOfAMillimeter,
				PrinterUnit.ThousandthsOfAnInch);

			Assert.Equal (39, r);
		}

		[Fact]
		public void ConvertFromTenthsOfAMillimeter ()
		{
			r = PrinterUnitConvert.Convert (n, PrinterUnit.TenthsOfAMillimeter,
				PrinterUnit.Display);

			Assert.Equal (39, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.TenthsOfAMillimeter,
				PrinterUnit.HundredthsOfAMillimeter);

			Assert.Equal (1000, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.TenthsOfAMillimeter,
				PrinterUnit.TenthsOfAMillimeter);

			Assert.Equal (100, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.TenthsOfAMillimeter,
				PrinterUnit.ThousandthsOfAnInch);

			Assert.Equal (394, r);
		}

		[Fact]
		public void ConvertFromThousandthsOfAnInch ()
		{
			r = PrinterUnitConvert.Convert (n, PrinterUnit.ThousandthsOfAnInch,
				PrinterUnit.Display);

			Assert.Equal (10, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.ThousandthsOfAnInch,
				PrinterUnit.HundredthsOfAMillimeter);

			Assert.Equal (254, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.ThousandthsOfAnInch,
				PrinterUnit.TenthsOfAMillimeter);

			Assert.Equal (25, r);

			r = PrinterUnitConvert.Convert (n, PrinterUnit.ThousandthsOfAnInch,
				PrinterUnit.ThousandthsOfAnInch);

			Assert.Equal (100, r);
		}
	}
}


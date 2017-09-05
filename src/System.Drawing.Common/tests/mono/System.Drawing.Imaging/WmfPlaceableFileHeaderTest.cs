//
// WmfPlaceableFileHeader class testing unit
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Permissions;
using Xunit;

namespace MonoTests.System.Drawing.Imaging {

	public class WmfPlaceableFileHeaderTest {

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void DefaultValues ()
		{
			WmfPlaceableFileHeader wh = new WmfPlaceableFileHeader ();
			Assert.Equal (0, wh.BboxBottom);
			Assert.Equal (0, wh.BboxLeft);
			Assert.Equal (0, wh.BboxRight);
			Assert.Equal (0, wh.BboxTop);
			Assert.Equal (0, wh.Checksum);
			Assert.Equal (0, wh.Hmf);
			Assert.Equal (0, wh.Inch);
			Assert.Equal (unchecked ((int)0x9AC6CDD7), wh.Key); // always (from documentation)
			Assert.Equal (0, wh.Reserved);
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void Min ()
		{
			WmfPlaceableFileHeader wh = new WmfPlaceableFileHeader ();
			wh.BboxBottom = short.MinValue;
			Assert.Equal (short.MinValue, wh.BboxBottom);
			wh.BboxLeft = short.MinValue;
			Assert.Equal (short.MinValue, wh.BboxLeft);
			wh.BboxRight = short.MinValue;
			Assert.Equal (short.MinValue, wh.BboxRight);
			wh.BboxTop = short.MinValue;
			Assert.Equal (short.MinValue, wh.BboxTop);
			wh.Checksum = short.MinValue;
			Assert.Equal (short.MinValue, wh.Checksum);
			wh.Hmf = short.MinValue;
			Assert.Equal (short.MinValue, wh.Hmf);
			wh.Inch = short.MinValue;
			Assert.Equal (short.MinValue, wh.Inch);
			wh.Key = int.MinValue;
			Assert.Equal (int.MinValue, wh.Key);
			wh.Reserved = int.MinValue;
			Assert.Equal (int.MinValue, wh.Reserved);
		}

		[ConditionalFact(Helpers.GdiplusIsAvailable)]
		public void Max ()
		{
			WmfPlaceableFileHeader wh = new WmfPlaceableFileHeader ();
			wh.BboxBottom = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.BboxBottom);
			wh.BboxLeft = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.BboxLeft);
			wh.BboxRight = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.BboxRight);
			wh.BboxTop = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.BboxTop);
			wh.Checksum = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.Checksum);
			wh.Hmf = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.Hmf);
			wh.Inch = short.MaxValue;
			Assert.Equal (short.MaxValue, wh.Inch);
			wh.Key = int.MaxValue;
			Assert.Equal (int.MaxValue, wh.Key);
			wh.Reserved = int.MaxValue;
			Assert.Equal (int.MaxValue, wh.Reserved);
		}
	}
}

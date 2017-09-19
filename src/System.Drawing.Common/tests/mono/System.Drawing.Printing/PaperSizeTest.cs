//
// Copyright (C) 2009 Novell, Inc (http://www.novell.com)
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
// 	Andy Hume <andyhume32@yahoo.co.uk>
//

using Xunit;
using System;
using System.Drawing;
using System.Drawing.Printing;

namespace MonoTests.System.Drawing.Printing
{
    public class PaperSizeTest
    {
        [ConditionalFact(Helpers.GdiplusIsAvailable)]
        public void PaperSizeKindTest()
        {
            // set_RawKind seems to accept any value (no ArgEx seen), but get_Kind 
            // returns "Custom" when it's set to a value bigger than the biggest enum.
            //
            PaperSize ps = new PaperSize("foo", 100, 100);

            //
            // Zero == Custom
            Assert.Equal(PaperKind.Custom, ps.Kind);
            Assert.Equal(0, ps.RawKind);

            try
            {
                ps.Height = 1;
                Assert.Equal(1, ps.Height);
            }
            catch (ArgumentException)
            {
                Assert.True(false);
            }

            //
            // Well-known
            ps.RawKind = (int)PaperKind.A4;
            Assert.Equal(PaperKind.A4, ps.Kind);
            Assert.Equal((int)PaperKind.A4, ps.RawKind);

            try
            {
                ps.Height = 2;
                Assert.True(false);
            }
            catch (ArgumentException)
            {
            }

            //
            ps.RawKind = (int)PaperKind.JapaneseEnvelopeKakuNumber3;
            Assert.Equal(PaperKind.JapaneseEnvelopeKakuNumber3, ps.Kind);
            Assert.Equal((int)PaperKind.JapaneseEnvelopeKakuNumber3, ps.RawKind);

            //
            // Too Big
            ps.RawKind = 999999;
            Assert.Equal(PaperKind.Custom, ps.Kind);
            Assert.Equal(999999, ps.RawKind);

            // The properties can be changed only when the *real* Kind is Custom 
            // and not when is 'effectively' Custom.
            try
            {
                ps.Height = 4;
                Assert.True(false);
            }
            catch (ArgumentException)
            {
            }

            //
            ps.RawKind = int.MaxValue;
            Assert.Equal(PaperKind.Custom, ps.Kind);
            Assert.Equal(int.MaxValue, ps.RawKind);

            //
            // Negative -- Looks as if MSFT forgot to check for negative!
            ps.RawKind = -1;
            Assert.Equal((PaperKind)(-1), ps.Kind);
            Assert.Equal(-1, ps.RawKind);

            //
            ps.RawKind = int.MinValue;
            Assert.Equal((PaperKind)(int.MinValue), ps.Kind);
            Assert.Equal(int.MinValue, ps.RawKind);

            //
            // Where's the top limit?
            ps.RawKind = (int)PaperKind.PrcEnvelopeNumber10Rotated;
            Assert.Equal(PaperKind.PrcEnvelopeNumber10Rotated, ps.Kind);
            Assert.Equal((int)PaperKind.PrcEnvelopeNumber10Rotated, ps.RawKind);

            // +1
            ps.RawKind = 1 + (int)PaperKind.PrcEnvelopeNumber10Rotated;
            Assert.Equal(PaperKind.Custom, ps.Kind);
            Assert.Equal(1 + (int)PaperKind.PrcEnvelopeNumber10Rotated, ps.RawKind);

            try
            {
                ps.Height = 9;
                Assert.True(false);
            }
            catch (ArgumentException)
            {
            }

            // Set Custom
            ps.RawKind = (int)PaperKind.Custom;
            Assert.Equal(PaperKind.Custom, ps.Kind);
            Assert.Equal(0, ps.RawKind);

            try
            {
                ps.Height = 1;
                Assert.Equal(1, ps.Height);
            }
            catch (ArgumentException)
            {
                Assert.True(false);
            }
        }

    }
}


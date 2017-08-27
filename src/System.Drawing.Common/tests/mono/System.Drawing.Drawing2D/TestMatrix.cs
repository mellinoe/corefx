//
// Tests for System.Drawing.Drawing2D.Matrix.cs
//
// Authors:
//	Jordi Mas i Hernandez <jordi@ximian.com>
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc (http://www.novell.com)
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
	public class MatrixTest {

		[Fact]
		public void Constructor_Default ()
		{
			Matrix matrix = new Matrix ();
			Assert.Equal (6, matrix.Elements.Length, "C#1");
		}

		[Fact]
		public void Constructor_SixFloats ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			Assert.Equal (6, matrix.Elements.Length, "C#2");
			Assert.Equal (10, matrix.Elements[0], "C#3");
			Assert.Equal (20, matrix.Elements[1], "C#4");
			Assert.Equal (30, matrix.Elements[2], "C#5");
			Assert.Equal (40, matrix.Elements[3], "C#6");
			Assert.Equal (50, matrix.Elements[4], "C#7");
			Assert.Equal (60, matrix.Elements[5], "C#8");
		}

		[Fact]
		public void Constructor_Float ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			Assert.Equal (6, matrix.Elements.Length, "C#2");
			Assert.Equal (10, matrix.Elements[0], "C#3");
			Assert.Equal (20, matrix.Elements[1], "C#4");
			Assert.Equal (30, matrix.Elements[2], "C#5");
			Assert.Equal (40, matrix.Elements[3], "C#6");
			Assert.Equal (50, matrix.Elements[4], "C#7");
			Assert.Equal (60, matrix.Elements[5], "C#8");
		}

		[Fact]
		public void Constructor_Int_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix (default (Rectangle), null));
		}

		[Fact]
		public void Constructor_Int_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix (default (Rectangle), new Point[0]));
		}

		[Fact]
		public void Constructor_Int_4Point ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix (default (Rectangle), new Point[4]));
		}

		[Fact]
		public void Constructor_Rect_Point ()
		{
			Rectangle r = new Rectangle (100, 200, 300, 400);
			Matrix m = new Matrix (r, new Point[3] { new Point (10, 20), new Point (30, 40), new Point (50, 60) });
			float[] elements = m.Elements;
			Assert.Equal (0.06666666, elements[0], 0.00001, "0");
			Assert.Equal (0.06666666, elements[1], 0.00001, "1");
			Assert.Equal (0.09999999, elements[2], 0.00001, "2");
			Assert.Equal (0.09999999, elements[3], 0.00001, "3");
			Assert.Equal (-16.6666679, elements[4], 0.00001, "4");
			Assert.Equal (-6.666667, elements[5], 0.00001, "5");
		}

		[Fact]
		public void Constructor_Float_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix (default (RectangleF), null));
		}

		[Fact]
		public void Constructor_Float_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix (default (RectangleF), new PointF[0]));
		}

		[Fact]
		public void Constructor_Float_2PointF ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix (default (RectangleF), new PointF[2]));
		}

		[Fact]
		public void Constructor_RectF_PointF ()
		{
			RectangleF r = new RectangleF (100, 200, 300, 400);
			Matrix m = new Matrix (r, new PointF[3] { new PointF (10, 20), new PointF (30, 40), new PointF (50, 60) });
			float[] elements = m.Elements;
			Assert.Equal (0.06666666, elements[0], 0.00001, "0");
			Assert.Equal (0.06666666, elements[1], 0.00001, "1");
			Assert.Equal (0.09999999, elements[2], 0.00001, "2");
			Assert.Equal (0.09999999, elements[3], 0.00001, "3");
			Assert.Equal (-16.6666679, elements[4], 0.00001, "4");
			Assert.Equal (-6.666667, elements[5], 0.00001, "5");
		}

		// Properties

		[Fact]
		public void Invertible ()
		{
			Matrix matrix = new Matrix (123, 24, 82, 16, 47, 30);
			Assert.Equal (false, matrix.IsInvertible, "I#1");

			matrix = new Matrix (156, 46, 0, 0, 106, 19);
			Assert.Equal (false, matrix.IsInvertible, "I#2");

			matrix = new Matrix (146, 66, 158, 104, 42, 150);
			Assert.Equal (true, matrix.IsInvertible, "I#3");

			matrix = new Matrix (119, 140, 145, 74, 102, 58);
			Assert.Equal (true, matrix.IsInvertible, "I#4");
		}
		
		[Fact]
		public void IsIdentity ()
		{
			Matrix identity = new Matrix ();
			Matrix matrix = new Matrix (123, 24, 82, 16, 47, 30);
			Assert.Equal (false, matrix.IsIdentity, "N#1-identity");
			Assert.True (!identity.Equals (matrix), "N#1-equals");
			
			matrix = new Matrix (1, 0, 0, 1, 0, 0);
			Assert.Equal (true, matrix.IsIdentity, "N#2-identity");
			Assert.True (identity.Equals (matrix), "N#2-equals");

			// so what's the required precision ?

			matrix = new Matrix (1.1f, 0.1f, -0.1f, 0.9f, 0, 0);
			Assert.True (!matrix.IsIdentity, "N#3-identity");
			Assert.True (!identity.Equals (matrix), "N#3-equals");

			matrix = new Matrix (1.01f, 0.01f, -0.01f, 0.99f, 0, 0);
			Assert.True (!matrix.IsIdentity, "N#4-identity");
			Assert.True (!identity.Equals (matrix), "N#4-equals");

			matrix = new Matrix (1.001f, 0.001f, -0.001f, 0.999f, 0, 0);
			Assert.True (!matrix.IsIdentity, "N#5-identity");
			Assert.True (!identity.Equals (matrix), "N#5-equals");

			matrix = new Matrix (1.0001f, 0.0001f, -0.0001f, 0.9999f, 0, 0);
			Assert.True (matrix.IsIdentity, "N#6-identity");
			// note: NOT equal
			Assert.True (!identity.Equals (matrix), "N#6-equals");

			matrix = new Matrix (1.0009f, 0.0009f, -0.0009f, 0.99995f, 0, 0);
			Assert.True (!matrix.IsIdentity, "N#7-identity");
			Assert.True (!identity.Equals (matrix), "N#7-equals");
		}
		
		[Fact]
		public void IsOffsetX ()
		{
			Matrix matrix = new Matrix (123, 24, 82, 16, 47, 30);
			Assert.Equal (47, matrix.OffsetX, "X#1");
		}
		
		[Fact]
		public void IsOffsetY ()
		{
			Matrix matrix = new Matrix (123, 24, 82, 16, 47, 30);
			Assert.Equal (30, matrix.OffsetY, "Y#1");
		}
		
		// Elements Property is checked implicity in other test

		//
		// Methods
		//
		

		[Fact]
		public void Clone ()
		{
			Matrix matsrc = new Matrix (10, 20, 30, 40, 50, 60);
			Matrix matrix  = matsrc.Clone ();

			Assert.Equal (6, matrix.Elements.Length, "D#1");
			Assert.Equal (10, matrix.Elements[0], "D#2");
			Assert.Equal (20, matrix.Elements[1], "D#3");
			Assert.Equal (30, matrix.Elements[2], "D#4");
			Assert.Equal (40, matrix.Elements[3], "D#5");
			Assert.Equal (50, matrix.Elements[4], "D#6");
			Assert.Equal (60, matrix.Elements[5], "D#7");
		}

		[Fact]
		public void HashCode ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			Matrix clone = matrix.Clone ();
			Assert.True (matrix.GetHashCode () != clone.GetHashCode (), "HashCode/Clone");

			Matrix matrix2 = new Matrix (10, 20, 30, 40, 50, 60);
			Assert.True (matrix.GetHashCode () != matrix2.GetHashCode (), "HashCode/Identical");
		}

		[Fact]
		public void Reset ()
		{
			Matrix matrix = new Matrix (51, 52, 53, 54, 55, 56);
			matrix.Reset ();

			Assert.Equal (6, matrix.Elements.Length, "F#1");
			Assert.Equal (1, matrix.Elements[0], "F#2");
			Assert.Equal (0, matrix.Elements[1], "F#3");
			Assert.Equal (0, matrix.Elements[2], "F#4");
			Assert.Equal (1, matrix.Elements[3], "F#5");
			Assert.Equal (0, matrix.Elements[4], "F#6");
			Assert.Equal (0, matrix.Elements[5], "F#7");
		}

		[Fact]
		public void Rotate ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Rotate (180);

			Assert.Equal (-10.0f, matrix.Elements[0], 0.0001, "H#1");
			Assert.Equal (-20, matrix.Elements[1], 0.0001, "H#2");
			Assert.Equal (-30.0000019f, matrix.Elements[2], 0.0001, "H#3");
			Assert.Equal (-40.0000038f, matrix.Elements[3], 0.0001, "H#4");
			Assert.Equal (50, matrix.Elements[4], "H#5");
			Assert.Equal (60, matrix.Elements[5], "H#6");
		}

		[Fact]
		public void Rotate_45_135 ()
		{
			Matrix matrix = new Matrix ();
			Assert.True (matrix.IsIdentity, "original.IsIdentity");

			matrix.Rotate (45);
			Assert.True (!matrix.IsIdentity, "+45.!IsIdentity");
			float[] elements = matrix.Elements;
			Assert.Equal (0.707106769f, elements[0], 0.0001, "45#1");
			Assert.Equal (0.707106769f, elements[1], 0.0001, "45#2");
			Assert.Equal (-0.707106829f, elements[2], 0.0001, "45#3");
			Assert.Equal (0.707106769f, elements[3], 0.0001, "45#4");
			Assert.Equal (0, elements[4], 0.001f, "45#5");
			Assert.Equal (0, elements[5], 0.001f, "45#6");

			matrix.Rotate (135);
			Assert.True (!matrix.IsIdentity, "+135.!IsIdentity");
			elements = matrix.Elements;
			Assert.Equal (-1, elements[0], 0.0001, "180#1");
			Assert.Equal (0, elements[1], 0.0001, "180#2");
			Assert.Equal (0, elements[2], 0.0001, "180#3");
			Assert.Equal (-1, elements[3], 0.0001, "180#4");
			Assert.Equal (0, elements[4], "180#5");
			Assert.Equal (0, elements[5], "180#6");
		}

		[Fact]
		public void Rotate_90_270_Matrix ()
		{
			Matrix matrix = new Matrix ();
			Assert.True (matrix.IsIdentity, "original.IsIdentity");

			matrix.Rotate (90);
			Assert.True (!matrix.IsIdentity, "+90.!IsIdentity");
			float[] elements = matrix.Elements;
			Assert.Equal (0, elements[0], 0.0001, "90#1");
			Assert.Equal (1, elements[1], 0.0001, "90#2");
			Assert.Equal (-1, elements[2], 0.0001, "90#3");
			Assert.Equal (0, elements[3], 0.0001, "90#4");
			Assert.Equal (0, elements[4], "90#5");
			Assert.Equal (0, elements[5], "90#6");

			matrix.Rotate (270);
			// this isn't a perfect 1, 0, 0, 1, 0, 0 matrix - but close enough
			Assert.True (matrix.IsIdentity, "360.IsIdentity");
			Assert.True (!new Matrix ().Equals (matrix), "360.Equals");
		}

		[Fact]
		public void Rotate_InvalidOrder ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().Rotate (180, (MatrixOrder) Int32.MinValue));
		}

		[Fact]
		public void RotateAt ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.RotateAt (180, new PointF (10, 10));

			Assert.Equal (-10, matrix.Elements[0], 0.01, "I#1");
			Assert.Equal (-20, matrix.Elements[1], 0.01, "I#2");
			Assert.Equal (-30, matrix.Elements[2], 0.01, "I#3");
			Assert.Equal (-40, matrix.Elements[3], 0.01, "I#4");
			Assert.Equal (850, matrix.Elements[4], 0.01, "I#5");
			Assert.Equal (1260, matrix.Elements[5], 0.01, "I#6");
		}

		[Fact]
		public void RotateAt_InvalidOrder ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().RotateAt (180, new PointF (10, 10), (MatrixOrder) Int32.MinValue));
		}

		[Fact]
		public void Multiply_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix (10, 20, 30, 40, 50, 60).Multiply (null));
		}

		[Fact]
		public void Multiply ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Multiply (new Matrix (10, 20, 30, 40, 50, 60));

			Assert.Equal (700, matrix.Elements[0], "J#1");
			Assert.Equal (1000, matrix.Elements[1], "J#2");
			Assert.Equal (1500, matrix.Elements[2], "J#3");
			Assert.Equal (2200, matrix.Elements[3], "J#4");
			Assert.Equal (2350, matrix.Elements[4], "J#5");
			Assert.Equal (3460, matrix.Elements[5], "J#6");
		}

		[Fact]
		public void Multiply_Null_Order ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix (10, 20, 30, 40, 50, 60).Multiply (null, MatrixOrder.Append));
		}

		[Fact]
		public void Multiply_Append ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Multiply (new Matrix (10, 20, 30, 40, 50, 60), MatrixOrder.Append);

			Assert.Equal (700, matrix.Elements[0], "J#1");
			Assert.Equal (1000, matrix.Elements[1], "J#2");
			Assert.Equal (1500, matrix.Elements[2], "J#3");
			Assert.Equal (2200, matrix.Elements[3], "J#4");
			Assert.Equal (2350, matrix.Elements[4], "J#5");
			Assert.Equal (3460, matrix.Elements[5], "J#6");
		}

		[Fact]
		public void Multiply_Prepend ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Multiply (new Matrix (10, 20, 30, 40, 50, 60), MatrixOrder.Prepend);

			Assert.Equal (700, matrix.Elements[0], "J#1");
			Assert.Equal (1000, matrix.Elements[1], "J#2");
			Assert.Equal (1500, matrix.Elements[2], "J#3");
			Assert.Equal (2200, matrix.Elements[3], "J#4");
			Assert.Equal (2350, matrix.Elements[4], "J#5");
			Assert.Equal (3460, matrix.Elements[5], "J#6");
		}

		[Fact]
		public void Multiply_InvalidOrder ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			Assert.Throws<ArgumentException> (() => matrix.Multiply (new Matrix (10, 20, 30, 40, 50, 60), (MatrixOrder)Int32.MinValue));
		}

		[Fact]
		public void Equals ()
		{
			Matrix mat1 = new Matrix (10, 20, 30, 40, 50, 60);
			Matrix mat2 = new Matrix (10, 20, 30, 40, 50, 60);
			Matrix mat3 = new Matrix (10, 20, 30, 40, 50, 10);

			Assert.Equal (true, mat1.Equals (mat2), "E#1");
			Assert.Equal (false, mat2.Equals (mat3), "E#2");
			Assert.Equal (false, mat1.Equals (mat3), "E#3");
		}
		
		[Fact]
		public void Invert ()
		{
			Matrix matrix = new Matrix (1, 2, 3, 4, 5, 6);
			matrix.Invert ();
			
			Assert.Equal (-2, matrix.Elements[0], "V#1");
			Assert.Equal (1, matrix.Elements[1], "V#2");
			Assert.Equal (1.5, matrix.Elements[2], "V#3");
			Assert.Equal (-0.5, matrix.Elements[3], "V#4");
			Assert.Equal (1, matrix.Elements[4], "V#5");
			Assert.Equal (-2, matrix.Elements[5], "V#6");
		}

		[Fact]
		public void Invert_Translation ()
		{
			Matrix matrix = new Matrix (1, 0, 0, 1, 8, 8);
			matrix.Invert ();

			float[] elements = matrix.Elements;
			Assert.Equal (1, elements[0], "#1");
			Assert.Equal (0, elements[1], "#2");
			Assert.Equal (0, elements[2], "#3");
			Assert.Equal (1, elements[3], "#4");
			Assert.Equal (-8, elements[4], "#5");
			Assert.Equal (-8, elements[5], "#6");
		}

		[Fact]
		public void Invert_Identity ()
		{
			Matrix matrix = new Matrix ();
			Assert.True (matrix.IsIdentity, "IsIdentity");
			Assert.True (matrix.IsInvertible, "IsInvertible");
			matrix.Invert ();
			Assert.True (matrix.IsIdentity, "IsIdentity-2");
			Assert.True (matrix.IsInvertible, "IsInvertible-2");
		}

		[Fact]
		public void Scale ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Scale (2, 4);

			Assert.Equal (20, matrix.Elements[0], "S#1");
			Assert.Equal (40, matrix.Elements[1], "S#2");
			Assert.Equal (120, matrix.Elements[2], "S#3");
			Assert.Equal (160, matrix.Elements[3], "S#4");
			Assert.Equal (50, matrix.Elements[4], "S#5");
			Assert.Equal (60, matrix.Elements[5], "S#6");

			matrix.Scale (0.5f, 0.25f);

			Assert.Equal (10, matrix.Elements[0], "SB#1");
			Assert.Equal (20, matrix.Elements[1], "SB#2");
			Assert.Equal (30, matrix.Elements[2], "SB#3");
			Assert.Equal (40, matrix.Elements[3], "SB#4");
			Assert.Equal (50, matrix.Elements[4], "SB#5");
			Assert.Equal (60, matrix.Elements[5], "SB#6");
		}

		[Fact]
		public void Scale_Negative ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Scale (-2, -4);

			Assert.Equal (-20, matrix.Elements[0], "S#1");
			Assert.Equal (-40, matrix.Elements[1], "S#2");
			Assert.Equal (-120, matrix.Elements[2], "S#3");
			Assert.Equal (-160, matrix.Elements[3], "S#4");
			Assert.Equal (50, matrix.Elements[4], "S#5");
			Assert.Equal (60, matrix.Elements[5], "S#6");
		}

		[Fact]
		public void Scale_InvalidOrder ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().Scale (2, 1, (MatrixOrder) Int32.MinValue));
		}
		
		[Fact]
		public void Shear ()
		{
			Matrix matrix = new Matrix (10, 20, 30, 40, 50, 60);
			matrix.Shear (2, 4);

			Assert.Equal (130, matrix.Elements[0], "H#1");
			Assert.Equal (180, matrix.Elements[1], "H#2");
			Assert.Equal (50, matrix.Elements[2], "H#3");
			Assert.Equal (80, matrix.Elements[3], "H#4");
			Assert.Equal (50, matrix.Elements[4], "H#5");
			Assert.Equal (60, matrix.Elements[5], "H#6");
			
			matrix = new Matrix (5, 3, 9, 2, 2, 1);
			matrix.Shear  (10, 20);			
			
			Assert.Equal (185, matrix.Elements[0], "H#7");
			Assert.Equal (43, matrix.Elements[1], "H#8");
			Assert.Equal (59, matrix.Elements[2], "H#9");
			Assert.Equal (32, matrix.Elements[3], "H#10");
			Assert.Equal (2, matrix.Elements[4], "H#11");
			Assert.Equal (1, matrix.Elements[5], "H#12");
		}

		[Fact]
		public void Shear_InvalidOrder ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().Shear (-1, 1, (MatrixOrder) Int32.MinValue));
		}
		
		[Fact]
		public void TransformPoints ()
		{
			Matrix matrix = new Matrix (2, 4, 6, 8, 10, 12);
			PointF [] pointsF = new PointF [] {new PointF (2, 4), new PointF (4, 8)};
			matrix.TransformPoints (pointsF);
						
			Assert.Equal (38, pointsF[0].X, "K#1");
			Assert.Equal (52, pointsF[0].Y, "K#2");
			Assert.Equal (66, pointsF[1].X, "K#3");
			Assert.Equal (92, pointsF[1].Y, "K#4");
			
			Point [] points = new Point [] {new Point (2, 4), new Point (4, 8)};
			matrix.TransformPoints (points);
			Assert.Equal (38, pointsF[0].X, "K#5");
			Assert.Equal (52, pointsF[0].Y, "K#6");
			Assert.Equal (66, pointsF[1].X, "K#7");
			Assert.Equal (92, pointsF[1].Y, "K#8");
		}

		[Fact]
		public void TransformPoints_Point_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix ().TransformPoints ((Point[]) null));
		}

		[Fact]
		public void TransformPoints_PointF_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix ().TransformPoints ((PointF[]) null));
		}

		[Fact]
		public void TransformPoints_Point_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().TransformPoints (new Point[0]));
		}

		[Fact]
		public void TransformPoints_PointF_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().TransformPoints (new PointF[0]));
		}
		
		[Fact]
		public void TransformVectors  ()
		{
			Matrix matrix = new Matrix (2, 4, 6, 8, 10, 12);
			PointF [] pointsF = new PointF [] {new PointF (2, 4), new PointF (4, 8)};
			matrix.TransformVectors (pointsF);
						
			Assert.Equal (28, pointsF[0].X, "N#1");
			Assert.Equal (40, pointsF[0].Y, "N#2");
			Assert.Equal (56, pointsF[1].X, "N#3");
			Assert.Equal (80, pointsF[1].Y, "N#4");
			
			Point [] points = new Point [] {new Point (2, 4), new Point (4, 8)};
			matrix.TransformVectors (points);
			Assert.Equal (28, pointsF[0].X, "N#5");
			Assert.Equal (40, pointsF[0].Y, "N#6");
			Assert.Equal (56, pointsF[1].X, "N#7");
			Assert.Equal (80, pointsF[1].Y, "N#8");
		}

		[Fact]
		public void TransformVectors_Point_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix ().TransformVectors ((Point[]) null));
		}

		[Fact]
		public void TransformVectors_PointF_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix ().TransformVectors ((PointF[]) null));
		}

		[Fact]
		public void TransformVectors_Point_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().TransformVectors (new Point[0]));
		}

		[Fact]
		public void TransformVectors_PointF_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().TransformVectors (new PointF[0]));
		}

		[Fact]
		public void Translate  ()
		{
			Matrix matrix = new Matrix (2, 4, 6, 8, 10, 12);			
			matrix.Translate (5, 10);
						
			Assert.Equal (2, matrix.Elements[0], "Y#1");
			Assert.Equal (4, matrix.Elements[1], "Y#2");
			Assert.Equal (6, matrix.Elements[2], "Y#3");
			Assert.Equal (8, matrix.Elements[3], "Y#4");
			Assert.Equal (80, matrix.Elements[4], "Y#5");
			Assert.Equal (112, matrix.Elements[5], "Y#6");
		}

		[Fact]
		public void Translate_InvalidOrder ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().Translate (-1, 1, (MatrixOrder) Int32.MinValue));
		}

		[Fact]
		public void VectorTransformPoints_Null ()
		{
			Assert.Throws<ArgumentNullException> (() => new Matrix ().VectorTransformPoints ((Point[]) null));
		}

		[Fact]
		public void VectorTransformPoints_Empty ()
		{
			Assert.Throws<ArgumentException> (() => new Matrix ().VectorTransformPoints (new Point[0]));
		}
	}
}

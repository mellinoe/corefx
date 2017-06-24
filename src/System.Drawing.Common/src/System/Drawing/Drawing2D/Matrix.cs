// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    using System.Runtime.InteropServices;
    using System.Drawing.Internal;

    /**
     * Represent a Matrix object
     */
    /// <summary>
    ///    Encapsulates a 3 X 3 affine matrix that
    ///    represents a geometric transform.
    /// </summary>
    public sealed class Matrix : MarshalByRefObject, IDisposable
    {
        internal IntPtr nativeMatrix;

        /*
         * Create a new identity matrix
         */

        /// <summary>
        ///    Initializes a new instance of the <see cref='System.Drawing.Drawing2D.Matrix'/> class.
        /// </summary>
        public Matrix()
        {
            IntPtr matrix = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateMatrix(out matrix);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            nativeMatrix = matrix;
        }

        /// <summary>
        ///    
        ///       Initialized a new instance of the <see cref='System.Drawing.Drawing2D.Matrix'/> class with the specified
        ///       elements.
        ///    
        /// </summary>
        public Matrix(float m11,
                      float m12,
                      float m21,
                      float m22,
                      float dx,
                      float dy)
        {
            IntPtr matrix = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateMatrix2(m11, m12, m21, m22, dx, dy,
                                                   out matrix);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            nativeMatrix = matrix;
        }

        // float version
        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Drawing2D.Matrix'/> class to the geometrical transform
        ///       defined by the specified rectangle and array of points.
        ///    
        /// </summary>
        public Matrix(RectangleF rect, PointF[] plgpts)
        {
            if (plgpts == null)
            {
                throw new ArgumentNullException("plgpts");
            }
            if (plgpts.Length != 3)
            {
                throw SafeNativeMethods.Gdip.StatusException(SafeNativeMethods.Gdip.InvalidParameter);
            }

            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(plgpts);

            try
            {
                IntPtr matrix = IntPtr.Zero;

                GPRECTF gprectf = new GPRECTF(rect);
                int status = SafeNativeMethods.Gdip.GdipCreateMatrix3(ref gprectf, new HandleRef(null, buf), out matrix);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                nativeMatrix = matrix;
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        // int version
        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Drawing2D.Matrix'/> class to the geometrical transform
        ///       defined by the specified rectangle and array of points.
        ///    
        /// </summary>
        public Matrix(Rectangle rect, Point[] plgpts)
        {
            if (plgpts == null)
            {
                throw new ArgumentNullException("plgpts");
            }
            if (plgpts.Length != 3)
            {
                throw SafeNativeMethods.Gdip.StatusException(SafeNativeMethods.Gdip.InvalidParameter);
            }

            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(plgpts);

            try
            {
                IntPtr matrix = IntPtr.Zero;

                GPRECT gprect = new GPRECT(rect);
                int status = SafeNativeMethods.Gdip.GdipCreateMatrix3I(ref gprect, new HandleRef(null, buf), out matrix);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                nativeMatrix = matrix;
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        /// <summary>
        ///    Cleans up resources allocated for this
        /// <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (nativeMatrix != IntPtr.Zero)
            {
                SafeNativeMethods.Gdip.GdipDeleteMatrix(new HandleRef(this, nativeMatrix));
                nativeMatrix = IntPtr.Zero;
            }
        }

        /// <summary>
        ///    Cleans up resources allocated for this
        /// <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        ~Matrix()
        {
            Dispose(false);
        }

        /// <summary>
        ///    Creates an exact copy of this <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        public Matrix Clone()
        {
            IntPtr cloneMatrix = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneMatrix(new HandleRef(this, nativeMatrix), out cloneMatrix);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return new Matrix(cloneMatrix);
        }

        /// <summary>
        ///    Gets an array of floating-point values that
        ///    represent the elements of this <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        public float[] Elements
        {
            get
            {
                float[] m;

                IntPtr buf = Marshal.AllocHGlobal(6 * 8); // 6 elements x 8 bytes (float)

                try
                {
                    int status = SafeNativeMethods.Gdip.GdipGetMatrixElements(new HandleRef(this, nativeMatrix), buf);

                    if (status != SafeNativeMethods.Gdip.Ok)
                    {
                        throw SafeNativeMethods.Gdip.StatusException(status);
                    }

                    m = new float[6];

                    Marshal.Copy(buf, m, 0, 6);
                }
                finally
                {
                    Marshal.FreeHGlobal(buf);
                }

                return m;
            }
        }

        /// <summary>
        ///    Gets the x translation value (the dx value,
        ///    or the element in the third row and first column) of this <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        public float OffsetX
        {
            get { return Elements[4]; }
        }

        /// <summary>
        ///    Gets the y translation value (the dy
        ///    value, or the element in the third row and second column) of this <see cref='System.Drawing.Drawing2D.Matrix'/>.
        /// </summary>
        public float OffsetY
        {
            get { return Elements[5]; }
        }

        /// <summary>
        ///    Resets this <see cref='System.Drawing.Drawing2D.Matrix'/> to identity.
        /// </summary>
        public void Reset()
        {
            int status = SafeNativeMethods.Gdip.GdipSetMatrixElements(new HandleRef(this, nativeMatrix),
                                                       1.0f, 0.0f, 0.0f,
                                                       1.0f, 0.0f, 0.0f);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Multiplies this <see cref='System.Drawing.Drawing2D.Matrix'/> by the specified <see cref='System.Drawing.Drawing2D.Matrix'/> by prepending the specified <see cref='System.Drawing.Drawing2D.Matrix'/>.
        ///    
        /// </summary>
        public void Multiply(Matrix matrix)
        {
            Multiply(matrix, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Multiplies this <see cref='System.Drawing.Drawing2D.Matrix'/> by the specified <see cref='System.Drawing.Drawing2D.Matrix'/> in the specified order.
        ///    
        /// </summary>
        public void Multiply(Matrix matrix, MatrixOrder order)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            int status = SafeNativeMethods.Gdip.GdipMultiplyMatrix(new HandleRef(this, nativeMatrix), new HandleRef(matrix, matrix.nativeMatrix),
                                                    order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Applies the specified translation vector to
        ///       the this <see cref='System.Drawing.Drawing2D.Matrix'/> by
        ///       prepending the translation vector.
        ///    
        /// </summary>
        public void Translate(float offsetX, float offsetY)
        {
            Translate(offsetX, offsetY, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Applies the specified translation vector to
        ///       the this <see cref='System.Drawing.Drawing2D.Matrix'/> in the specified order.
        ///    
        /// </summary>
        public void Translate(float offsetX, float offsetY, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipTranslateMatrix(new HandleRef(this, nativeMatrix),
                                                     offsetX, offsetY, order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Applies the specified scale vector to this
        /// <see cref='System.Drawing.Drawing2D.Matrix'/> by prepending the scale vector.
        /// </summary>
        public void Scale(float scaleX, float scaleY)
        {
            Scale(scaleX, scaleY, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Applies the specified scale vector to this
        ///    <see cref='System.Drawing.Drawing2D.Matrix'/> using the specified order.
        ///    
        /// </summary>
        public void Scale(float scaleX, float scaleY, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipScaleMatrix(new HandleRef(this, nativeMatrix), scaleX, scaleY, order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Rotates this <see cref='System.Drawing.Drawing2D.Matrix'/> clockwise about the
        ///       origin by the specified angle.
        ///    
        /// </summary>
        public void Rotate(float angle)
        {
            Rotate(angle, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Rotates this <see cref='System.Drawing.Drawing2D.Matrix'/> clockwise about the
        ///       origin by the specified
        ///       angle in the specified order.
        ///    
        /// </summary>
        public void Rotate(float angle, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipRotateMatrix(new HandleRef(this, nativeMatrix), angle, order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Applies a clockwise rotation about the
        ///       specified point to this <see cref='System.Drawing.Drawing2D.Matrix'/> by prepending the rotation.
        ///    
        /// </summary>
        public void RotateAt(float angle, PointF point)
        {
            RotateAt(angle, point, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Applies a clockwise rotation about the specified point
        ///       to this <see cref='System.Drawing.Drawing2D.Matrix'/> in the
        ///       specified order.
        ///    
        /// </summary>
        public void RotateAt(float angle, PointF point, MatrixOrder order)
        {
            int status;

            // !! TO DO: We cheat with error codes here...
            if (order == MatrixOrder.Prepend)
            {
                status = SafeNativeMethods.Gdip.GdipTranslateMatrix(new HandleRef(this, nativeMatrix), point.X, point.Y, order);
                status |= SafeNativeMethods.Gdip.GdipRotateMatrix(new HandleRef(this, nativeMatrix), angle, order);
                status |= SafeNativeMethods.Gdip.GdipTranslateMatrix(new HandleRef(this, nativeMatrix), -point.X, -point.Y, order);
            }
            else
            {
                status = SafeNativeMethods.Gdip.GdipTranslateMatrix(new HandleRef(this, nativeMatrix), -point.X, -point.Y, order);
                status |= SafeNativeMethods.Gdip.GdipRotateMatrix(new HandleRef(this, nativeMatrix), angle, order);
                status |= SafeNativeMethods.Gdip.GdipTranslateMatrix(new HandleRef(this, nativeMatrix), point.X, point.Y, order);
            }

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Applies the specified shear
        ///    vector to this <see cref='System.Drawing.Drawing2D.Matrix'/> by prepending the shear vector.
        /// </summary>
        public void Shear(float shearX, float shearY)
        {
            int status = SafeNativeMethods.Gdip.GdipShearMatrix(new HandleRef(this, nativeMatrix), shearX, shearY, MatrixOrder.Prepend);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Applies the specified shear
        ///       vector to this <see cref='System.Drawing.Drawing2D.Matrix'/> in the specified order.
        ///    
        /// </summary>
        public void Shear(float shearX, float shearY, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipShearMatrix(new HandleRef(this, nativeMatrix), shearX, shearY, order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Inverts this <see cref='System.Drawing.Drawing2D.Matrix'/>, if it is
        ///    invertible.
        /// </summary>
        public void Invert()
        {
            int status = SafeNativeMethods.Gdip.GdipInvertMatrix(new HandleRef(this, nativeMatrix));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        // float version
        /// <summary>
        ///    
        ///       Applies the geometrical transform this <see cref='System.Drawing.Drawing2D.Matrix'/>represents to an
        ///       array of points.
        ///    
        /// </summary>
        public void TransformPoints(PointF[] pts)
        {
            if (pts == null)
                throw new ArgumentNullException("pts");
            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(pts);

            try
            {
                int status = SafeNativeMethods.Gdip.GdipTransformMatrixPoints(new HandleRef(this, nativeMatrix),
                    new HandleRef(null, buf),
                    pts.Length);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                PointF[] newPts = SafeNativeMethods.Gdip.ConvertGPPOINTFArrayF(buf, pts.Length);

                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i] = newPts[i];
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        // int version
        /// <summary>
        ///    
        ///       Applies the geometrical transform this <see cref='System.Drawing.Drawing2D.Matrix'/> represents to an array of points.
        ///    
        /// </summary>
        public void TransformPoints(Point[] pts)
        {
            if (pts == null)
                throw new ArgumentNullException("pts");
            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(pts);

            try
            {
                int status = SafeNativeMethods.Gdip.GdipTransformMatrixPointsI(new HandleRef(this, nativeMatrix),
                    new HandleRef(null, buf),
                    pts.Length);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                // must do an in-place copy because we only have a reference
                Point[] newPts = SafeNativeMethods.Gdip.ConvertGPPOINTArray(buf, pts.Length);

                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i] = newPts[i];
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        public void TransformVectors(PointF[] pts)
        {
            if (pts == null)
            {
                throw new ArgumentNullException("pts");
            }

            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(pts);

            try
            {
                int status = SafeNativeMethods.Gdip.GdipVectorTransformMatrixPoints(new HandleRef(this, nativeMatrix),
                    new HandleRef(null, buf),
                    pts.Length);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                // must do an in-place copy because we only have a reference
                PointF[] newPts = SafeNativeMethods.Gdip.ConvertGPPOINTFArrayF(buf, pts.Length);

                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i] = newPts[i];
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        // int version
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        public void VectorTransformPoints(Point[] pts)
        {
            TransformVectors(pts);
        }

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        public void TransformVectors(Point[] pts)
        {
            if (pts == null)
            {
                throw new ArgumentNullException("pts");
            }

            IntPtr buf = SafeNativeMethods.Gdip.ConvertPointToMemory(pts);

            try
            {
                int status = SafeNativeMethods.Gdip.GdipVectorTransformMatrixPointsI(new HandleRef(this, nativeMatrix),
                    new HandleRef(null, buf),
                    pts.Length);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                // must do an in-place copy because we only have a reference
                Point[] newPts = SafeNativeMethods.Gdip.ConvertGPPOINTArray(buf, pts.Length);

                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i] = newPts[i];
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }

        /// <summary>
        ///    Gets a value indicating whether this
        /// <see cref='System.Drawing.Drawing2D.Matrix'/> is invertible.
        /// </summary>
        public bool IsInvertible
        {
            get
            {
                int isInvertible;

                int status = SafeNativeMethods.Gdip.GdipIsMatrixInvertible(new HandleRef(this, nativeMatrix), out isInvertible);

                if (status != SafeNativeMethods.Gdip.Ok)
                    throw SafeNativeMethods.Gdip.StatusException(status);

                return isInvertible != 0;
            }
        }

        /// <summary>
        ///    Gets a value indicating whether this <see cref='System.Drawing.Drawing2D.Matrix'/> is the identity matrix.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                int isIdentity;

                int status = SafeNativeMethods.Gdip.GdipIsMatrixIdentity(new HandleRef(this, nativeMatrix), out isIdentity);

                if (status != SafeNativeMethods.Gdip.Ok)
                    throw SafeNativeMethods.Gdip.StatusException(status);

                return isIdentity != 0;
            }
        }

        /// <summary>
        ///    
        ///       Tests whether the specified object is a
        ///    <see cref='System.Drawing.Drawing2D.Matrix'/> and is identical to this <see cref='System.Drawing.Drawing2D.Matrix'/>.
        ///    
        /// </summary>
        public override bool Equals(object obj)
        {
            Matrix matrix2 = obj as Matrix;
            if (matrix2 == null) return false;

            int isEqual;

            int status = SafeNativeMethods.Gdip.GdipIsMatrixEqual(new HandleRef(this, nativeMatrix),
                                                   new HandleRef(matrix2, matrix2.nativeMatrix),
                                                   out isEqual);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isEqual != 0;
        }

        /// <summary>
        ///    
        ///       Returns a hash code.
        ///    
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal Matrix(IntPtr nativeMatrix)
        {
            SetNativeMatrix(nativeMatrix);
        }

        internal void SetNativeMatrix(IntPtr nativeMatrix)
        {
            this.nativeMatrix = nativeMatrix;
        }
    }
}

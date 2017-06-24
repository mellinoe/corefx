// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Drawing.Internal;

    /**
     * Represent a LinearGradient brush object
     */
    /// <summary>
    ///    
    ///       Encapsulates a <see cref='System.Drawing.Brush'/> with a linear gradient.
    ///    
    /// </summary>
    public sealed class LinearGradientBrush : Brush
    {
        private bool _interpolationColorsWasSet;

        /**
         * Create a new rectangle gradient brush object
         */
        /// <summary>
        ///    Initializes a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the specified points and
        ///    colors.
        /// </summary>
        public LinearGradientBrush(PointF point1, PointF point2,
                                   Color color1, Color color2)
        {
            IntPtr brush = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateLineBrush(new GPPOINTF(point1),
                                                     new GPPOINTF(point2),
                                                     color1.ToArgb(),
                                                     color2.ToArgb(),
                                                     (int)WrapMode.Tile,
                                                     out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points and colors.
        ///    
        /// </summary>
        public LinearGradientBrush(Point point1, Point point2,
                                   Color color1, Color color2)
        {
            IntPtr brush = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateLineBrushI(new GPPOINT(point1),
                                                      new GPPOINT(point2),
                                                      color1.ToArgb(),
                                                      color2.ToArgb(),
                                                      (int)WrapMode.Tile,
                                                      out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with
        ///       the specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(RectangleF rect, Color color1, Color color2,
                                   LinearGradientMode linearGradientMode)
        {
            //validate the LinearGradientMode enum
            //valid values are 0x0 to 0x3
            if (!ClientUtils.IsEnumValid(linearGradientMode, unchecked((int)linearGradientMode), (int)LinearGradientMode.Horizontal, (int)LinearGradientMode.BackwardDiagonal))
            {
                throw new InvalidEnumArgumentException("linearGradientMode", unchecked((int)linearGradientMode), typeof(LinearGradientMode));
            }

            //validate the rect
            if (rect.Width == 0.0 || rect.Height == 0.0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            IntPtr brush = IntPtr.Zero;

            GPRECTF gprectf = new GPRECTF(rect);
            int status = SafeNativeMethods.Gdip.GdipCreateLineBrushFromRect(ref gprectf,
                                                             color1.ToArgb(),
                                                             color2.ToArgb(),
                                                             unchecked((int)linearGradientMode),
                                                             (int)WrapMode.Tile,
                                                             out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(Rectangle rect, Color color1, Color color2,
                                   LinearGradientMode linearGradientMode)
        {
            //validate the LinearGradientMode enum
            //valid values are 0x0 to 0x3
            if (!ClientUtils.IsEnumValid(linearGradientMode, unchecked((int)linearGradientMode), (int)LinearGradientMode.Horizontal, (int)LinearGradientMode.BackwardDiagonal))
            {
                throw new InvalidEnumArgumentException("linearGradientMode", unchecked((int)linearGradientMode), typeof(LinearGradientMode));
            }

            //validate the rect
            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            IntPtr brush = IntPtr.Zero;

            GPRECT gpRect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCreateLineBrushFromRectI(ref gpRect,
                                                              color1.ToArgb(),
                                                              color2.ToArgb(),
                                                              unchecked((int)linearGradientMode),
                                                              (int)WrapMode.Tile,
                                                              out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(RectangleF rect, Color color1, Color color2,
                                 float angle)
            : this(rect, color1, color2, angle, false)
        { }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(RectangleF rect, Color color1, Color color2,
                                 float angle, bool isAngleScaleable)
        {
            IntPtr brush = IntPtr.Zero;

            //validate the rect
            if (rect.Width == 0.0 || rect.Height == 0.0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            GPRECTF gprectf = new GPRECTF(rect);
            int status = SafeNativeMethods.Gdip.GdipCreateLineBrushFromRectWithAngle(ref gprectf,
                                                                      color1.ToArgb(),
                                                                      color2.ToArgb(),
                                                                      angle,
                                                                      isAngleScaleable,
                                                                      (int)WrapMode.Tile,
                                                                      out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(Rectangle rect, Color color1, Color color2,
                                   float angle)
            : this(rect, color1, color2, angle, false)
        {
        }

        /// <summary>
        ///    
        ///       Encapsulates a new instance of the <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> class with the
        ///       specified points, colors, and orientation.
        ///    
        /// </summary>
        public LinearGradientBrush(Rectangle rect, Color color1, Color color2,
                                 float angle, bool isAngleScaleable)
        {
            IntPtr brush = IntPtr.Zero;

            //validate the rect
            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCreateLineBrushFromRectWithAngleI(ref gprect,
                                                                       color1.ToArgb(),
                                                                       color2.ToArgb(),
                                                                       angle,
                                                                       isAngleScaleable,
                                                                       (int)WrapMode.Tile,
                                                                       out brush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeBrushInternal(brush);
        }

        /// <summary>
        ///     Constructor to initialized this object to be owned by GDI+.
        /// </summary>
        internal LinearGradientBrush(IntPtr nativeBrush)
        {
            Debug.Assert(nativeBrush != IntPtr.Zero, "Initializing native brush with null.");
            SetNativeBrushInternal(nativeBrush);
        }

        /// <summary>
        ///    Creates an exact copy of this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/>.
        /// </summary>
        public override object Clone()
        {
            IntPtr cloneBrush = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneBrush(new HandleRef(this, NativeBrush), out cloneBrush);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return new LinearGradientBrush(cloneBrush);
        }

        /**
         * Get/set colors
         */

        private void _SetLinearColors(Color color1, Color color2)
        {
            int status = SafeNativeMethods.Gdip.GdipSetLineColors(new HandleRef(this, NativeBrush),
                                                   color1.ToArgb(),
                                                   color2.ToArgb());

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private Color[] _GetLinearColors()
        {
            int[] colors =
            new int[]
            {
                0,
                0
            };

            int status = SafeNativeMethods.Gdip.GdipGetLineColors(new HandleRef(this, NativeBrush), colors);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            Color[] lineColor = new Color[2];

            lineColor[0] = Color.FromArgb(colors[0]);
            lineColor[1] = Color.FromArgb(colors[1]);

            return lineColor;
        }

        /// <summary>
        ///    Gets or sets the starting and ending colors of the
        ///    gradient.
        /// </summary>
        public Color[] LinearColors
        {
            get { return _GetLinearColors(); }
            set { _SetLinearColors(value[0], value[1]); }
        }

        /**
         * Get source rectangle
         */
        private RectangleF _GetRectangle()
        {
            GPRECTF rect = new GPRECTF();

            int status = SafeNativeMethods.Gdip.GdipGetLineRect(new HandleRef(this, NativeBrush), ref rect);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return rect.ToRectangleF();
        }

        /// <summary>
        ///    
        ///       Gets a rectangular region that defines the
        ///       starting and ending points of the gradient.
        ///    
        /// </summary>
        public RectangleF Rectangle
        {
            get { return _GetRectangle(); }
        }

        /// <summary>
        ///    
        ///       Gets or sets a value indicating whether
        ///       gamma correction is enabled for this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/>.
        ///    
        /// </summary>
        public bool GammaCorrection
        {
            get
            {
                bool useGammaCorrection;

                int status = SafeNativeMethods.Gdip.GdipGetLineGammaCorrection(new HandleRef(this, NativeBrush),
                                                       out useGammaCorrection);
                if (status != SafeNativeMethods.Gdip.Ok)
                    throw SafeNativeMethods.Gdip.StatusException(status);

                return useGammaCorrection;
            }
            set
            {
                int status = SafeNativeMethods.Gdip.GdipSetLineGammaCorrection(new HandleRef(this, NativeBrush),
                                                        value);
                if (status != SafeNativeMethods.Gdip.Ok)
                    throw SafeNativeMethods.Gdip.StatusException(status);
            }
        }

        /**
         * Get/set blend factors
         *
         * @notes If the blendFactors.Length = 1, then it's treated
         *  as the falloff parameter. Otherwise, it's the array
         *  of blend factors.
         */

        private Blend _GetBlend()
        {
            // VSWHidbey 518309 - interpolation colors and blends don't get along.  Just getting
            // the Blend when InterpolationColors was set puts the Brush into an unusable state afterwards.
            // so to avoid that (mostly the problem of having Blend pop up in the debugger window and cause this problem)
            // we just bail here.
            //
            if (_interpolationColorsWasSet)
            {
                return null;
            }

            Blend blend;

            // Figure out the size of blend factor array
            int retval = 0;
            int status = SafeNativeMethods.Gdip.GdipGetLineBlendCount(new HandleRef(this, NativeBrush), out retval);

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                throw SafeNativeMethods.Gdip.StatusException(status);
            }
            if (retval <= 0)
            {
                return null;
            }

            // Allocate temporary native memory buffer
            int count = retval;

            IntPtr factors = IntPtr.Zero;
            IntPtr positions = IntPtr.Zero;

            try
            {
                int size = checked(4 * count);
                factors = Marshal.AllocHGlobal(size);
                positions = Marshal.AllocHGlobal(size);

                // Retrieve horizontal blend factors
                status = SafeNativeMethods.Gdip.GdipGetLineBlend(new HandleRef(this, NativeBrush), factors, positions, count);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                // Return the result in a managed array
                blend = new Blend(count);

                Marshal.Copy(factors, blend.Factors, 0, count);
                Marshal.Copy(positions, blend.Positions, 0, count);
            }
            finally
            {
                if (factors != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(factors);
                }
                if (positions != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(positions);
                }
            }

            return blend;
        }

        private void _SetBlend(Blend blend)
        {
            // Allocate temporary native memory buffer
            // and copy input blend factors into it.

            int count = blend.Factors.Length;

            IntPtr factors = IntPtr.Zero;
            IntPtr positions = IntPtr.Zero;

            try
            {
                int size = checked(4 * count);
                factors = Marshal.AllocHGlobal(size);
                positions = Marshal.AllocHGlobal(size);

                Marshal.Copy(blend.Factors, 0, factors, count);
                Marshal.Copy(blend.Positions, 0, positions, count);

                // Set blend factors

                int status = SafeNativeMethods.Gdip.GdipSetLineBlend(new HandleRef(this, NativeBrush), new HandleRef(null, factors), new HandleRef(null, positions), count);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }
            }
            finally
            {
                if (factors != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(factors);
                }
                if (positions != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(positions);
                }
            }
        }

        /// <summary>
        ///    Gets or sets a <see cref='System.Drawing.Drawing2D.Blend'/> that specifies
        ///    positions and factors that define a custom falloff for the gradient.
        /// </summary>
        public Blend Blend
        {
            get { return _GetBlend(); }
            set { _SetBlend(value); }
        }

        /*
         * SigmaBlend & LinearBlend not yet implemented
         */

        /// <summary>
        ///    Creates a gradient falloff based on a
        ///    bell-shaped curve.
        /// </summary>
        public void SetSigmaBellShape(float focus)
        {
            SetSigmaBellShape(focus, (float)1.0);
        }

        /// <summary>
        ///    Creates a gradient falloff based on a
        ///    bell-shaped curve.
        /// </summary>
        public void SetSigmaBellShape(float focus, float scale)
        {
            int status = SafeNativeMethods.Gdip.GdipSetLineSigmaBlend(new HandleRef(this, NativeBrush), focus, scale);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Creates a triangular gradient.
        ///    
        /// </summary>
        public void SetBlendTriangularShape(float focus)
        {
            SetBlendTriangularShape(focus, (float)1.0);
        }

        /// <summary>
        ///    
        ///       Creates a triangular gradient.
        ///    
        /// </summary>
        public void SetBlendTriangularShape(float focus, float scale)
        {
            int status = SafeNativeMethods.Gdip.GdipSetLineLinearBlend(new HandleRef(this, NativeBrush), focus, scale);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /*
         * Preset Color Blend
         */

        private ColorBlend _GetInterpolationColors()
        {
            ColorBlend blend;

            if (!_interpolationColorsWasSet)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsColorBlendNotSet), ""));
            }
            // Figure out the size of blend factor array

            int retval = 0;
            int status = SafeNativeMethods.Gdip.GdipGetLinePresetBlendCount(new HandleRef(this, NativeBrush), out retval);

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            // Allocate temporary native memory buffer

            int count = retval;

            IntPtr colors = IntPtr.Zero;
            IntPtr positions = IntPtr.Zero;

            try
            {
                int size = checked(4 * count);
                colors = Marshal.AllocHGlobal(size);
                positions = Marshal.AllocHGlobal(size);

                // Retrieve horizontal blend factors

                status = SafeNativeMethods.Gdip.GdipGetLinePresetBlend(new HandleRef(this, NativeBrush), colors, positions, count);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                // Return the result in a managed array

                blend = new ColorBlend(count);

                int[] argb = new int[count];
                Marshal.Copy(colors, argb, 0, count);
                Marshal.Copy(positions, blend.Positions, 0, count);

                // copy ARGB values into Color array of ColorBlend
                blend.Colors = new Color[argb.Length];

                for (int i = 0; i < argb.Length; i++)
                {
                    blend.Colors[i] = Color.FromArgb(argb[i]);
                }
            }
            finally
            {
                if (colors != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(colors);
                }
                if (positions != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(positions);
                }
            }

            return blend;
        }

        private void _SetInterpolationColors(ColorBlend blend)
        {
            _interpolationColorsWasSet = true;

            // Validate the ColorBlend object.
            if (blend == null)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsInvalidColorBlendObject), ""));
            }
            else if (blend.Colors.Length < 2)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsInvalidColorBlendObject),
                                            SR.Format(SR.InterpolationColorsLength)));
            }
            else if (blend.Colors.Length != blend.Positions.Length)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsInvalidColorBlendObject),
                                            SR.Format(SR.InterpolationColorsLengthsDiffer)));
            }
            else if (blend.Positions[0] != 0.0f)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsInvalidColorBlendObject),
                                            SR.Format(SR.InterpolationColorsInvalidStartPosition)));
            }
            else if (blend.Positions[blend.Positions.Length - 1] != 1.0f)
            {
                throw new ArgumentException(SR.Format(SR.InterpolationColorsCommon,
                                            SR.Format(SR.InterpolationColorsInvalidColorBlendObject),
                                            SR.Format(SR.InterpolationColorsInvalidEndPosition)));
            }


            // Allocate temporary native memory buffer
            // and copy input blend factors into it.

            int count = blend.Colors.Length;

            IntPtr colors = IntPtr.Zero;
            IntPtr positions = IntPtr.Zero;

            try
            {
                int size = checked(4 * count);
                colors = Marshal.AllocHGlobal(size);
                positions = Marshal.AllocHGlobal(size);

                int[] argbs = new int[count];
                for (int i = 0; i < count; i++)
                {
                    argbs[i] = blend.Colors[i].ToArgb();
                }

                Marshal.Copy(argbs, 0, colors, count);
                Marshal.Copy(blend.Positions, 0, positions, count);

                // Set blend factors

                int status = SafeNativeMethods.Gdip.GdipSetLinePresetBlend(new HandleRef(this, NativeBrush), new HandleRef(null, colors), new HandleRef(null, positions), count);

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }
            }
            finally
            {
                if (colors != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(colors);
                }
                if (positions != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(positions);
                }
            }
        }

        /// <summary>
        ///    
        ///       Gets or sets a <see cref='System.Drawing.Drawing2D.ColorBlend'/> that defines a multi-color linear
        ///       gradient.
        ///    
        /// </summary>
        public ColorBlend InterpolationColors
        {
            get { return _GetInterpolationColors(); }
            set { _SetInterpolationColors(value); }
        }

        /**
         * Set/get brush wrapping mode
         */
        private void _SetWrapMode(WrapMode wrapMode)
        {
            int status = SafeNativeMethods.Gdip.GdipSetLineWrapMode(new HandleRef(this, NativeBrush), unchecked((int)wrapMode));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private WrapMode _GetWrapMode()
        {
            int mode = 0;

            int status = SafeNativeMethods.Gdip.GdipGetLineWrapMode(new HandleRef(this, NativeBrush), out mode);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return (WrapMode)mode;
        }

        /// <summary>
        ///    
        ///       Gets or sets a <see cref='System.Drawing.Drawing2D.WrapMode'/> that indicates the wrap mode for this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/>.
        ///    
        /// </summary>
        public WrapMode WrapMode
        {
            get
            {
                return _GetWrapMode();
            }
            set
            {
                //validate the WrapMode enum
                //valid values are 0x0 to 0x4
                if (!ClientUtils.IsEnumValid(value, unchecked((int)value), (int)WrapMode.Tile, (int)WrapMode.Clamp))
                {
                    throw new InvalidEnumArgumentException("value", unchecked((int)value), typeof(WrapMode));
                }

                _SetWrapMode(value);
            }
        }

        /**
         * Set/get brush transform
         */
        private void _SetTransform(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            int status = SafeNativeMethods.Gdip.GdipSetLineTransform(new HandleRef(this, NativeBrush), new HandleRef(matrix, matrix.nativeMatrix));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private Matrix _GetTransform()
        {
            Matrix matrix = new Matrix();

            // NOTE: new Matrix() will throw an exception if matrix == null.

            int status = SafeNativeMethods.Gdip.GdipGetLineTransform(new HandleRef(this, NativeBrush), new HandleRef(matrix, matrix.nativeMatrix));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return matrix;
        }

        /// <summary>
        ///    
        ///       Gets or sets a <see cref='System.Drawing.Drawing2D.Matrix'/> that defines a local geometrical transform for
        ///       this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/>.
        ///    
        /// </summary>
        public Matrix Transform
        {
            get { return _GetTransform(); }
            set { _SetTransform(value); }
        }

        /// <summary>
        ///    Resets the <see cref='System.Drawing.Drawing2D.LinearGradientBrush.Transform'/> property to identity.
        /// </summary>
        public void ResetTransform()
        {
            int status = SafeNativeMethods.Gdip.GdipResetLineTransform(new HandleRef(this, NativeBrush));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Multiplies the <see cref='System.Drawing.Drawing2D.Matrix'/> that represents the local geometrical
        ///       transform of this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> by the specified <see cref='System.Drawing.Drawing2D.Matrix'/> by prepending the specified <see cref='System.Drawing.Drawing2D.Matrix'/>.
        ///    
        /// </summary>
        public void MultiplyTransform(Matrix matrix)
        {
            MultiplyTransform(matrix, MatrixOrder.Prepend);
        }

        /// <summary>
        ///    
        ///       Multiplies the <see cref='System.Drawing.Drawing2D.Matrix'/> that represents the local geometrical
        ///       transform of this <see cref='System.Drawing.Drawing2D.LinearGradientBrush'/> by the specified <see cref='System.Drawing.Drawing2D.Matrix'/> in the specified order.
        ///    
        /// </summary>
        public void MultiplyTransform(Matrix matrix, MatrixOrder order)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            int status = SafeNativeMethods.Gdip.GdipMultiplyLineTransform(new HandleRef(this, NativeBrush),
                                                new HandleRef(matrix, matrix.nativeMatrix),
                                                order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }


        /// <summary>
        ///    Translates the local geometrical transform
        ///    by the specified dimmensions. This method prepends the translation to the
        ///    transform.
        /// </summary>
        public void TranslateTransform(float dx, float dy)
        { TranslateTransform(dx, dy, MatrixOrder.Prepend); }

        /// <summary>
        ///    Translates the local geometrical transform
        ///    by the specified dimmensions in the specified order.
        /// </summary>
        public void TranslateTransform(float dx, float dy, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipTranslateLineTransform(new HandleRef(this, NativeBrush),
                                                            dx,
                                                            dy,
                                                            order);
            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Scales the local geometric transform by the
        ///    specified amounts. This method prepends the scaling matrix to the transform.
        /// </summary>
        public void ScaleTransform(float sx, float sy)
        { ScaleTransform(sx, sy, MatrixOrder.Prepend); }

        /// <summary>
        ///    
        ///       Scales the local geometric transform by the
        ///       specified amounts in the specified order.
        ///    
        /// </summary>
        public void ScaleTransform(float sx, float sy, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipScaleLineTransform(new HandleRef(this, NativeBrush),
                                                        sx,
                                                        sy,
                                                        order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Rotates the local geometric transform by the
        ///    specified amount. This method prepends the rotation to the transform.
        /// </summary>
        public void RotateTransform(float angle)
        { RotateTransform(angle, MatrixOrder.Prepend); }

        /// <summary>
        ///    
        ///       Rotates the local geometric transform by the specified
        ///       amount in the specified order.
        ///    
        /// </summary>
        public void RotateTransform(float angle, MatrixOrder order)
        {
            int status = SafeNativeMethods.Gdip.GdipRotateLineTransform(new HandleRef(this, NativeBrush),
                                                         angle,
                                                         order);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Represents an adjustable arrow-shaped line cap.
    /// </summary>
    public sealed class AdjustableArrowCap : CustomLineCap
    {
        internal AdjustableArrowCap(IntPtr nativeCap) :
            base(nativeCap)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref='AdjustableArrowCap'/> class with the specified width and height.
        /// </summary>
        public AdjustableArrowCap(float width,
                                  float height) :
            this(width, height, true)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref='AdjustableArrowCap'/> class with the specified width, height,
        /// and fill property.
        /// </summary>
        public AdjustableArrowCap(float width,
                                  float height,
                                  bool isFilled)
        {
            IntPtr nativeCap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateAdjustableArrowCap(
                                height, width, isFilled, out nativeCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeLineCap(nativeCap);
        }

        private void _SetHeight(float height)
        {
            int status = SafeNativeMethods.Gdip.GdipSetAdjustableArrowCapHeight(new HandleRef(this, nativeCap), height);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private float _GetHeight()
        {
            float height;
            int status = SafeNativeMethods.Gdip.GdipGetAdjustableArrowCapHeight(new HandleRef(this, nativeCap), out height);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return height;
        }

        /// <summary>
        /// Gets or sets the height of the arrow cap.
        /// </summary>
        public float Height
        {
            get { return _GetHeight(); }
            set { _SetHeight(value); }
        }

        private void _SetWidth(float width)
        {
            int status = SafeNativeMethods.Gdip.GdipSetAdjustableArrowCapWidth(new HandleRef(this, nativeCap), width);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private float _GetWidth()
        {
            float width;
            int status = SafeNativeMethods.Gdip.GdipGetAdjustableArrowCapWidth(new HandleRef(this, nativeCap), out width);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return width;
        }

        /// <summary>
        /// Gets or sets the width of the arrow cap.
        /// </summary>
        public float Width
        {
            get { return _GetWidth(); }
            set { _SetWidth(value); }
        }

        private void _SetMiddleInset(float middleInset)
        {
            int status = SafeNativeMethods.Gdip.GdipSetAdjustableArrowCapMiddleInset(new HandleRef(this, nativeCap), middleInset);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private float _GetMiddleInset()
        {
            float middleInset;
            int status = SafeNativeMethods.Gdip.GdipGetAdjustableArrowCapMiddleInset(new HandleRef(this, nativeCap), out middleInset);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return middleInset;
        }

        /// <summary>
        /// Gets or set the number of pixels between the outline of the arrow cap and the fill.
        /// </summary>
        public float MiddleInset
        {
            get { return _GetMiddleInset(); }
            set { _SetMiddleInset(value); }
        }

        private void _SetFillState(bool isFilled)
        {
            int status = SafeNativeMethods.Gdip.GdipSetAdjustableArrowCapFillState(new HandleRef(this, nativeCap), isFilled);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private bool _IsFilled()
        {
            bool isFilled = false;
            int status = SafeNativeMethods.Gdip.GdipGetAdjustableArrowCapFillState(new HandleRef(this, nativeCap), out isFilled);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isFilled;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the arrow cap is filled.
        /// </summary>
        public bool Filled
        {
            get { return _IsFilled(); }
            set { _SetFillState(value); }
        }
    }
}

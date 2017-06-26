// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Encapsulates a custom user-defined line cap.
    /// </summary>
    public class CustomLineCap : MarshalByRefObject, ICloneable, IDisposable
    {
#if FINALIZATION_WATCH
        private string allocationSite = Graphics.GetAllocationStack();
#endif


        /*
         * Handle to native line cap object
         */
        internal SafeCustomLineCapHandle nativeCap = null;

        private bool _disposed = false;

        // For subclass creation
        internal CustomLineCap() { }

        /// <summary>
        /// Initializes a new instance of the <see cref='CustomLineCap'/> class with the specified outline and fill.
        /// </summary>
        public CustomLineCap(GraphicsPath fillPath,
                             GraphicsPath strokePath) :
            this(fillPath, strokePath, LineCap.Flat)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref='CustomLineCap'/> class from the specified existing
        /// <see cref='LineCap'/> with the specified outline and fill.
        /// </summary>
        public CustomLineCap(GraphicsPath fillPath,
                             GraphicsPath strokePath,
                             LineCap baseCap) :
            this(fillPath, strokePath, baseCap, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref='CustomLineCap'/> class from the specified existing
        /// <see cref='LineCap'/> with the specified outline, fill, and inset.
        /// </summary>
        public CustomLineCap(GraphicsPath fillPath,
                             GraphicsPath strokePath,
                             LineCap baseCap,
                             float baseInset)
        {
            IntPtr nativeLineCap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateCustomLineCap(
                                new HandleRef(fillPath, (fillPath == null) ? IntPtr.Zero : fillPath.nativePath),
                                new HandleRef(strokePath, (strokePath == null) ? IntPtr.Zero : strokePath.nativePath),
                                baseCap, baseInset, out nativeLineCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeLineCap(nativeLineCap);
        }

        internal CustomLineCap(IntPtr nativeLineCap)
        {
            SetNativeLineCap(nativeLineCap);
        }

        internal void SetNativeLineCap(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentNullException("handle");

            nativeCap = new SafeCustomLineCapHandle(handle);
        }

        /// <summary>
        /// Cleans up Windows resources for this <see cref='CustomLineCap'/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

#if FINALIZATION_WATCH
            if (!disposing && nativeCap != null)
                Debug.WriteLine("**********************\nDisposed through finalization:\n" + allocationSite);
#endif
            // propagate the explicit dispose call to the child
            if (disposing && nativeCap != null)
            {
                nativeCap.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Cleans up Windows resources for this <see cref='CustomLineCap'/>.
        /// </summary>
        ~CustomLineCap()
        {
            Dispose(false);
        }

        /// <summary>
        /// Creates an exact copy of this <see cref='CustomLineCap'/>.
        /// </summary>
        public object Clone()
        {
            IntPtr cloneCap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneCustomLineCap(new HandleRef(this, nativeCap), out cloneCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return CustomLineCap.CreateCustomLineCapObject(cloneCap);
        }

        internal static CustomLineCap CreateCustomLineCapObject(IntPtr cap)
        {
            CustomLineCapType capType = 0;

            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapType(new HandleRef(null, cap), out capType);

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDeleteCustomLineCap(new HandleRef(null, cap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            switch (capType)
            {
                case CustomLineCapType.Default:
                    return new CustomLineCap(cap);

                case CustomLineCapType.AdjustableArrowCap:
                    return new AdjustableArrowCap(cap);
            }

            SafeNativeMethods.Gdip.GdipDeleteCustomLineCap(new HandleRef(null, cap));
            throw SafeNativeMethods.Gdip.StatusException(SafeNativeMethods.Gdip.NotImplemented);
        }

        /// <summary>
        /// Sets the caps used to start and end lines.
        /// </summary>
        public void SetStrokeCaps(LineCap startCap, LineCap endCap)
        {
            int status = SafeNativeMethods.Gdip.GdipSetCustomLineCapStrokeCaps(new HandleRef(this, nativeCap), startCap, endCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Gets the caps used to start and end lines.
        /// </summary>
        public void GetStrokeCaps(out LineCap startCap, out LineCap endCap)
        {
            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapStrokeCaps(new HandleRef(this, nativeCap), out startCap, out endCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private void _SetStrokeJoin(LineJoin lineJoin)
        {
            int status = SafeNativeMethods.Gdip.GdipSetCustomLineCapStrokeJoin(new HandleRef(this, nativeCap), lineJoin);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private LineJoin _GetStrokeJoin()
        {
            LineJoin lineJoin;

            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapStrokeJoin(new HandleRef(this, nativeCap), out lineJoin);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return lineJoin;
        }

        /// <summary>
        /// Gets or sets the <see cref='LineJoin'/> used by this custom cap.
        /// </summary>
        public LineJoin StrokeJoin
        {
            get { return _GetStrokeJoin(); }
            set { _SetStrokeJoin(value); }
        }

        private void _SetBaseCap(LineCap baseCap)
        {
            int status = SafeNativeMethods.Gdip.GdipSetCustomLineCapBaseCap(new HandleRef(this, nativeCap), baseCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private LineCap _GetBaseCap()
        {
            LineCap baseCap;
            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapBaseCap(new HandleRef(this, nativeCap), out baseCap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return baseCap;
        }

        /// <summary>
        /// Gets or sets the <see cref='LineCap'/> on which this <see cref='CustomLineCap'/> is based.
        /// </summary>
        public LineCap BaseCap
        {
            get { return _GetBaseCap(); }
            set { _SetBaseCap(value); }
        }

        private void _SetBaseInset(float inset)
        {
            int status = SafeNativeMethods.Gdip.GdipSetCustomLineCapBaseInset(new HandleRef(this, nativeCap), inset);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private float _GetBaseInset()
        {
            float inset;
            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapBaseInset(new HandleRef(this, nativeCap), out inset);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return inset;
        }

        /// <summary>
        /// Gets or sets the distance between the cap and the line.
        /// </summary>
        public float BaseInset
        {
            get { return _GetBaseInset(); }
            set { _SetBaseInset(value); }
        }

        private void _SetWidthScale(float widthScale)
        {
            int status = SafeNativeMethods.Gdip.GdipSetCustomLineCapWidthScale(new HandleRef(this, nativeCap), widthScale);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        private float _GetWidthScale()
        {
            float widthScale;
            int status = SafeNativeMethods.Gdip.GdipGetCustomLineCapWidthScale(new HandleRef(this, nativeCap), out widthScale);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return widthScale;
        }

        /// <summary>
        /// Gets or sets the amount by which to scale the width of the cap.
        /// </summary>
        public float WidthScale
        {
            get { return _GetWidthScale(); }
            set { _SetWidthScale(value); }
        }
    }
}

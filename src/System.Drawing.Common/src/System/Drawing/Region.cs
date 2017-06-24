// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Internal;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Drawing
{
    /// <summary>
    /// Describes the interior of a graphics shape composed of rectangles and paths.
    /// </summary>
    public sealed class Region : MarshalByRefObject, IDisposable
    {
#if FINALIZATION_WATCH
        private string allocationSite = Graphics.GetAllocationStack();
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class.
        /// </summary>
        public Region()
        {
            IntPtr region = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateRegion(out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeRegion(region);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class from the specified <see cref='RectangleF'/> .
        /// </summary>
        public Region(RectangleF rect)
        {
            IntPtr region = IntPtr.Zero;

            GPRECTF gprectf = rect.ToGPRECTF();

            int status = SafeNativeMethods.Gdip.GdipCreateRegionRect(ref gprectf, out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeRegion(region);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class from the specified <see cref='Rectangle'/>.
        /// </summary>
        public Region(Rectangle rect)
        {
            IntPtr region = IntPtr.Zero;

            GPRECT gprect = new GPRECT(rect);

            int status = SafeNativeMethods.Gdip.GdipCreateRegionRectI(ref gprect, out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeRegion(region);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class with the specified <see cref='GraphicsPath'/>.
        /// </summary>
        public Region(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            IntPtr region = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateRegionPath(new HandleRef(path, path.nativePath), out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeRegion(region);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class from the specified data.
        /// </summary>
        public Region(RegionData rgnData)
        {
            if (rgnData == null)
                throw new ArgumentNullException("rgnData");
            IntPtr region = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateRegionRgnData(rgnData.Data,
                                                         rgnData.Data.Length,
                                                         out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeRegion(region);
        }

        internal Region(IntPtr nativeRegion)
        {
            SetNativeRegion(nativeRegion);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Region'/> class from the specified existing <see cref='Region'/>.
        /// </summary>
        public static Region FromHrgn(IntPtr hrgn)
        {
            IntPtr region = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateRegionHrgn(new HandleRef(null, hrgn), out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return new Region(region);
        }

        private void SetNativeRegion(IntPtr nativeRegion)
        {
            if (nativeRegion == IntPtr.Zero)
                throw new ArgumentNullException("nativeRegion");

            this.nativeRegion = nativeRegion;
        }

        /// <summary>
        /// Creates an exact copy if this <see cref='Region'/>.
        /// </summary>
        public Region Clone()
        {
            IntPtr region = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneRegion(new HandleRef(this, nativeRegion), out region);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return new Region(region);
        }

        /// <summary>
        /// Cleans up Windows resources for this <see cref='Region'/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
#if FINALIZATION_WATCH
            if (!disposing && nativeRegion != IntPtr.Zero)
                Debug.WriteLine("**********************\nDisposed through finalization:\n" + allocationSite);
#endif
            if (nativeRegion != IntPtr.Zero)
            {
                try
                {
#if DEBUG
                    int status =
#endif
                    SafeNativeMethods.Gdip.GdipDeleteRegion(new HandleRef(this, nativeRegion));
#if DEBUG
                    Debug.Assert(status == SafeNativeMethods.Gdip.Ok, "GDI+ returned an error status: " + status.ToString(CultureInfo.InvariantCulture));
#endif
                }
                catch (Exception ex)
                {
                    if (ClientUtils.IsSecurityOrCriticalException(ex))
                    {
                        throw;
                    }

                    Debug.Fail("Exception thrown during Dispose: " + ex.ToString());
                }
                finally
                {
                    nativeRegion = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Cleans up Windows resources for this <see cref='Region'/>.
        /// </summary>
        ~Region()
        {
            Dispose(false);
        }

        // Region operations

        /// <summary>
        /// Initializes this <see cref='Region'/> to an infinite interior.
        /// </summary>
        public void MakeInfinite()
        {
            int status = SafeNativeMethods.Gdip.GdipSetInfinite(new HandleRef(this, nativeRegion));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Initializes this <see cref='Region'/> to an empty interior.
        /// </summary>
        public void MakeEmpty()
        {
            int status = SafeNativeMethods.Gdip.GdipSetEmpty(new HandleRef(this, nativeRegion));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the intersection of itself with the specified <see cref='RectangleF'/>.
        /// </summary>
        public void Intersect(RectangleF rect)
        {
            GPRECTF gprectf = rect.ToGPRECTF();
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRect(new HandleRef(this, nativeRegion), ref gprectf, CombineMode.Intersect);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the intersection of itself with the specified <see cref='Rectangle'/>.
        /// </summary>
        public void Intersect(Rectangle rect)
        {
            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRectI(new HandleRef(this, nativeRegion), ref gprect, CombineMode.Intersect);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the intersection of itself with the specified <see cref='GraphicsPath'/>. 
        /// </summary>
        public void Intersect(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionPath(new HandleRef(this, nativeRegion), new HandleRef(path, path.nativePath), CombineMode.Intersect);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the intersection of itself with the specified <see cref='Region'/>. 
        /// </summary>
        public void Intersect(Region region)
        {
            if (region == null)
                throw new ArgumentNullException("region");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion), CombineMode.Intersect);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Releases the handle to the region handle.
        /// </summary>
        public void ReleaseHrgn(IntPtr regionHandle)
        {
            if (regionHandle == IntPtr.Zero)
            {
                throw new ArgumentNullException("regionHandle");
            }

            SafeNativeMethods.IntDeleteObject(new HandleRef(this, regionHandle));
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union of itself and the specified <see cref='RectangleF'/>.
        /// </summary>
        public void Union(RectangleF rect)
        {
            GPRECTF gprectf = new GPRECTF(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRect(new HandleRef(this, nativeRegion), ref gprectf, CombineMode.Union);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union of itself and the specified <see cref='Rectangle'/>.
        /// </summary>
        public void Union(Rectangle rect)
        {
            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRectI(new HandleRef(this, nativeRegion), ref gprect, CombineMode.Union);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union of itself and the specified <see cref='GraphicsPath'/>.
        /// </summary>
        public void Union(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionPath(new HandleRef(this, nativeRegion), new HandleRef(path, path.nativePath), CombineMode.Union);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union of itself and the specified <see cref='Region'/>.
        /// </summary>
        public void Union(Region region)
        {
            if (region == null)
                throw new ArgumentNullException("region");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion), CombineMode.Union);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union minus the intersection of itself with the specified <see cref='RectangleF'/>.
        /// </summary>
        public void Xor(RectangleF rect)
        {
            GPRECTF gprectf = new GPRECTF(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRect(new HandleRef(this, nativeRegion), ref gprectf, CombineMode.Xor);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union minus the intersection of itself with the specified <see cref='Rectangle'/>.
        /// </summary>
        public void Xor(Rectangle rect)
        {
            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRectI(new HandleRef(this, nativeRegion), ref gprect, CombineMode.Xor);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union minus the intersection of itself with the specified
        /// <see cref='GraphicsPath'/>.
        /// </summary>
        public void Xor(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionPath(new HandleRef(this, nativeRegion), new HandleRef(path, path.nativePath), CombineMode.Xor);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the union minus the intersection of itself with the specified
        /// <see cref='Region'/>.
        /// </summary>
        public void Xor(Region region)
        {
            if (region == null)
                throw new ArgumentNullException("region");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion), CombineMode.Xor);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of its interior that does not intersect with the specified
        /// <see cref='RectangleF'/>.
        /// </summary>
        public void Exclude(RectangleF rect)
        {
            GPRECTF gprectf = new GPRECTF(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRect(new HandleRef(this, nativeRegion), ref gprectf, CombineMode.Exclude);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of its interior that does not intersect with the specified
        /// <see cref='Rectangle'/>.
        /// </summary>
        public void Exclude(Rectangle rect)
        {
            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRectI(new HandleRef(this, nativeRegion), ref gprect, CombineMode.Exclude);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of its interior that does not intersect with the specified
        /// <see cref='GraphicsPath'/>.
        /// </summary>
        public void Exclude(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionPath(new HandleRef(this, nativeRegion), new HandleRef(path, path.nativePath),
                                                       CombineMode.Exclude);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of its interior that does not intersect with the specified
        /// <see cref='Region'/>.
        /// </summary>
        public void Exclude(Region region)
        {
            if (region == null)
                throw new ArgumentNullException("region");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion),
                                                         CombineMode.Exclude);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of the specified <see cref='RectangleF'/> that does not
        /// intersect with this <see cref='Region'/>.
        /// </summary>
        public void Complement(RectangleF rect)
        {
            GPRECTF gprectf = rect.ToGPRECTF();
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRect(new HandleRef(this, nativeRegion), ref gprectf, CombineMode.Complement);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of the specified <see cref='Rectangle'/> that does not
        /// intersect with this <see cref='Region'/>.
        /// </summary>
        public void Complement(Rectangle rect)
        {
            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipCombineRegionRectI(new HandleRef(this, nativeRegion), ref gprect, CombineMode.Complement);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of the specified <see cref='GraphicsPath'/> that does not
        /// intersect with this <see cref='Region'/>.
        /// </summary>
        public void Complement(GraphicsPath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionPath(new HandleRef(this, nativeRegion), new HandleRef(path, path.nativePath), CombineMode.Complement);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Updates this <see cref='Region'/> to the portion of the specified <see cref='Region'/> that does not intersect
        /// with this <see cref='Region'/>.
        /// </summary>
        public void Complement(Region region)
        {
            if (region == null)
                throw new ArgumentNullException("region");

            int status = SafeNativeMethods.Gdip.GdipCombineRegionRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion), CombineMode.Complement);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Offsets the coordinates of this <see cref='Region'/> by the specified amount.
        /// </summary>
        public void Translate(float dx, float dy)
        {
            int status = SafeNativeMethods.Gdip.GdipTranslateRegion(new HandleRef(this, nativeRegion), dx, dy);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Offsets the coordinates of this <see cref='Region'/> by the specified amount.
        /// </summary>
        public void Translate(int dx, int dy)
        {
            int status = SafeNativeMethods.Gdip.GdipTranslateRegionI(new HandleRef(this, nativeRegion), dx, dy);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Transforms this <see cref='Region'/> by the specified <see cref='Matrix'/>.
        /// </summary>
        public void Transform(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            int status = SafeNativeMethods.Gdip.GdipTransformRegion(new HandleRef(this, nativeRegion),
                                                     new HandleRef(matrix, matrix.nativeMatrix));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        /// Returns a <see cref='System.Drawing.RectangleF'/> that represents a rectangular region that bounds this
        /// <see cref='Region'/> on the drawing surface of a <see cref='Graphics'/>.
        /// </summary>
        public RectangleF GetBounds(Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            GPRECTF gprectf = new GPRECTF();

            int status = SafeNativeMethods.Gdip.GdipGetRegionBounds(new HandleRef(this, nativeRegion), new HandleRef(g, g.NativeGraphics), ref gprectf);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return gprectf.ToRectangleF();
        }

        /// <summary>
        /// Returns a Windows handle to this <see cref='Region'/> in the specified graphics context.
        /// Remarks from MSDN: 
        ///   It is the caller's responsibility to call the GDI function 
        ///   DeleteObject to free the GDI region when it is no longer needed.
        /// </summary>
        public IntPtr GetHrgn(Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            IntPtr hrgn = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipGetRegionHRgn(new HandleRef(this, nativeRegion), new HandleRef(g, g.NativeGraphics), out hrgn);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return hrgn;
        }

        /// <summary>
        /// Tests whether this <see cref='Region'/> has an empty interior on the specified drawing surface.
        /// </summary>
        public bool IsEmpty(Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            int isEmpty;
            int status = SafeNativeMethods.Gdip.GdipIsEmptyRegion(new HandleRef(this, nativeRegion), new HandleRef(g, g.NativeGraphics), out isEmpty);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isEmpty != 0;
        }

        /// <summary>
        /// Tests whether this <see cref='Region'/> has an infinite interior on the specified drawing surface.
        /// </summary>
        public bool IsInfinite(Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            int isInfinite;
            int status = SafeNativeMethods.Gdip.GdipIsInfiniteRegion(new HandleRef(this, nativeRegion), new HandleRef(g, g.NativeGraphics), out isInfinite);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isInfinite != 0;
        }

        /// <summary>
        /// Tests whether the specified <see cref='Region'/> is identical to this <see cref='Region'/> on the specified drawing surface.
        /// </summary>
        public bool Equals(Region region, Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            if (region == null)
                throw new ArgumentNullException("region");

            int isEqual;
            int status = SafeNativeMethods.Gdip.GdipIsEqualRegion(new HandleRef(this, nativeRegion), new HandleRef(region, region.nativeRegion), new HandleRef(g, g.NativeGraphics), out isEqual);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isEqual != 0;
        }

        /// <summary>
        /// Returns a <see cref='RegionData'/> that represents the information that describes this <see cref='Region'/>.
        /// </summary>
        public RegionData GetRegionData()
        {
            int regionSize = 0;

            int status = SafeNativeMethods.Gdip.GdipGetRegionDataSize(new HandleRef(this, nativeRegion), out regionSize);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            if (regionSize == 0)
                return null;

            byte[] regionData = new byte[regionSize];

            status = SafeNativeMethods.Gdip.GdipGetRegionData(new HandleRef(this, nativeRegion), regionData, regionSize, out regionSize);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return new RegionData(regionData);
        }

        /// <summary>
        /// Tests whether the specified point is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(float x, float y)
        {
            return IsVisible(new PointF(x, y), null);
        }

        /// <summary>
        /// Tests whether the specified <see cref='PointF'/> is contained within this <see cref='Region'/>.
        /// </summary>
        public bool IsVisible(PointF point)
        {
            return IsVisible(point, null);
        }

        /// <summary>
        /// Tests whether the specified point is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(float x, float y, Graphics g)
        {
            return IsVisible(new PointF(x, y), g);
        }

        /// <summary>
        /// Tests whether the specified <see cref='PointF'/> is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(PointF point, Graphics g)
        {
            int isVisible;

            int status = SafeNativeMethods.Gdip.GdipIsVisibleRegionPoint(new HandleRef(this, nativeRegion), point.X, point.Y,
                                                          new HandleRef(g, (g == null) ? IntPtr.Zero : g.NativeGraphics),
                                                          out isVisible);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isVisible != 0;
        }

        /// <summary>
        /// Tests whether the specified rectangle is contained within this <see cref='Region'/>.
        /// </summary>
        public bool IsVisible(float x, float y, float width, float height)
        {
            return IsVisible(new RectangleF(x, y, width, height), null);
        }

        /// <summary>
        /// Tests whether the specified <see cref='RectangleF'/> is contained within this <see cref='Region'/>. 
        /// </summary>
        public bool IsVisible(RectangleF rect)
        {
            return IsVisible(rect, null);
        }

        /// <summary>
        /// Tests whether the specified rectangle is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(float x, float y, float width, float height, Graphics g)
        {
            return IsVisible(new RectangleF(x, y, width, height), g);
        }

        /// <summary>
        /// Tests whether the specified <see cref='RectangleF'/> is contained within this <see cref='Region'/> in the
        /// specified graphics context.
        /// </summary>
        public bool IsVisible(RectangleF rect, Graphics g)
        {
            int isVisible = 0;
            int status = SafeNativeMethods.Gdip.GdipIsVisibleRegionRect(new HandleRef(this, nativeRegion), rect.X, rect.Y,
                                                         rect.Width, rect.Height,
                                                         new HandleRef(g, (g == null) ? IntPtr.Zero : g.NativeGraphics),
                                                         out isVisible);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isVisible != 0;
        }

        /// <summary>
        /// Tests whether the specified point is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(int x, int y, Graphics g)
        {
            return IsVisible(new Point(x, y), g);
        }

        /// <summary>
        /// Tests whether the specified <see cref='Point'/> is contained within this <see cref='Region'/>.
        /// </summary>
        public bool IsVisible(Point point)
        {
            return IsVisible(point, null);
        }

        /// <summary>
        /// Tests whether the specified <see cref='System.Drawing.Point'/> is contained within this <see cref='Region'/>
        /// in the specified graphics context.
        /// </summary>
        public bool IsVisible(Point point, Graphics g)
        {
            int isVisible = 0;
            int status = SafeNativeMethods.Gdip.GdipIsVisibleRegionPointI(new HandleRef(this, nativeRegion), point.X, point.Y,
                                                           new HandleRef(g, (g == null) ? IntPtr.Zero : g.NativeGraphics),
                                                           out isVisible);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isVisible != 0;
        }

        /// <summary>
        /// Tests whether the specified rectangle is contained within this <see cref='Region'/>.
        /// </summary>
        public bool IsVisible(int x, int y, int width, int height)
        {
            return IsVisible(new Rectangle(x, y, width, height), null);
        }

        /// <summary>
        /// Tests whether the specified <see cref='Rectangle'/> is contained within this <see cref='Region'/>. 
        /// </summary>
        public bool IsVisible(Rectangle rect)
        {
            return IsVisible(rect, null);
        }

        /// <summary>
        /// Tests whether the specified rectangle is contained within this <see cref='Region'/> in the specified graphics context.
        /// </summary>
        public bool IsVisible(int x, int y, int width, int height, Graphics g)
        {
            return IsVisible(new Rectangle(x, y, width, height), g);
        }

        /// <summary>
        /// Tests whether the specified <see cref='Rectangle'/> is contained within this <see cref='Region'/> in the specified
        /// graphics context.
        /// </summary>
        public bool IsVisible(Rectangle rect, Graphics g)
        {
            int isVisible = 0;
            int status = SafeNativeMethods.Gdip.GdipIsVisibleRegionRectI(new HandleRef(this, nativeRegion), rect.X, rect.Y,
                                                          rect.Width, rect.Height,
                                                          new HandleRef(g, (g == null) ? IntPtr.Zero : g.NativeGraphics),
                                                          out isVisible);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return isVisible != 0;
        }

        /// <summary>
        /// Returns an array of <see cref='RectangleF'/> objects that approximate this Region on the specified
        /// </summary>        
        public RectangleF[] GetRegionScans(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            int count = 0;

            // call first time to get actual count of rectangles

            int status = SafeNativeMethods.Gdip.GdipGetRegionScansCount(new HandleRef(this, nativeRegion),
                                                         out count,
                                                         new HandleRef(matrix, matrix.nativeMatrix));

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            RectangleF[] rectangles;
            int rectsize = (int)Marshal.SizeOf(typeof(GPRECTF));
            IntPtr memoryRects = Marshal.AllocHGlobal(checked(rectsize * count));

            try
            {
                status = SafeNativeMethods.Gdip.GdipGetRegionScans(new HandleRef(this, nativeRegion),
                    memoryRects,
                    out count,
                    new HandleRef(matrix, matrix.nativeMatrix));

                if (status != SafeNativeMethods.Gdip.Ok)
                {
                    throw SafeNativeMethods.Gdip.StatusException(status);
                }

                int index;
                GPRECTF gprectf = new GPRECTF();

                rectangles = new RectangleF[count];

                for (index = 0; index < count; index++)
                {
                    gprectf = (GPRECTF)UnsafeNativeMethods.PtrToStructure((IntPtr)(checked((long)memoryRects + rectsize * index)), typeof(GPRECTF));
                    rectangles[index] = gprectf.ToRectangleF();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(memoryRects);
            }

            return rectangles;
        }

        internal IntPtr nativeRegion;
    }
}

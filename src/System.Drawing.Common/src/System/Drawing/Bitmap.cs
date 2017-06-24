// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing
{
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Drawing.Imaging;
    using System.Drawing.Internal;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    /// <summary>
    ///    Encapsultates a GDI+ bitmap.
    /// </summary>
    /**
     * Represent a bitmap image
     */
    [ComVisible(true)]
    public sealed partial class Bitmap : Image
    {
        private static Color s_defaultTransparentColor = Color.LightGray;

        /*
         * Predefined bitmap data formats
         */

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class from the specified file.
        /// </summary>
        /**
         * Create a new bitmap object from URL
         */
        public Bitmap(String filename)
        {
            //GDI+ will read this file multiple times.  Get the fully qualified path
            //so if our app changes default directory we won't get an error
            //
            filename = Path.GetFullPath(filename);

            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromFile(filename, out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            SetNativeImage(bitmap);

            EnsureSave(this, filename, null);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Bitmap'/> class from the specified
        ///       file.
        ///    
        /// </summary>
        public Bitmap(String filename, bool useIcm)
        {
            //GDI+ will read this file multiple times.  Get the fully qualified path
            //so if our app changes default directory we won't get an error
            //
            filename = Path.GetFullPath(filename);

            IntPtr bitmap = IntPtr.Zero;
            int status;

            if (useIcm)
            {
                status = SafeNativeMethods.Gdip.GdipCreateBitmapFromFileICM(filename, out bitmap);
            }
            else
            {
                status = SafeNativeMethods.Gdip.GdipCreateBitmapFromFile(filename, out bitmap);
            }

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            SetNativeImage(bitmap);

            EnsureSave(this, filename, null);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Bitmap'/> class from a specified resource.
        ///    
        /// </summary>
        public Bitmap(Type type, string resource)
        {
            Stream stream = type.Module.Assembly.GetManifestResourceStream(type, resource);
            if (stream == null)
                throw new ArgumentException(SR.Format(SR.ResourceNotFound, type, resource));

            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromStream(new GPStream(stream), out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            SetNativeImage(bitmap);

            EnsureSave(this, null, stream);
        }

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class from the specified data stream.
        /// </summary>
        /**
         * Create a new bitmap object from a stream
         */
        public Bitmap(Stream stream)
        {
            if (stream == null)
                throw new ArgumentException(SR.Format(SR.InvalidArgument, "stream", "null"));

            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromStream(new GPStream(stream), out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            SetNativeImage(bitmap);

            EnsureSave(this, null, stream);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Bitmap'/> class from the specified data
        ///       stream.
        ///    
        /// </summary>
        public Bitmap(Stream stream, bool useIcm)
        {
            if (stream == null)
                throw new ArgumentException(SR.Format(SR.InvalidArgument, "stream", "null"));

            IntPtr bitmap = IntPtr.Zero;
            int status;

            if (useIcm)
            {
                status = SafeNativeMethods.Gdip.GdipCreateBitmapFromStreamICM(new GPStream(stream), out bitmap);
            }
            else
            {
                status = SafeNativeMethods.Gdip.GdipCreateBitmapFromStream(new GPStream(stream), out bitmap);
            }

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            SetNativeImage(bitmap);

            EnsureSave(this, null, stream);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the
        ///       Bitmap class with the specified size, pixel format, and pixel data.
        ///    
        /// </summary>
        public Bitmap(int width, int height, int stride, PixelFormat format, IntPtr scan0)
        {
            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromScan0(width, height, stride, unchecked((int)format), new HandleRef(null, scan0), out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeImage(bitmap);
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the Bitmap class with the specified
        ///       size and format.
        ///    
        /// </summary>
        public Bitmap(int width, int height, PixelFormat format)
        {
            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromScan0(width, height, 0, unchecked((int)format), NativeMethods.NullHandleRef, out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeImage(bitmap);
        }

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class with the specified size.
        /// </summary>
        public Bitmap(int width, int height) : this(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class with the specified size and target <see cref='System.Drawing.Graphics'/>.
        /// </summary>
        public Bitmap(int width, int height, Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException(SR.Format(SR.InvalidArgument, "g", "null"));

            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromGraphics(width, height, new HandleRef(g, g.NativeGraphics), out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            SetNativeImage(bitmap);
        }

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class, from the specified existing image, with the specified size.
        /// </summary>
        public Bitmap(Image original) : this(original, original.Width, original.Height)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the
        /// <see cref='System.Drawing.Bitmap'/> 
        /// class, from the specified existing image, with the specified size.
        /// </summary>
        public Bitmap(Image original, int width, int height) : this(width, height)
        {
            Graphics g = null;
            try
            {
                g = Graphics.FromImage(this);
                g.Clear(Color.Transparent);
                g.DrawImage(original, 0, 0, width, height);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }

        /// <summary>
        ///    Creates a <see cref='System.Drawing.Bitmap'/> from a Windows handle to an
        ///    Icon.
        /// </summary>
        public static Bitmap FromHicon(IntPtr hicon)
        {
            IntPtr bitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromHICON(new HandleRef(null, hicon), out bitmap);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return Bitmap.FromGDIplus(bitmap);
        }

        /// <summary>
        /// </summary>
        public static Bitmap FromResource(IntPtr hinstance, String bitmapName)
        {
            IntPtr bitmap;

            IntPtr name = Marshal.StringToHGlobalUni(bitmapName);

            int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromResource(new HandleRef(null, hinstance),
                                                              new HandleRef(null, name),
                                                              out bitmap);
            Marshal.FreeHGlobal(name);

            if (status != SafeNativeMethods.Gdip.Ok)
            {
                throw SafeNativeMethods.Gdip.StatusException(status);
            }

            return Bitmap.FromGDIplus(bitmap);
        }

        /// <summary>
        ///    
        ///       Creates a Win32 HBITMAP out of the image. You are responsible for
        ///       de-allocating the HBITMAP with Windows.DeleteObject(handle). If the image uses
        ///       transparency, the background will be filled with the specified background
        ///       color.
        ///    
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IntPtr GetHbitmap()
        {
            return GetHbitmap(Color.LightGray);
        }

        /// <summary>
        ///     Creates a Win32 HBITMAP out of the image.  You are responsible for
        ///     de-allocating the HBITMAP with Windows.DeleteObject(handle).
        ///     If the image uses transparency, the background will be filled with the specified background color.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IntPtr GetHbitmap(Color background)
        {
            IntPtr hBitmap = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateHBITMAPFromBitmap(new HandleRef(this, nativeImage), out hBitmap,
                                                             ColorTranslator.ToWin32(background));
            if (status == 2 /* invalid parameter*/ && (Width >= Int16.MaxValue || Height >= Int16.MaxValue))
            {
                throw (new ArgumentException(SR.Format(SR.GdiplusInvalidSize)));
            }

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return hBitmap;
        }

        /// <summary>
        ///    Returns the handle to an icon.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IntPtr GetHicon()
        {
            IntPtr hIcon = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCreateHICONFromBitmap(new HandleRef(this, nativeImage), out hIcon);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return hIcon;
        }

        /// <summary>
        ///    
        ///       Initializes a new instance of the <see cref='System.Drawing.Bitmap'/> class, from the specified
        ///       existing image, with the specified size.
        ///    
        /// </summary>
        public Bitmap(Image original, Size newSize) :
        this(original, (object)newSize != null ? newSize.Width : 0, (object)newSize != null ? newSize.Height : 0)
        {
        }

        // for use with CreateFromGDIplus
        private Bitmap()
        {
        }

        /*
         * Create a new bitmap object from a native bitmap handle.
         * This is only for internal purpose.
         */
        internal static Bitmap FromGDIplus(IntPtr handle)
        {
            Bitmap result = new Bitmap();
            result.SetNativeImage(handle);
            return result;
        }

        /// <summary>
        ///    Creates a copy of the section of this
        ///    Bitmap defined by <paramref term="rect"/> with a specified <see cref='System.Drawing.Imaging.PixelFormat'/>.
        /// </summary>
        // int version
        public Bitmap Clone(Rectangle rect, PixelFormat format)
        {
            //validate the rect
            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            IntPtr dstHandle = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneBitmapAreaI(
                                                     rect.X,
                                                     rect.Y,
                                                     rect.Width,
                                                     rect.Height,
                                                     unchecked((int)format),
                                                     new HandleRef(this, nativeImage),
                                                     out dstHandle);

            if (status != SafeNativeMethods.Gdip.Ok || dstHandle == IntPtr.Zero)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return Bitmap.FromGDIplus(dstHandle);
        }

        /// <summary>
        ///    
        ///       Creates a copy of the section of this
        ///       Bitmap defined by <paramref term="rect"/> with a specified <see cref='System.Drawing.Imaging.PixelFormat'/>.
        ///    
        /// </summary>
        // float version
        public Bitmap Clone(RectangleF rect, PixelFormat format)
        {
            //validate the rect
            if (rect.Width == 0 || rect.Height == 0)
            {
                throw new ArgumentException(SR.Format(SR.GdiplusInvalidRectangle, rect.ToString()));
            }

            IntPtr dstHandle = IntPtr.Zero;

            int status = SafeNativeMethods.Gdip.GdipCloneBitmapArea(
                                                    rect.X,
                                                    rect.Y,
                                                    rect.Width,
                                                    rect.Height,
                                                    unchecked((int)format),
                                                    new HandleRef(this, nativeImage),
                                                    out dstHandle);

            if (status != SafeNativeMethods.Gdip.Ok || dstHandle == IntPtr.Zero)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return Bitmap.FromGDIplus(dstHandle);
        }

        /// <summary>
        ///    
        ///       Makes the default transparent color transparent for this <see cref='System.Drawing.Bitmap'/>
        ///       .
        ///    
        /// </summary>
        public void MakeTransparent()
        {
            Color transparent = s_defaultTransparentColor;
            if (Height > 0 && Width > 0)
                transparent = GetPixel(0, Size.Height - 1);
            if (transparent.A < 255)
            {
                // It's already transparent, and if we proceeded, we will do something
                // unintended like making black transparent
                return;
            }
            MakeTransparent(transparent);
        }

        /// <summary>
        ///    Makes the specified color transparent
        ///    for this <see cref='System.Drawing.Bitmap'/>.
        /// </summary>        
        public void MakeTransparent(Color transparentColor)
        {
            if (RawFormat.Guid == ImageFormat.Icon.Guid)
            {
                throw new InvalidOperationException(SR.Format(SR.CantMakeIconTransparent));
            }

            Size size = Size;

            // The new bitmap must be in 32bppARGB  format, because that's the only
            // thing that supports alpha.  (And that's what the image is initialized to -- transparent)
            Bitmap result = null;
            Graphics graphics = null;
            try
            {
                result = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                try
                {
                    graphics = Graphics.FromImage(result);
                    graphics.Clear(Color.Transparent);
                    Rectangle rectangle = new Rectangle(0, 0, size.Width, size.Height);

                    ImageAttributes attributes = null;
                    try
                    {
                        attributes = new ImageAttributes();
                        attributes.SetColorKey(transparentColor, transparentColor);
                        graphics.DrawImage(this, rectangle,
                                           0, 0, size.Width, size.Height,
                                           GraphicsUnit.Pixel, attributes, null, IntPtr.Zero);
                    }
                    finally
                    {
                        if (attributes != null)
                        {
                            attributes.Dispose();
                        }
                    }
                }
                finally
                {
                    if (graphics != null)
                    {
                        graphics.Dispose();
                    }
                }

                // Swap nativeImage pointers to make it look like we modified the image in place
                IntPtr temp = nativeImage;
                nativeImage = result.nativeImage;
                result.nativeImage = temp;
            }
            finally
            {
                if (result != null)
                {
                    result.Dispose();
                }
            }
        }

        /// <summary>
        ///    Locks a Bitmap into system memory.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public BitmapData LockBits(Rectangle rect, ImageLockMode flags, PixelFormat format)
        {
            Contract.Ensures(Contract.Result<BitmapData>() != null);

            BitmapData bitmapData = new BitmapData();

            return LockBits(rect, flags, format, bitmapData);
        }

        /// <summary>
        ///    Locks a Bitmap into system memory.  This overload takes a user-defined
        ///    BitmapData object and is intended to be used with an ImageLockMode.UserInputBuffer.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public BitmapData LockBits(Rectangle rect, ImageLockMode flags, PixelFormat format, BitmapData bitmapData)
        {
            Contract.Ensures(Contract.Result<BitmapData>() != null);

            GPRECT gprect = new GPRECT(rect);
            int status = SafeNativeMethods.Gdip.GdipBitmapLockBits(new HandleRef(this, nativeImage), ref gprect,
                                                    flags, format, bitmapData);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return bitmapData;
        }


        /// <summary>
        ///    Unlocks this <see cref='System.Drawing.Bitmap'/> from system memory.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void UnlockBits(BitmapData bitmapdata)
        {
            int status = SafeNativeMethods.Gdip.GdipBitmapUnlockBits(new HandleRef(this, nativeImage), bitmapdata);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    
        ///       Gets the color of the specified pixel
        ///       in this <see cref='System.Drawing.Bitmap'/>.
        ///    
        /// </summary>
        public Color GetPixel(int x, int y)
        {
            int color = 0;

            if (x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException("x", SR.Format(SR.ValidRangeX));
            }

            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("y", SR.Format(SR.ValidRangeY));
            }

            int status = SafeNativeMethods.Gdip.GdipBitmapGetPixel(new HandleRef(this, nativeImage), x, y, out color);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);

            return Color.FromArgb(color);
        }

        /// <summary>
        ///    
        ///       Sets the color of the specified pixel in this <see cref='System.Drawing.Bitmap'/> .
        ///    
        /// </summary>
        public void SetPixel(int x, int y, Color color)
        {
            if ((PixelFormat & PixelFormat.Indexed) != 0)
            {
                throw new InvalidOperationException(SR.Format(SR.GdiplusCannotSetPixelFromIndexedPixelFormat));
            }

            if (x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException("x", SR.Format(SR.ValidRangeX));
            }

            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("y", SR.Format(SR.ValidRangeY));
            }

            int status = SafeNativeMethods.Gdip.GdipBitmapSetPixel(new HandleRef(this, nativeImage), x, y, color.ToArgb());

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        /// <summary>
        ///    Sets the resolution for this <see cref='System.Drawing.Bitmap'/>.
        /// </summary>
        public void SetResolution(float xDpi, float yDpi)
        {
            int status = SafeNativeMethods.Gdip.GdipBitmapSetResolution(new HandleRef(this, nativeImage), xDpi, yDpi);

            if (status != SafeNativeMethods.Gdip.Ok)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }
    }
}

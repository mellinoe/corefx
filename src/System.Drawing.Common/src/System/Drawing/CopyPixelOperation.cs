// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing
{
    /// <summary>
    ///    
    ///       Specifies the
    ///       Copy Pixel (ROP) operation.
    ///    
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public enum CopyPixelOperation
    {
        /// <summary>
        ///    
        ///       Fills the Destination Rectangle using the color associated with the index 0 in the physical palette.
        ///    
        /// </summary>
        Blackness = SafeNativeMethods.BLACKNESS,

        /// <summary>
        ///    
        ///       Includes any windows that are Layered on Top.
        ///    
        /// </summary>
        CaptureBlt = SafeNativeMethods.CAPTUREBLT,

        /// <summary>
        ///    
        ///       DestinationInvert.
        ///    
        /// </summary>
        DestinationInvert = SafeNativeMethods.DSTINVERT,

        /// <summary>
        ///    
        ///       MergeCopy.
        ///    
        /// </summary>
        MergeCopy = SafeNativeMethods.MERGECOPY,

        /// <summary>
        ///    
        ///       MergePaint.
        ///    
        /// </summary>
        MergePaint = SafeNativeMethods.MERGEPAINT,


        /// <summary>
        ///    
        ///       NoMirrorBitmap.
        ///    
        /// </summary>
        NoMirrorBitmap = SafeNativeMethods.NOMIRRORBITMAP,


        /// <summary>
        ///    
        ///       NotSourceCopy.
        ///    
        /// </summary>
        NotSourceCopy = SafeNativeMethods.NOTSRCCOPY,


        /// <summary>
        ///    
        ///       NotSourceErase.
        ///    
        /// </summary>
        NotSourceErase = SafeNativeMethods.NOTSRCERASE,



        /// <summary>
        ///    
        ///       PatCopy.
        ///    
        /// </summary>
        PatCopy = SafeNativeMethods.PATCOPY,



        /// <summary>
        ///    
        ///       PatInvert.
        ///    
        /// </summary>
        PatInvert = SafeNativeMethods.PATINVERT,


        /// <summary>
        ///    
        ///       PatPaint.
        ///    
        /// </summary>
        PatPaint = SafeNativeMethods.PATPAINT,

        /// <summary>
        ///    
        ///       SourceAnd.
        ///    
        /// </summary>
        SourceAnd = SafeNativeMethods.SRCAND,

        /// <summary>
        ///    
        ///       SourceCopy.
        ///    
        /// </summary>
        SourceCopy = SafeNativeMethods.SRCCOPY,

        /// <summary>
        ///    
        ///       SourceErase.
        ///    
        /// </summary>
        SourceErase = SafeNativeMethods.SRCERASE,

        /// <summary>
        ///    
        ///       SourceInvert.
        ///    
        /// </summary>
        SourceInvert = SafeNativeMethods.SRCINVERT,

        /// <summary>
        ///    
        ///       SourcePaint.
        ///    
        /// </summary>
        SourcePaint = SafeNativeMethods.SRCPAINT,

        /// <summary>
        ///    
        ///       Whiteness.
        ///    
        /// </summary>
        Whiteness = SafeNativeMethods.WHITENESS,
    }
}

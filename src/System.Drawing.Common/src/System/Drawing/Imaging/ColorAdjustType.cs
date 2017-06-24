// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Imaging
{
    /**
     * Color adjust type constants
     */
    /// <summary>
    ///    Specifies which GDI+ objects use color
    ///    adjustment information.
    /// </summary>
    public enum ColorAdjustType
    {
        /// <summary>
        ///    Defines color adjustment information that is
        ///    used by all GDI+ objects that do not have their own color adjustment
        ///    information.
        /// </summary>
        Default = 0,
        /// <summary>
        ///    Defines color adjustment information for
        /// <see cref='System.Drawing.Bitmap'/> 
        /// objects.
        /// </summary>
        Bitmap,
        /// <summary>
        ///    
        ///       Defines color adjustment information for <see cref='System.Drawing.Brush'/> objects.
        ///    
        /// </summary>
        Brush,
        /// <summary>
        ///    
        ///       Defines color adjustment information for <see cref='System.Drawing.Pen'/> objects.
        ///    
        /// </summary>
        Pen,
        /// <summary>
        ///    
        ///       Defines color adjustment information for text.
        ///    
        /// </summary>
        Text,
        /// <summary>
        ///    Specifies the number of types specified.
        /// </summary>
        Count,
        /// <summary>
        ///    
        ///       Specifies the number of types specified.
        ///    
        /// </summary>
        Any
    }
}


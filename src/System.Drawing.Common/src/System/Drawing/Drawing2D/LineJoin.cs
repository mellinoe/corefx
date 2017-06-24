// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Line join constants
     */
    /// <summary>
    ///    
    ///       Specifies how to join two intersecting lines in a
    ///    <see cref='System.Drawing.Drawing2D.GraphicsPath'/> at their intersection.
    ///    
    /// </summary>
    public enum LineJoin
    {
        /// <summary>
        ///    Specifies an angled miter join.
        /// </summary>
        Miter = 0,
        /// <summary>
        ///    
        ///       Specifies a beveled join.
        ///    
        /// </summary>
        Bevel = 1,
        /// <summary>
        ///    Specifies a smooth, rounded join.
        /// </summary>
        Round = 2,
        /// <summary>
        ///    Specifies a mitered clipped join
        /// </summary>
        MiterClipped = 3
    }
}

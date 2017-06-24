// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Path Point Type
     */
    /// <summary>
    ///    
    ///       Specifies the type of graphical point
    ///       contained at a specific point in a <see cref='System.Drawing.Drawing2D.GraphicsPath'/>.
    ///    
    /// </summary>
    public enum PathPointType
    {
        /// <summary>
        ///    Specifies the starting point of a <see cref='System.Drawing.Drawing2D.GraphicsPath'/>.
        /// </summary>
        Start = 0,    // move
        /// <summary>
        ///    Specifies a line segment.
        /// </summary>
        Line = 1,    // line
        /// <summary>
        ///    Specifies a default Bezier curve.
        /// </summary>
        Bezier = 3,    // default Beizer (= cubic Bezier)
        /// <summary>
        ///    Specifies a mask point.
        /// </summary>
        PathTypeMask = 0x07, // type mask (lowest 3 bits).
        /// <summary>
        ///    
        ///       Specifies that the corresponding segment is dashed.
        ///    
        /// </summary>
        DashMode = 0x10, // currently in dash mode.
        /// <summary>
        ///    Specifies a path marker.
        /// </summary>
        PathMarker = 0x20, // a marker for the path.
        /// <summary>
        ///    Specifies the ending point of a subpath.
        /// </summary>
        CloseSubpath = 0x80, // closed flag

        // Path types used for advanced path.

        /// <summary>
        ///    Specifies a cubic Bezier curve.
        /// </summary>
        Bezier3 = 3,    // cubic Bezier
    }
}

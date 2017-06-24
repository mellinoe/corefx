// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * PenType Type
     */
    /// <summary>
    ///    
    ///       Specifies the type of fill a <see cref='System.Drawing.Pen'/> uses to
    ///       fill lines.
    ///    
    /// </summary>
    public enum PenType
    {
        /// <summary>
        ///    Specifies a solid fill.
        /// </summary>
        SolidColor = BrushType.SolidColor,
        /// <summary>
        ///    Specifies a hatch fill.
        /// </summary>
        HatchFill = BrushType.HatchFill,
        /// <summary>
        ///    Specifies a bitmap texture fill.
        /// </summary>
        TextureFill = BrushType.TextureFill,
        /// <summary>
        ///    Specifies a path gradient fill.
        /// </summary>
        PathGradient = BrushType.PathGradient,
        /// <summary>
        ///    Specifies a linear gradient fill.
        /// </summary>
        LinearGradient = BrushType.LinearGradient,
    }
}

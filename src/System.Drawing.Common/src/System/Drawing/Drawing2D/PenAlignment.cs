// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the algnment of a <see cref='Pen'/> in relation to the line being drawn.
    /// </summary>
    public enum PenAlignment
    {
        /// <summary>
        /// Specifies that the <see cref='Pen'/> is positioned at the center of the line being drawn.
        /// </summary>
        Center = 0,
        /// <summary>
        /// Specifies that the <see cref='Pen'/> is positioned on the insede of the line being drawn.
        /// </summary>
        Inset = 1,
        /// <summary>
        /// Specifies that the <see cref='Pen'/> is positioned on the outside of the line being drawn.
        /// </summary>
        Outset = 2,
        /// <summary>
        /// Specifies that the <see cref='Pen'/> is positioned to the left of the line being drawn.
        /// </summary>
        Left = 3,
        /// <summary>
        /// Specifies that the <see cref='Pen'/> is positioned to the right of the line being drawn.
        /// </summary>
        Right = 4
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies how a texture or gradient is tiled when it is larger than the area being filled.
    /// </summary>
    public enum WrapMode
    {
        /// <summary>
        /// Tiles the gradient or texture.
        /// </summary>
        Tile = 0,
        /// <summary>
        /// Reverses the texture or gradient horizontally and then tiles the texture or gradient.
        /// </summary>
        TileFlipX = 1,
        /// <summary>
        /// Reverses the texture or gradient vertically and then tiles the texture or gradient.
        /// </summary>
        TileFlipY = 2,
        /// <summary>
        /// Reverses the texture or gradient horizontally and vertically and then tiles the texture or gradient.
        /// </summary>
        TileFlipXY = 3,
        /// <summary>
        /// Clamps the texture or gradient to the object boundary.
        /// </summary>
        Clamp = 4
    }
}

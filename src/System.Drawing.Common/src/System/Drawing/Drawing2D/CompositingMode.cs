// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Defines how the source image is composited with the background image.
    /// </summary>
    public enum CompositingMode
    {
        /// <summary>
        /// The source pixels overwrite the background pixels.
        /// </summary>
        SourceOver = 0,
        /// <summary>
        /// The source pixels are combined with the background pixels.
        /// </summary>
        SourceCopy = 1
    }
}

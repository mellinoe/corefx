// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the direction of a linear gradient.
    /// </summary>
    public enum LinearGradientMode
    {
        /// <summary>
        /// Specifies a gradient from left to right.
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// Specifies a gradient from top to bottom.
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// Specifies a gradient from upper-left to lower-right.
        /// </summary>
        ForwardDiagonal = 2,
        /// <summary>
        /// Specifies a gradient from upper-right to lower-left.
        /// </summary>
        BackwardDiagonal = 3
    }
}

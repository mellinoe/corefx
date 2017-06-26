// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the style of dashed lines drawn with a <see cref='Pen'/> .
    /// </summary>
    public enum DashStyle
    {
        /// <summary>
        /// Specifies a solid line.
        /// </summary>
        Solid = 0,
        /// <summary>
        /// Specifies a line comprised of dashes.
        /// </summary>
        Dash = 1,
        /// <summary>
        /// Specifies a line comprised of dots.
        /// </summary>
        Dot = 2,
        /// <summary>
        /// Specifies a line comprised of an alternating pattern of dash-dot-dash-dot.
        /// </summary>
        DashDot = 3,
        /// <summary>
        /// Specifies a line comprised of an alternating pattern of dash-dot-dot-dash-dot-dot.
        /// </summary>
        DashDotDot = 4,
        /// <summary>
        /// Specifies a user-defined custom dash style.
        /// </summary>
        Custom = 5
    }
}

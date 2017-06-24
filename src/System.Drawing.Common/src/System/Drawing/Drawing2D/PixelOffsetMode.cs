// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    ///    Specifies how pixels are offset during
    ///    rendering.
    /// </summary>
    public enum PixelOffsetMode
    {
        /// <summary>
        ///    Specifies an invalid mode.
        /// </summary>
        Invalid = QualityMode.Invalid,
        /// <summary>
        ///    Specifies the default mode.
        /// </summary>
        Default = QualityMode.Default,
        /// <summary>
        ///    Specifies high low quality (high
        ///    performance) mode.
        /// </summary>
        HighSpeed = QualityMode.Low,
        /// <summary>
        ///    Specifies high quality (lower performance)
        ///    mode.
        /// </summary>
        HighQuality = QualityMode.High,
        /// <summary>
        ///    Specifies no pixel offset.
        /// </summary>
        None,                   // no pixel offset
        /// <summary>
        ///    Specifies that pixels are offset by -.5
        ///    units both horizontally and vertically for high performance anti-aliasing.
        /// </summary>
        Half                    // offset by -0.5, -0.5 for fast anti-alias perf
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    ///    
    ///       Specifies the overall quality of rendering of graphics
    ///       shapes.
    ///    
    /// </summary>
    public enum SmoothingMode
    {
        /// <summary>
        ///    
        ///       Specifies an invalid mode.
        ///    
        /// </summary>
        Invalid = QualityMode.Invalid,
        /// <summary>
        ///    
        ///       Specifies the default mode.
        ///    
        /// </summary>
        Default = QualityMode.Default,
        /// <summary>
        ///    
        ///       Specifies low quality, high performance rendering.
        ///    
        /// </summary>
        HighSpeed = QualityMode.Low,
        /// <summary>
        ///    
        ///       Specifies high quality, lower performance rendering.
        ///    
        /// </summary>
        HighQuality = QualityMode.High,
        /// <summary>
        ///    Specifies no anti-aliasing.
        /// </summary>
        None,
        /// <summary>
        ///    Specifies anti-aliased rendering.
        /// </summary>
        AntiAlias
    }
}

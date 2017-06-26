// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies how data is interpolated between endpoints.
    /// </summary>
    public enum InterpolationMode
    {
        /// <summary>
        /// Equivalent to <see cref='QualityMode.Invalid'/>
        /// </summary>
        Invalid = QualityMode.Invalid,
        /// <summary>
        /// Specifies default mode.
        /// </summary>
        Default = QualityMode.Default,
        /// <summary>
        /// Specifies low quality.
        /// </summary>
        Low = QualityMode.Low,
        /// <summary>
        /// Specifies high quality.
        /// </summary>
        High = QualityMode.High,
        /// <summary>
        /// Specifies bilinear interpolation.
        /// </summary>
        Bilinear,
        /// <summary>
        /// Specifies bicubic interpolation.
        /// </summary>
        Bicubic,
        /// <summary>
        /// Specifies nearest neighbor interpolation.
        /// </summary>
        NearestNeighbor,
        /// <summary>
        /// Specifies high qulaity bilenear interpolation.
        /// </summary>
        HighQualityBilinear,
        /// <summary>
        /// Specifies high quality bicubic interpolation.
        /// </summary>
        HighQualityBicubic
    }
}

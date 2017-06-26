// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the quality level to use during compositing.
    /// </summary>
    public enum CompositingQuality
    {
        /// <summary>
        /// Invalid quality.
        /// </summary>
        Invalid = QualityMode.Invalid,
        /// <summary>
        /// Default quality.
        /// </summary>
        Default = QualityMode.Default,
        /// <summary>
        /// Low quality, high speed.
        /// </summary>
        HighSpeed = QualityMode.Low,
        /// <summary>
        /// High quality, low speed.
        /// </summary>
        HighQuality = QualityMode.High,
        /// <summary>
        /// Gamma correction is used.
        /// </summary>
        GammaCorrected,
        /// <summary>
        /// Assume linear values.
        /// </summary>
        AssumeLinear
    }
}

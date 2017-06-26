// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the overall quality of rendering of graphics shapes.
    /// </summary>
    public enum QualityMode
    {
        /// <summary>
        /// Specifies an invalid mode.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Specifies the default mode.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Specifies low quality, high performance rendering.
        /// </summary>
        Low = 1,             // for apps that need the best performance
        /// <summary>
        /// Specifies high quality, lower performance rendering.
        /// </summary>
        High = 2             // for apps that need the best rendering quality                                          
    }
}

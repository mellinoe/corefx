// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /*
     * Fill mode constants
     */

    /// <summary>
    ///    
    ///       Specifies how the interior of a closed path
    ///       is filled.
    ///    
    /// </summary>
    public enum FillMode
    {
        /**
         * Odd-even fill rule
         */
        /// <summary>
        ///    
        ///       Specifies the alternate fill mode.
        ///    
        /// </summary>
        Alternate = 0,

        /**
         * Non-zero winding fill rule
         */
        /// <summary>
        ///    
        ///       Specifies the winding fill mode.
        ///    
        /// </summary>
        Winding = 1
    }
}


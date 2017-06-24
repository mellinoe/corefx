// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Coordinate space identifiers
     */
    /// <summary>
    ///    
    ///       Specifies the system to use when evaluating coordinates.
    ///    
    /// </summary>
    public enum CoordinateSpace
    {
        /// <summary>
        ///    
        ///       Specifies that coordinates are in the world coordinate context. World
        ///       coordinates are used in a non physical enviroment such as a modeling
        ///       environment.
        ///    
        /// </summary>
        World = 0,
        /// <summary>
        ///    
        ///       Specifies that coordinates are in the page coordinate context. Page
        ///       coordinates are typically used in a multiple page documents environment.
        ///    
        /// </summary>
        Page = 1,
        /// <summary>
        ///    
        ///       Specifies that coordinates are in the device coordinate context. Device
        ///       coordinates occur in screen coordinates just before they are drawn on the
        ///       screen.
        ///    
        /// </summary>
        Device = 2
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Line cap constants
     */
    /// <summary>
    ///    Specifies the available cap
    ///    styles with which a <see cref='System.Drawing.Pen'/> can end a line.
    /// </summary>
    public enum LineCap
    {
        /// <summary>
        ///    Specifies a flat line cap.
        /// </summary>
        Flat = 0,
        /// <summary>
        ///    Specifies a square line cap.
        /// </summary>
        Square = 1,
        /// <summary>
        ///    Specifies a round line cap.
        /// </summary>
        Round = 2,
        /// <summary>
        ///    Specifies a triangular line cap.
        /// </summary>
        Triangle = 3,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        NoAnchor = 0x10, // corresponds to flat cap
        /// <summary>
        ///    Specifies no line cap.
        /// </summary>
        SquareAnchor = 0x11, // corresponds to square cap
        /// <summary>
        ///    Specifies a round anchor cap.
        /// </summary>
        RoundAnchor = 0x12, // corresponds to round cap
        /// <summary>
        ///    Specifies a diamond anchor cap.
        /// </summary>
        DiamondAnchor = 0x13, // corresponds to triangle cap
        /// <summary>
        ///    
        ///       Specifies an arrow-shaped anchor cap.
        ///    
        /// </summary>
        ArrowAnchor = 0x14, // no correspondence

        /// <summary>
        ///    
        ///       Specifies a custom line cap.
        ///    
        /// </summary>
        Custom = 0xff, // custom cap

        /// <summary>
        ///    Specifies a mask used to check whether a
        ///    line cap is an anchor cap.
        /// </summary>
        AnchorMask = 0xf0  // mask to check for anchor or not.
    }
}

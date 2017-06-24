// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    ///    Specifies the different patterns available
    ///    for <see cref='System.Drawing.Drawing2D.HatchBrush'/> objects.
    /// </summary>
    public enum HatchStyle
    {
        /// <summary>
        ///    
        ///       A pattern of horizontal lines.
        ///    
        /// </summary>
        Horizontal = 0,
        /// <summary>
        ///    
        ///       A pattern of vertical lines.
        ///    
        /// </summary>
        Vertical = 1,
        /// <summary>
        ///    
        ///       A pattern of lines on a diagonal from top-left to bottom-right.
        ///    
        /// </summary>
        ForwardDiagonal = 2,
        /// <summary>
        ///    A pattern of lines on a diagonal from
        ///    top-right to bottom-left.
        /// </summary>
        BackwardDiagonal = 3,
        /// <summary>
        ///    
        ///       A pattern of criss-cross horizontal and vertical lines.
        ///    
        /// </summary>
        Cross = 4,
        /// <summary>
        ///    
        ///       A pattern of criss-cross diagonal lines.
        ///    
        /// </summary>
        DiagonalCross = 5,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent05 = 6,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent10 = 7,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent20 = 8,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent25 = 9,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent30 = 10,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent40 = 11,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent50 = 12,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent60 = 13,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent70 = 14,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent75 = 15,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent80 = 16,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Percent90 = 17,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LightDownwardDiagonal = 18,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LightUpwardDiagonal = 19,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DarkDownwardDiagonal = 20,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DarkUpwardDiagonal = 21,
        /// <summary>
        ///    
        ///    
        /// </summary>
        WideDownwardDiagonal = 22,
        /// <summary>
        ///    
        ///    
        /// </summary>
        WideUpwardDiagonal = 23,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LightVertical = 24,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LightHorizontal = 25,
        /// <summary>
        ///    
        ///    
        /// </summary>
        NarrowVertical = 26,
        /// <summary>
        ///    
        ///    
        /// </summary>
        NarrowHorizontal = 27,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DarkVertical = 28,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DarkHorizontal = 29,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DashedDownwardDiagonal = 30,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DashedUpwardDiagonal = 31,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DashedHorizontal = 32,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DashedVertical = 33,
        /// <summary>
        ///    
        ///    
        /// </summary>
        SmallConfetti = 34,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LargeConfetti = 35,
        /// <summary>
        ///    
        ///    
        /// </summary>
        ZigZag = 36,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Wave = 37,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DiagonalBrick = 38,
        /// <summary>
        ///    
        ///    
        /// </summary>
        HorizontalBrick = 39,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Weave = 40,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Plaid = 41,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Divot = 42,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DottedGrid = 43,
        /// <summary>
        ///    
        ///    
        /// </summary>
        DottedDiamond = 44,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Shingle = 45,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Trellis = 46,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Sphere = 47,
        /// <summary>
        ///    
        ///    
        /// </summary>
        SmallGrid = 48,
        /// <summary>
        ///    
        ///    
        /// </summary>
        SmallCheckerBoard = 49,
        /// <summary>
        ///    
        ///    
        /// </summary>
        LargeCheckerBoard = 50,
        /// <summary>
        ///    
        ///    
        /// </summary>
        OutlinedDiamond = 51,
        /// <summary>
        ///    
        ///    
        /// </summary>
        SolidDiamond = 52,

        /// <summary>
        ///    
        ///    
        /// </summary>
        LargeGrid = Cross,

        /// <summary>
        ///    
        ///    
        /// </summary>
        Min = Horizontal,
        /// <summary>
        ///    
        ///    
        /// </summary>
        Max = LargeGrid
    };
}

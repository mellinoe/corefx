// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies the different patterns available for <see cref='HatchBrush'/> objects.
    /// </summary>
    public enum HatchStyle
    {
        /// <summary>
        /// A pattern of horizontal lines.
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// A pattern of vertical lines.
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// A pattern of lines on a diagonal from top-left to bottom-right.
        /// </summary>
        ForwardDiagonal = 2,
        /// <summary>
        /// A pattern of lines on a diagonal from top-right to bottom-left.
        /// </summary>
        BackwardDiagonal = 3,
        /// <summary>
        /// A pattern of criss-cross horizontal and vertical lines.
        /// </summary>
        Cross = 4,
        /// <summary>
        /// A pattern of criss-cross diagonal lines.
        /// </summary>
        DiagonalCross = 5,
        Percent05 = 6,
        Percent10 = 7,
        Percent20 = 8,
        Percent25 = 9,
        Percent30 = 10,
        Percent40 = 11,
        Percent50 = 12,
        Percent60 = 13,
        Percent70 = 14,
        Percent75 = 15,
        Percent80 = 16,
        Percent90 = 17,
        LightDownwardDiagonal = 18,
        LightUpwardDiagonal = 19,
        DarkDownwardDiagonal = 20,
        DarkUpwardDiagonal = 21,
        WideDownwardDiagonal = 22,
        WideUpwardDiagonal = 23,
        LightVertical = 24,
        LightHorizontal = 25,
        NarrowVertical = 26,
        NarrowHorizontal = 27,
        DarkVertical = 28,
        DarkHorizontal = 29,
        DashedDownwardDiagonal = 30,
        DashedUpwardDiagonal = 31,
        DashedHorizontal = 32,
        DashedVertical = 33,
        SmallConfetti = 34,
        LargeConfetti = 35,
        ZigZag = 36,
        Wave = 37,
        DiagonalBrick = 38,
        HorizontalBrick = 39,
        Weave = 40,
        Plaid = 41,
        Divot = 42,
        DottedGrid = 43,
        DottedDiamond = 44,
        Shingle = 45,
        Trellis = 46,
        Sphere = 47,
        SmallGrid = 48,
        SmallCheckerBoard = 49,
        LargeCheckerBoard = 50,
        OutlinedDiamond = 51,
        SolidDiamond = 52,
        LargeGrid = Cross,
        Min = Horizontal,
        Max = LargeGrid
    };
}

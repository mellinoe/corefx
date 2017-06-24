// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Combine mode constants
     */
    /// <summary>
    ///    Defines how different clipping regions can
    ///    be combined.
    /// </summary>
    public enum CombineMode
    {
        /// <summary>
        ///    One clipping region is replaced by another.
        /// </summary>
        Replace = 0,
        /// <summary>
        ///    The two clipping regions are combined by
        ///    taking their intersection.
        /// </summary>
        Intersect = 1,
        /// <summary>
        ///    The two clipping regions are combined by
        ///    taking the union of both.
        /// </summary>
        Union = 2,
        /// <summary>
        ///    The two clipping regions are combined by
        ///    taking only the area enclosed by one or the other regions, but not both.
        /// </summary>
        Xor = 3,
        /// <summary>
        ///    
        ///       Two clipping regions are combined by taking
        ///       the area of the first region that does not intersect with the second.
        ///    
        /// </summary>
        Exclude = 4,
        /// <summary>
        ///    
        ///       Two clipping regions are combined by taking
        ///       the area of the second region that does not intersect with the first.
        ///    
        /// </summary>
        Complement = 5
    }
}

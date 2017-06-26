// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Defines arrays of colors and positions used for interpolating color blending in a gradient.
    /// </summary>
    public sealed class ColorBlend
    {
        private Color[] _colors;
        private float[] _positions;

        /// <summary>
        /// Initializes a new instance of the <see cref='ColorBlend'/> class.
        /// </summary>
        public ColorBlend()
        {
            _colors = new Color[1];
            _positions = new float[1];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='ColorBlend'/> class with the specified number of colors and positions.
        /// </summary>
        public ColorBlend(int count)
        {
            _colors = new Color[count];
            _positions = new float[count];
        }

        /// <summary>
        /// Represents an array of colors.
        /// </summary>
        public Color[] Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
            }
        }

        /// <summary>
        /// Represents the positions along a gradient line.
        /// </summary>
        public float[] Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
            }
        }
    }
}

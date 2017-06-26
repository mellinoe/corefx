// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Defines a blend pattern for a <see cref='LinearGradientBrush'/>.
    /// </summary>
    public sealed class Blend
    {
        private float[] _factors;
        private float[] _positions;

        /// <summary>
        /// Initializes a new instance of the <see cref='Blend'/> class.
        /// </summary>
        public Blend()
        {
            _factors = new float[1];
            _positions = new float[1];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Blend'/> class with the specified number of factors and positions.
        /// </summary>
        public Blend(int count)
        {
            _factors = new float[count];
            _positions = new float[count];
        }
        /// <summary>
        /// Specifies an array of blend factors for the gradient.
        /// </summary>
        public float[] Factors
        {
            get
            {
                return _factors;
            }
            set
            {
                _factors = value;
            }
        }

        /// <summary>
        /// Specifies an array of blend positions for the gradient.
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

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    /**
     * Represent the internal data of a path object
     */
    /// <summary>
    ///    Contains the graphical data that makes up a
    /// <see cref='System.Drawing.Drawing2D.GraphicsPath'/>.
    /// </summary>
    public sealed class PathData
    {
        private PointF[] _points;
        private byte[] _types;

        /// <summary>
        ///    Initializes a new instance of the <see cref='System.Drawing.Drawing2D.PathData'/> class.
        /// </summary>
        public PathData()
        {
        }

        /// <summary>
        ///    Contains an array of <see cref='System.Drawing.PointF'/> objects
        ///    that represent the points through which the path is constructed.
        /// </summary>
        public PointF[] Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        /// <summary>
        ///    
        ///       Contains an array of <see cref='System.Drawing.Drawing2D.PathPointType'/> objects that represent the types of
        ///       data in the corresponding elements of the <see cref='System.Drawing.Drawing2D.PathData. _points'/> array.
        ///    
        /// </summary>
        public byte[] Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
            }
        }
    }
}

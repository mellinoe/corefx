// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Design
{
    using System.Collections;

    /// <summary>
    ///     
    ///       A collection that stores <see cref='System.String'/> objects.
    ///    
    /// </summary>
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
    public sealed class CategoryNameCollection : ReadOnlyCollectionBase
    {
        /// <summary>
        ///     
        ///       Initializes a new instance of <see cref='System.Drawing.Design.CategoryNameCollection'/> based on another <see cref='System.Drawing.Design.CategoryNameCollection'/>.
        ///    
        /// </summary>
        public CategoryNameCollection(CategoryNameCollection value)
        {
            InnerList.AddRange(value);
        }

        /// <summary>
        ///     
        ///       Initializes a new instance of <see cref='System.Drawing.Design.CategoryNameCollection'/> containing any array of <see cref='System.String'/> objects.
        ///    
        /// </summary>
        public CategoryNameCollection(String[] value)
        {
            InnerList.AddRange(value);
        }

        /// <summary>
        /// Represents the entry at the specified index of the <see cref='System.String'/>.
        /// </summary>
        public string this[int index]
        {
            get
            {
                return ((string)(InnerList[index]));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the 
        ///    <see cref='System.Drawing.Design.CategoryNameCollection'/> contains the specified <see cref='System.String'/>.
        /// </summary>
        public bool Contains(string value)
        {
            return InnerList.Contains(value);
        }

        /// <summary>
        /// Copies the <see cref='System.Drawing.Design.CategoryNameCollection'/> values to a one-dimensional <see cref='System.Array'/> instance at the 
        ///    specified index.
        /// </summary>
        public void CopyTo(String[] array, int index)
        {
            InnerList.CopyTo(array, index);
        }

        /// <summary>
        ///    Returns the index of a <see cref='System.String'/> in 
        ///       the <see cref='System.Drawing.Design.CategoryNameCollection'/> .
        /// </summary>
        public int IndexOf(string value)
        {
            return InnerList.IndexOf(value);
        }
    }
}


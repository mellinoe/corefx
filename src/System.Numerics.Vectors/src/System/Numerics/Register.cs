// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace System.Numerics
{
    /// <summary>
    /// A structure describing the layout of an SSE2-sized register.
    /// Contains overlapping fields representing the set of valid numeric types.
    /// Allows the generic Vector'T struct to contain an explicit field layout.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct Register
    {
        #region Internal Storage Fields
        // Internal System.Byte Fields
        [FieldOffset(0)]
        internal Byte byte_0;
        [FieldOffset(1)]
        internal Byte byte_1;
        [FieldOffset(2)]
        internal Byte byte_2;
        [FieldOffset(3)]
        internal Byte byte_3;
        [FieldOffset(4)]
        internal Byte byte_4;
        [FieldOffset(5)]
        internal Byte byte_5;
        [FieldOffset(6)]
        internal Byte byte_6;
        [FieldOffset(7)]
        internal Byte byte_7;

        // Internal System.SByte Fields
        [FieldOffset(0)]
        internal SByte sbyte_0;
        [FieldOffset(1)]
        internal SByte sbyte_1;
        [FieldOffset(2)]
        internal SByte sbyte_2;
        [FieldOffset(3)]
        internal SByte sbyte_3;
        [FieldOffset(4)]
        internal SByte sbyte_4;
        [FieldOffset(5)]
        internal SByte sbyte_5;
        [FieldOffset(6)]
        internal SByte sbyte_6;
        [FieldOffset(7)]
        internal SByte sbyte_7;

        // Internal System.UInt16 Fields
        [FieldOffset(0)]
        internal UInt16 uint16_0;
        [FieldOffset(2)]
        internal UInt16 uint16_1;
        [FieldOffset(4)]
        internal UInt16 uint16_2;
        [FieldOffset(6)]
        internal UInt16 uint16_3;

        // Internal System.Int16 Fields
        [FieldOffset(0)]
        internal Int16 int16_0;
        [FieldOffset(2)]
        internal Int16 int16_1;
        [FieldOffset(4)]
        internal Int16 int16_2;
        [FieldOffset(6)]
        internal Int16 int16_3;

        // Internal System.UInt32 Fields
        [FieldOffset(0)]
        internal UInt32 uint32_0;
        [FieldOffset(4)]
        internal UInt32 uint32_1;

        // Internal System.Int32 Fields
        [FieldOffset(0)]
        internal Int32 int32_0;
        [FieldOffset(4)]
        internal Int32 int32_1;

        // Internal System.UInt64 Fields
        [FieldOffset(0)]
        internal UInt64 uint64_0;

        // Internal System.Int64 Fields
        [FieldOffset(0)]
        internal Int64 int64_0;

        // Internal System.Single Fields
        [FieldOffset(0)]
        internal Single single_0;
        [FieldOffset(4)]
        internal Single single_1;

        // Internal System.Double Fields
        [FieldOffset(0)]
        internal Double double_0;

        #endregion Internal Storage Fields
    }
}
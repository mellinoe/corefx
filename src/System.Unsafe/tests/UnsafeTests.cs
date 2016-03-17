// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace System.Numerics.Tests
{
    public class UnsafeTests
    {
        private static List<object[]> _arrays = new List<object[]>();

        [Fact]
        public static unsafe void ReadInt32()
        {
            int expected = 42;
            void* address = &expected;
            int ret = Unsafe.Read<int>(address);
            Assert.Equal(expected, ret);
        }

        [Theory]
        [MemberData(nameof(AddressOfData))]
        public static unsafe void AddressOfThenRead<T>(T expected)
        {
            for (int i = 0; i < 1000; i++)
            {
                object[] arr = Enumerable.Range(0, i).Select(v => (object)v).ToArray();
                if (i % 15 == 0)
                {
                    _arrays.Add(arr);
                }
            }
            GC.Collect();
            GC.Collect();
            void* address = Unsafe.AddressOf(ref expected);
            for (int i = 0; i < 1000; i++)
            {
                object[] arr = Enumerable.Range(0, i).Select(v => (object)v).ToArray();
            }
            GC.Collect();
            GC.Collect();
            object ret = Unsafe.Read<T>(address);
            Assert.Same(expected, ret);
        }

        public static IEnumerable<object[]> AddressOfData()
        {
            yield return new object[] { "Hello" };
            yield return new object[] { new UnsafeTests() };
            yield return new object[] { new object() };
        }
    }
}

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Runtime.InteropServices;

namespace System.Net.NetworkInformation.Tests
{
    internal static class FileUtil
    {
        public static void NormalizeLineEndings(string source, string normalizedDest)
        {
            // I'm storing the test text assets with their original line endings.
            // The parsing logic depends on Environment.NewLine, so we normalize beforehand.
            if (Environment.NewLine != "\n")
            {
                string contents = File.ReadAllText(source);
                File.WriteAllText(normalizedDest, contents.Replace("\n", Environment.NewLine));
            }
        }
    }
}

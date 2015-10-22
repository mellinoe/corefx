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
            // I'm storing the test text assets with their original line endings ('\n').
            // The parsing logic depends on Environment.NewLine, so we normalize beforehand.
            string contents = File.ReadAllText(source);
            if (!contents.Contains(Environment.NewLine))
            {
                string otherEnding = Environment.NewLine == "\n" ? "\r\n" : "\n";
                contents = contents.Replace(otherEnding, Environment.NewLine);
            }

            File.WriteAllText(normalizedDest, contents);
        }
    }
}

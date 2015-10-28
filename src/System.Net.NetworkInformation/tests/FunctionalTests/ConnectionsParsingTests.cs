﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using Xunit;

namespace System.Net.NetworkInformation.Tests
{
    public class ConnectionsParsingTests
    {
        [Fact]
        public static void ActiveTcpConnectionsParsing()
        {
            NormalizeLineEndings("tcp", "tcp_normalized0");
            NormalizeLineEndings("tcp6", "tcp6_normalized0");

            TcpConnectionInformation[] infos = StringParsingHelpers.ParseActiveTcpConnectionsFromFiles("tcp_normalized0", "tcp6_normalized0");
            Assert.Equal(10, infos.Length);
            ValidateInfo(infos[0], new IPEndPoint(0xFFFFFF01L, 0x01BD), new IPEndPoint(0L, 0), TcpState.Established);
            ValidateInfo(infos[1], new IPEndPoint(0x12345678L, 0x008B), new IPEndPoint(0L, 0), TcpState.SynSent);
            ValidateInfo(infos[2], new IPEndPoint(0x0101007FL, 0x0035), new IPEndPoint(0L, 0), TcpState.SynReceived);
            ValidateInfo(infos[3], new IPEndPoint(0x0100007FL, 0x0277), new IPEndPoint(0L, 0), TcpState.FinWait1);

            ValidateInfo(
                infos[4],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x01BD),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x0000),
                TcpState.FinWait2);

            ValidateInfo(
                infos[5],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x008B),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x0000),
                TcpState.TimeWait);

            ValidateInfo(
                infos[6],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0x0277),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x0000),
                TcpState.Closing);

            ValidateInfo(
                infos[7],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA696),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0x0277),
                TcpState.CloseWait);

            ValidateInfo(
                infos[8],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA69B),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0x0277),
                TcpState.LastAck);

            ValidateInfo(
                infos[9],
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA697),
                new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0x0277),
                TcpState.Listen);
        }

        [Fact]
        public static void TcpListenersParsing()
        {
            NormalizeLineEndings("tcp", "tcp_normalized1");
            NormalizeLineEndings("tcp6", "tcp6_normalized1");

            IPEndPoint[] listeners = StringParsingHelpers.ParseActiveTcpListenersFromFiles("tcp_normalized1", "tcp6_normalized1");
            Assert.Equal(10, listeners.Length);

            Assert.Equal(new IPEndPoint(0xFFFFFF01, 0x01Bd), listeners[0]);
            Assert.Equal(new IPEndPoint(0x12345678, 0x008B), listeners[1]);
            Assert.Equal(new IPEndPoint(0x0101007F, 0x0035), listeners[2]);
            Assert.Equal(new IPEndPoint(0x0100007F, 0x0277), listeners[3]);

            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x01BD), listeners[4]);
            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x008B), listeners[5]);
            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0x0277), listeners[6]);
            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA696), listeners[7]);
            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA69B), listeners[8]);
            Assert.Equal(new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000001000000"), 0xA697), listeners[9]);
        }

        [Fact]
        public static void UdpListenersParsing()
        {
            NormalizeLineEndings("udp", "udp_normalized0");
            NormalizeLineEndings("udp6", "udp6_normalized0");

            IPEndPoint[] listeners = StringParsingHelpers.ParseActiveUdpListenersFromFiles("udp_normalized0", "udp6_normalized0");
            Assert.Equal(15, listeners.Length);

            Assert.Equal(listeners[0], new IPEndPoint(0x00000000, 0x8E15));
            Assert.Equal(listeners[1], new IPEndPoint(0x00000000, 0x14E9));
            Assert.Equal(listeners[2], new IPEndPoint(0x00000000, 0xB50F));
            Assert.Equal(listeners[3], new IPEndPoint(0x0101007F, 0x0035));
            Assert.Equal(listeners[4], new IPEndPoint(0x00000000, 0x0044));
            Assert.Equal(listeners[5], new IPEndPoint(0xFF83690A, 0x0089));
            Assert.Equal(listeners[6], new IPEndPoint(0x3B80690A, 0x0089));
            Assert.Equal(listeners[7], new IPEndPoint(0x00000000, 0x0089));
            Assert.Equal(listeners[8], new IPEndPoint(0xFF83690A, 0x008A));
            Assert.Equal(listeners[9], new IPEndPoint(0x3B80690A, 0x008A));
            Assert.Equal(listeners[10], new IPEndPoint(0x00000000, 0x008A));
            Assert.Equal(listeners[11], new IPEndPoint(0x00000000, 0x0277));

            Assert.Equal(listeners[12], new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x14E9));
            Assert.Equal(listeners[13], new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x96D3));
            Assert.Equal(listeners[14], new IPEndPoint(StringParsingHelpers.ParseHexIPAddress("00000000000000000000000000000000"), 0x8B58));
        }

        private static void NormalizeLineEndings(string source, string normalizedDest)
        {
            // I'm storing the test text assets with their original line endings.
            // The parsing logic depends on Environment.NewLine, so we normalize beforehand.
            string contents = File.ReadAllText(source);
            File.WriteAllText(normalizedDest, contents.Replace("\n", "\r\n"));
        }

        private static void ValidateInfo(TcpConnectionInformation tcpConnectionInformation, IPEndPoint localEP, IPEndPoint remoteEP, TcpState state)
        {
            Assert.Equal(localEP, tcpConnectionInformation.LocalEndPoint);
            Assert.Equal(remoteEP, tcpConnectionInformation.RemoteEndPoint);
            Assert.Equal(state, tcpConnectionInformation.State);
        }
    }
}

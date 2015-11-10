// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace System.Net.NetworkInformation
{
    public partial class Ping
    {
        private const int IcmpHeaderLengthInBytes = 8;
        private const int IpHeaderLengthInBytes = 20;

        private unsafe void InternalSendAsync(IPAddress address, byte[] buffer, int timeout, PingOptions options)
        {
            AsyncOperation asyncOp = _asyncOp;
            SendOrPostCallback callback = _onPingCompletedDelegate;

            Exception pingException = null;
            PingReply pr = null;
            EndPoint endPoint = new IPEndPoint(address, 0);

            bool isIpv4 = address.AddressFamily == AddressFamily.InterNetwork;
            ProtocolType protocolType = isIpv4 ? ProtocolType.Icmp : ProtocolType.IcmpV6;

            IcmpHeader header = new IcmpHeader()
            {
                Type = isIpv4 ? (byte)8 : (byte)128,
                Code = 0,
                HeaderChecksum = 0,
                Identifier = 42,
                SequenceNumber = 0,
            };
            byte[] sendBuffer = CreateSendMessageBuffer(header, buffer);


            using (Socket socket = new Socket(address.AddressFamily, SocketType.Raw, protocolType))
            {
                socket.ReceiveTimeout = DefaultTimeout;
                socket.SendTimeout = DefaultTimeout;
                if (options != null)
                {
                    socket.DontFragment = options.DontFragment;
                    socket.Ttl = (short)options.Ttl;
                }

                int ipHeaderLength = isIpv4 ? 20 : 18;
                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    socket.SendTo(sendBuffer, endPoint);
                    byte[] receiveBuffer = new byte[ipHeaderLength + IcmpHeaderLengthInBytes + buffer.Length];
                    int bytesReceived = socket.ReceiveFrom(receiveBuffer, ref endPoint);
                    byte type, code;
                    fixed (byte* bytesPtr = receiveBuffer)
                    {
                        int icmpHeaderOffset = isIpv4 ? ipHeaderLength : 0;
                        IcmpHeader receivedHeader = *((IcmpHeader*)(bytesPtr + icmpHeaderOffset)); // Skip IP header.
                        type = receivedHeader.Type;
                        code = receivedHeader.Code;
                    }
                    sw.Stop();
                    long roundTripTime = sw.ElapsedMilliseconds;
                    pr = new PingReply(
                        address,
                        options,
                        isIpv4 ? MapV4TypeToStatus(type, code) : MapV6TypeToStatus(type, code),
                        roundTripTime,
                        receiveBuffer);
                }
                catch (SocketException se)
                {
                    pingException = se;
                }
            }

            var ea = new PingCompletedEventArgs(
                pr,
                pingException,
                false,
                asyncOp.UserSuppliedState);

            Finish();
            asyncOp.PostOperationCompleted(callback, ea);

        }

        private IPStatus MapV4TypeToStatus(byte type, byte code)
        {
            // TODO: There's a LOT of other possibilities here.
            switch (type)
            {
                case 0:
                    return IPStatus.Success;
                case 3:
                    return IPStatus.DestinationUnreachable;
                default:
                    return IPStatus.Unknown;
            }
        }

        private IPStatus MapV6TypeToStatus(byte type, byte code)
        {
            // TODO: There's a LOT of other possibilities here.
            switch (type)
            {
                case 129:
                    return IPStatus.Success;
                case 1:
                    return IPStatus.DestinationUnreachable;
                default:
                    return IPStatus.Unknown;
            }
        }

        // Must be 8 bytes total.
        [StructLayout(LayoutKind.Sequential)]
        internal struct IcmpHeader
        {
            public byte Type;
            public byte Code;
            public ushort HeaderChecksum;
            public ushort Identifier;
            public ushort SequenceNumber;
        }

        private void InternalDisposeCore()
        {
        }

        private static unsafe byte[] CreateSendMessageBuffer(IcmpHeader header, byte[] payload)
        {
            var headerSize = Marshal.SizeOf<IcmpHeader>();
            byte[] result = new byte[headerSize + payload.Length];
            Marshal.Copy(new IntPtr(&header), result, 0, headerSize);
            payload.CopyTo(result, headerSize);
            ushort checksum = ComputerBufferChecksum(result, 0, result.Length);
            // Jam the checksum into the buffer.
            // TODO: Fix the order of this, not sure what is up.
            result[3] = (byte)(checksum & (0xFF));
            result[2] = (byte)(checksum >> 8);

            return result;
        }

        private static ushort ComputerBufferChecksum(byte[] header, int start, int length)
        {
            ushort word;
            long sum = 0;
            for (int i = start; i < (length + start); i += 2)
            {
                word = (ushort)(((header[i] << 8) & 0xFF00)
                + (header[i + 1] & 0xFF));
                sum += (long)word;
            }

            while ((sum >> 16) != 0)
            {
                sum = (sum & 0xFFFF) + (sum >> 16);
            }

            sum = ~sum;

            return (ushort)sum;
        }
    }
}

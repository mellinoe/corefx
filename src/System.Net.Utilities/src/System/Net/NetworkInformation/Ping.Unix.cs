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
        [DllImport("libc")]
        public static extern void printf(string message);

        private const int IcmpHeaderLengthInBytes = 8;
        private const int IpHeaderLengthInBytes = 20;

        private static readonly bool s_canUseRawSockets = CheckRawSocketPermissions();

        private static bool CheckRawSocketPermissions()
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private unsafe void InternalSendAsync(IPAddress address, byte[] buffer, int timeout, PingOptions options)
        {
            if (s_canUseRawSockets)
            {
                SendIcmpPingOverRawSocket(address, buffer, timeout, options);
            }
            else
            {
                throw new PlatformNotSupportedException("Need raw socket permissions.");
            }
        }

        private unsafe void SendIcmpPingOverRawSocket(IPAddress address, byte[] buffer, int timeout, PingOptions options)
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
                Type = isIpv4 ? (byte)Icmpv4MessageConstants.EchoRequest : (byte)Icmpv6MessageConstants.EchoRequest,
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
                    while (true)
                    {
                        int bytesReceived = socket.ReceiveFrom(receiveBuffer, ref endPoint);
                        byte type, code;
                        fixed (byte* bytesPtr = receiveBuffer)
                        {
                            int icmpHeaderOffset = ipHeaderLength;
                            IcmpHeader receivedHeader = *((IcmpHeader*)(bytesPtr + icmpHeaderOffset)); // Skip IP header.
                            type = receivedHeader.Type;
                            code = receivedHeader.Code;

                            if (type == 8 || type == 128) // Echo Request
                            {
                                continue;
                            }
                        }
                        sw.Stop();
                        long roundTripTime = sw.ElapsedMilliseconds;
                        pr = new PingReply(
                            address,
                            options,
                            isIpv4 ? Icmpv4MessageConstants.MapV4TypeToIPStatus(type, code) : Icmpv6MessageConstants.MapV6TypeToIPStatus(type, code),
                            roundTripTime,
                            receiveBuffer);
                        break;
                    }
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
            result[2] = (byte)(checksum >> 8);
            result[3] = (byte)(checksum & (0xFF));

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
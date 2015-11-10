// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Net.NetworkInformation
{
    public partial class Ping
    {
        private const int IcmpHeaderLengthInBytes = 8;
        private const int IpHeaderLengthInBytes = 20;

        private static readonly bool s_canUseRawSockets = CheckRawSocketPermissions();

        private static readonly string s_ipv4PingFile = "ping";
        private static readonly string s_ipv6PingFile = "ping6";

        private static bool CheckRawSocketPermissions()
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                s.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InternalSendAsync(IPAddress address, byte[] buffer, int timeout, PingOptions options)
        {
            AsyncOperation asyncOp = _asyncOp;
            SendOrPostCallback callback = _onPingCompletedDelegate;

            PingReply pr = null;
            Exception pingException = null;

            try
            {
                if (s_canUseRawSockets)
                {
                    pr = SendIcmpPingOverRawSocket(address, buffer, timeout, options);
                }
                else
                {
                    pr = SendWithPingUtility(address, buffer, timeout, options);
                }
            }
            catch (Exception e)
            {
                pingException = e;
            }

            // At this point, either PR has a real PingReply in it, or pingException has an Exception in it.
            var ea = new PingCompletedEventArgs(
                pr,
                pingException,
                false,
                asyncOp.UserSuppliedState);

            Finish();
            asyncOp.PostOperationCompleted(callback, ea);
        }

        private unsafe PingReply SendIcmpPingOverRawSocket(IPAddress address, byte[] buffer, int timeout, PingOptions options)
        {
            EndPoint endPoint = new IPEndPoint(address, 0);

            bool isIpv4 = address.AddressFamily == AddressFamily.InterNetwork;
            ProtocolType protocolType = isIpv4 ? ProtocolType.Icmp : ProtocolType.IcmpV6;
            // Use the current thread's ID as the identifier.
            ushort identifier = (ushort)Environment.CurrentManagedThreadId;
            IcmpHeader header = new IcmpHeader()
            {
                Type = isIpv4 ? (byte)Icmpv4MessageConstants.EchoRequest : (byte)Icmpv6MessageConstants.EchoRequest,
                Code = 0,
                HeaderChecksum = 0,
                Identifier = identifier,
                SequenceNumber = 0,
            };
            byte[] sendBuffer = CreateSendMessageBuffer(header, buffer);

            using (Socket socket = new Socket(address.AddressFamily, SocketType.Raw, protocolType))
            {
                socket.ReceiveTimeout = timeout;
                socket.SendTimeout = timeout;
                // Setting Socket.DontFragment and .Ttl is not supported on Unix, so ignore the PingOptions parameter.

                int ipHeaderLength = isIpv4 ? IpHeaderLengthInBytes : 0;
                Stopwatch sw = Stopwatch.StartNew();
                socket.SendTo(sendBuffer, endPoint);
                byte[] receiveBuffer = new byte[ipHeaderLength + IcmpHeaderLengthInBytes + buffer.Length];
                while (sw.ElapsedMilliseconds < timeout)
                {
                    int bytesReceived = socket.ReceiveFrom(receiveBuffer, ref endPoint);
                    if (bytesReceived - ipHeaderLength < IcmpHeaderLengthInBytes)
                    {
                        continue; // Not enough bytes to reconstruct IP header + ICMP header.
                    }
                    byte type, code;
                    fixed (byte* bytesPtr = receiveBuffer)
                    {
                        int icmpHeaderOffset = ipHeaderLength;
                        IcmpHeader receivedHeader = *((IcmpHeader*)(bytesPtr + icmpHeaderOffset)); // Skip IP header.
                        type = receivedHeader.Type;
                        code = receivedHeader.Code;

                        if (identifier != receivedHeader.Identifier
                            || type == Icmpv4MessageConstants.EchoRequest
                            || type == Icmpv6MessageConstants.EchoRequest) // Echo Request, ignore
                        {
                            continue;
                        }
                    }

                    sw.Stop();
                    long roundTripTime = sw.ElapsedMilliseconds;
                    // We want to return a buffer with the actual data we sent out, not including the header data.
                    byte[] dataBuffer = new byte[bytesReceived - IcmpHeaderLengthInBytes];
                    Array.Copy(receiveBuffer, IcmpHeaderLengthInBytes, dataBuffer, 0, dataBuffer.Length);

                    IPStatus status = isIpv4 
                                        ? Icmpv4MessageConstants.MapV4TypeToIPStatus(type, code) 
                                        : Icmpv6MessageConstants.MapV6TypeToIPStatus(type, code);
                    
                    return new PingReply(address, options, status, roundTripTime, dataBuffer);
                }

                // We have exceeded our timeout duration, and no reply has been received.
                sw.Stop();
                throw new PingException(SR.net_ping_reply_timeout);
            }
        }

        private PingReply SendWithPingUtility(IPAddress address, byte[] buffer, int timeout, PingOptions options)
        {
            bool isIpv4 = address.AddressFamily == AddressFamily.InterNetwork;
            string pingExecutable = isIpv4 ? s_ipv4PingFile : s_ipv6PingFile;

            StringBuilder sb = new StringBuilder();
            sb.Append("-c 1"); // Just send a single ping ("count = 1")

            // The command-line flags for "Do-not-fragment" and "TTL" are not standard.
            // In fact, they are different even between ping and ping6 on the same machine.

            // The ping utility is not flexible enough to specify an exact payload.
            // But we can at least send the right number of bytes.
            sb.Append(" -s ");
            sb.Append(buffer.Length);

            sb.Append(' ');
            sb.Append(address.ToString());

            string processArgs = sb.ToString();
            ProcessStartInfo psi = new ProcessStartInfo(pingExecutable, processArgs);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            Process p = new Process() { StartInfo = psi };
            p.Start();
            if (!p.WaitForExit(timeout))
            {
                p.Kill();
                throw new PingException(SR.net_ping_reply_timeout);
            }

            if (p.ExitCode != 0)
            {
                // This means no reply was received, although transmission may have been successful.
                throw new PingException(SR.net_ping_reply_timeout);
            }

            try
            {
                string output = p.StandardOutput.ReadToEnd();
                int timeIndex = output.IndexOf("time=", StringComparison.Ordinal);
                int afterTime = timeIndex + "time=".Length;
                double parsedRtt;
                int msIndex = output.IndexOf("ms", afterTime);
                int numLength = msIndex - afterTime - 1;
                string timeSubstring = output.Substring(afterTime, numLength);
                parsedRtt = double.Parse(timeSubstring);
                long rtt = (long)Math.Round(parsedRtt);
                return new PingReply(
                        address,
                        null, // Ping utility cannot accomodate these, return null to indicate they were ignored.
                        IPStatus.Success,
                        rtt,
                        Array.Empty<byte>()); // Ping utility doesn't deliver this info.
            }
            catch (Exception)
            {
                // If the standard output cannot be successfully parsed, throw a generic PingException.
                throw new PingException(SR.net_ping);
            }
        }

        private void InternalDisposeCore()
        {
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

        private static unsafe byte[] CreateSendMessageBuffer(IcmpHeader header, byte[] payload)
        {
            var headerSize = Marshal.SizeOf<IcmpHeader>();
            byte[] result = new byte[headerSize + payload.Length];
            Marshal.Copy(new IntPtr(&header), result, 0, headerSize);
            payload.CopyTo(result, headerSize);
            ushort checksum = ComputeBufferChecksum(result);
            // Jam the checksum into the buffer.
            result[2] = (byte)(checksum >> 8);
            result[3] = (byte)(checksum & (0xFF));

            return result;
        }

        private static ushort ComputeBufferChecksum(byte[] buffer)
        {
            // This is using the "deferred carries" approach outlined in RFC 1071.
            uint sum = 0;
            for (int i = 0; i < buffer.Length; i+= 2)
            {
                // Combine each pair of bytes into a 16-bit number and add it to the sum
                ushort element0 = (ushort)((buffer[i] << 8) & 0xFF00);
                ushort element1 = (i + 1 < buffer.Length)
                                    ? (ushort)(buffer[i + 1] & 0x00FF)
                                    : (ushort)0; // If there's an odd number of bytes, pad by one octet of zeros.
                ushort combined = (ushort)(element0 | element1);
                sum += (uint)combined;
            }

            // Add back the "carry bits" which have risen to the upper 16 bits of the sum.
            while ((sum >> 16) != 0)
            {
                var partialSum = sum & 0xFFFF;
                var carries = sum >> 16;
                sum = partialSum + carries;
            }

            return (ushort)~sum;
        }
    }
}

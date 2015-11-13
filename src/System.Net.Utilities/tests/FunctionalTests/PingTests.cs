// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Sockets;

using Xunit;

namespace System.Net.Utilities.Tests
{
    public class PingTests
    {
        [Fact]
        public async Task SendPingAsyncWithIPAddress()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));
                });
        }

        [Fact]
        public async Task SendPingAsyncWithIPAddressAndTimeout()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress, TestSettings.PingTimeout),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));
                });
        }

        // Non-root pings cannot send arbitrary data in the buffer, and do not receive it back in the PingReply.
        [PlatformSpecific(PlatformID.Windows)]
        [Fact]
        public async Task SendPingAsyncWithIPAddressAndTimeoutAndBuffer()
        {
            byte[] buffer = TestSettings.PayloadAsBytes;
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress, TestSettings.PingTimeout, buffer),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    Assert.Equal(buffer, pingReply.Buffer);
                });
        }

        [PlatformSpecific(PlatformID.AnyUnix)]
        [Fact]
        public async Task SendPingAsyncWithIPAddressAndTimeoutAndBuffer_Unix()
        {
            byte[] buffer = TestSettings.PayloadAsBytes;
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress, TestSettings.PingTimeout, buffer),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    if (CanUseRawSockets())
                    {
                        Assert.Equal(buffer, pingReply.Buffer);
                    }
                    else
                    {
                        Assert.Equal(Array.Empty<byte>(), pingReply.Buffer);
                    }
                });
        }

        // Non-root pings cannot send arbitrary data in the buffer, and do not receive it back in the PingReply.
        [PlatformSpecific(PlatformID.Windows)]
        [Fact]
        public async Task SendPingAsyncWithIPAddressAndTimeoutAndBufferAndPingOptions()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress, TestSettings.PingTimeout, buffer, new PingOptions()),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    Assert.Equal(buffer, pingReply.Buffer);
                });
        }

        // Non-root pings cannot send arbitrary data in the buffer, and do not receive it back in the PingReply.
        [PlatformSpecific(PlatformID.AnyUnix)]
        [Fact]
        public async Task SendPingAsyncWithIPAddressAndTimeoutAndBufferAndPingOptions_Unix()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(localIpAddress, TestSettings.PingTimeout, buffer, new PingOptions()),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    if (CanUseRawSockets())
                    {
                        Assert.Equal(buffer, pingReply.Buffer);
                    }
                    else
                    {
                        Assert.Equal(Array.Empty<byte>(), pingReply.Buffer);
                    }
                });
        }

        [Fact]
        public async Task SendPingAsyncWithHost()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));
                });
        }

        [Fact]
        public async Task SendPingAsyncWithHostAndTimeout()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost, TestSettings.PingTimeout),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));
                });
        }

        // Non-root pings cannot send arbitrary data in the buffer, and do not receive it back in the PingReply.
        [PlatformSpecific(PlatformID.Windows)]
        [Fact]
        public async Task SendPingAsyncWithHostAndTimeoutAndBuffer()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost, TestSettings.PingTimeout, buffer),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    Assert.Equal(buffer, pingReply.Buffer);
                });
        }

        [PlatformSpecific(PlatformID.AnyUnix)]
        [Fact]
        public async Task SendPingAsyncWithHostAndTimeoutAndBuffer_Unix()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost, TestSettings.PingTimeout, buffer),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    if (CanUseRawSockets())
                    {
                        Assert.Equal(buffer, pingReply.Buffer);
                    }
                    else
                    {
                        Assert.Equal(Array.Empty<byte>(), pingReply.Buffer);
                    }
                });
        }

        // Non-root pings cannot send arbitrary data in the buffer, and do not receive it back in the PingReply.
        [PlatformSpecific(PlatformID.Windows)]
        [Fact]
        public async Task SendPingAsyncWithHostAndTimeoutAndBufferAndPingOptions()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost, TestSettings.PingTimeout, buffer, new PingOptions()),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    Assert.Equal(buffer, pingReply.Buffer);
                });
        }

        [PlatformSpecific(PlatformID.AnyUnix)]
        [Fact]
        public async Task SendPingAsyncWithHostAndTimeoutAndBufferAndPingOptions_Unix()
        {
            IPAddress localIpAddress = await TestSettings.GetLocalIPAddress();

            byte[] buffer = TestSettings.PayloadAsBytes;
            SendBatchPingAsync(
                (ping) => ping.SendPingAsync(TestSettings.LocalHost, TestSettings.PingTimeout, buffer, new PingOptions()),
                (pingReply) =>
                {
                    Assert.Equal(IPStatus.Success, pingReply.Status);
                    Assert.True(pingReply.Address.Equals(localIpAddress));

                    if (CanUseRawSockets())
                    {
                        Assert.Equal(buffer, pingReply.Buffer);
                    }
                    else
                    {
                        Assert.Equal(Array.Empty<byte>(), pingReply.Buffer);
                    }
                });
        }

        private const int PingCount = 4;

        private static void SendBatchPingAsync(Func<Ping, Task<PingReply>> sendPing, Action<PingReply> pingResultValidator)
        {
            // create several concurrent pings
            Task[] pingTasks = new Task[PingCount];
            for (int i = 0; i < PingCount; i++)
            {
                pingTasks[i] = SendPingAsync(sendPing, pingResultValidator);
            }
            Task.WaitAll(pingTasks);
        }

        private static async Task SendPingAsync(Func<Ping, Task<PingReply>> sendPing, Action<PingReply> pingResultValidator)
        {
            var pingResult = await sendPing(new Ping());
            pingResultValidator(pingResult);
        }

        private static bool CanUseRawSockets()
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
    }
}

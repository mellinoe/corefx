﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace System.Net.NetworkInformation
{
    internal class LinuxIPGlobalProperties : IPGlobalProperties
    {
        public override string DhcpScopeName
        {
            get
            {
                throw new PlatformNotSupportedException();
            }
        }

        public override string DomainName
        {
            get
            {
                return HostInformation.DomainName;
            }
        }

        public override string HostName
        {
            get
            {
                return HostInformation.HostName;
            }
        }

        public override bool IsWinsProxy
        {
            get
            {
                throw new PlatformNotSupportedException();
            }
        }

        public override NetBiosNodeType NodeType
        {
            get
            {
                return NetBiosNodeType.Unknown;
            }
        }

        public override TcpConnectionInformation[] GetActiveTcpConnections()
        {
            return LinuxStringParsingHelpers.ParseActiveTcpConnectionsFromFiles(NetworkFiles.Tcp4ConnectionsFile, NetworkFiles.Tcp6ConnectionsFile);
        }

        public override IPEndPoint[] GetActiveTcpListeners()
        {
            return LinuxStringParsingHelpers.ParseActiveTcpListenersFromFiles(NetworkFiles.Tcp4ConnectionsFile, NetworkFiles.Tcp6ConnectionsFile);
        }

        public override IPEndPoint[] GetActiveUdpListeners()
        {
            return LinuxStringParsingHelpers.ParseActiveUdpListenersFromFiles(NetworkFiles.Udp4ConnectionsFile, NetworkFiles.Udp6ConnectionsFile);
        }

        public override IcmpV4Statistics GetIcmpV4Statistics()
        {
            return new LinuxIcmpV4Statistics();
        }

        public override IcmpV6Statistics GetIcmpV6Statistics()
        {
            return new LinuxIcmpV6Statistics();
        }

        public override IPGlobalStatistics GetIPv4GlobalStatistics()
        {
            return new LinuxIPGlobalStatistics(ipv4: true);
        }

        public override IPGlobalStatistics GetIPv6GlobalStatistics()
        {
            return new LinuxIPGlobalStatistics(ipv4: false);
        }

        public override TcpStatistics GetTcpIPv4Statistics()
        {
            return new LinuxTcpStatistics(ipv4: true);
        }

        public override TcpStatistics GetTcpIPv6Statistics()
        {
            return new LinuxTcpStatistics(ipv4: false);
        }

        public override UdpStatistics GetUdpIPv4Statistics()
        {
            return new LinuxUdpStatistics(true);
        }

        public override UdpStatistics GetUdpIPv6Statistics()
        {
            return new LinuxUdpStatistics(false);
        }

        private UnicastIPAddressInformationCollection GetUnicastAddresses()
        {
            UnicastIPAddressInformationCollection collection = new UnicastIPAddressInformationCollection();
            foreach (UnicastIPAddressInformation info in
                LinuxNetworkInterface.GetLinuxNetworkInterfaces().SelectMany(lni => lni.GetIPProperties().UnicastAddresses))
            {
                // PERF: Use Interop.Sys.EnumerateInterfaceAddresses directly here.
                collection.InternalAdd(info);
            }

            return collection;
        }

        public override Task<UnicastIPAddressInformationCollection> GetUnicastAddressesAsync()
        {
            return Task.Run((Func<UnicastIPAddressInformationCollection>)GetUnicastAddresses);
        }
    }
}

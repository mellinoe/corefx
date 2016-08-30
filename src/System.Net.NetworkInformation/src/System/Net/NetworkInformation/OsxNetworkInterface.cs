// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace System.Net.NetworkInformation
{
    internal class OsxNetworkInterface : UnixNetworkInterface
    {
        private readonly OsxIpInterfaceProperties _ipProperties;
        private readonly long _speed;

        protected unsafe OsxNetworkInterface(int index, string name) : base(int index, name)
        {
            Interop.Sys.NativeIPInterfaceStatistics nativeStats;
            if (Interop.Sys.GetNativeIPInterfaceStatistics(name, out nativeStats) == -1)
            {
                throw new NetworkInformationException(SR.net_PInvokeError);
            }

            _speed = (long)nativeStats.Speed;
            _ipProperties = new OsxIpInterfaceProperties(this, (int)nativeStats.Mtu);
        }

        public unsafe static NetworkInterface[] GetOsxNetworkInterfaces()
        {
            Dictionary<string, OsxNetworkInterface> interfacesByName = new Dictionary<string, OsxNetworkInterface>();
            Dictionary<uint, OsxNetworkInterface> interfacesByIndex = new Dictionary<uint, OsxNetworkInterface>();
            const int MaxRetries = 3;
            for (int attempt = 0; attempt < MaxRetries; attempt++)
            {
                interfacesByName.Clear();
                bool invalidate = false;
                int result = Interop.Sys.EnumerateInterfaceAddresses(
                    (index, name, ipAddr, maskAddr) =>
                    {
                        OsxNetworkInterface oni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out oni))
                        {
                            invalidate = true;
                        }
                        oni.ProcessIpv4Address(ipAddr, maskAddr);
                    },
                    (index, name, ipAddr, scopeId) =>
                    {
                        OsxNetworkInterface oni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out oni))
                        {
                            invalidate = true;
                        }
                        oni.ProcessIpv6Address(ipAddr, *scopeId);
                    },
                    (index, name, llAddr) =>
                    {
                        OsxNetworkInterface oni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out oni))
                        {
                            invalidate = true;
                        }
                        oni.ProcessLinkLayerAddress(llAddr);
                    });
                if (result == 0 && !invalidate)
                {
                    return interfacesByName.Values.ToArray();
                }
            }
            
            throw new NetworkInformationException(SR.net_PInvokeError);
        }

        /// <summary>
        /// Gets or creates a OsxNetworkInterface, based on whether it already exists in the given
        /// Dictionaries. If the given index and names do not match what was previously given for
        /// either value, then this method returns false. If the values do match, true is returned
        /// and oni contains the cached interface. If the interface has not been cached, a new one
        /// is created and added to both dictionaries.
        /// </summary>
        /// <param name="interfacesByName">The Dictionary of existing interfaces, indexed by name.</param>
        /// <param name="interfacesByName">The Dictionary of existing interfaces, indexed by interface index.</param>
        /// <param name="name">The name of the interface.</param>
        /// <returns>The cached or new OsxNetworkInterface with the given name.</returns>
        private static bool GetOrCreate(
            Dictionary<string, OsxNetworkInterface> interfacesByName,
            Dictionary<uint, OsxNetworkInterface> interfacesByIndex,
            uint index,
            string name,
            out OsxNetworkInterface oni)
        {
            OsxNetworkInterface fromName;
            OsxNetworkInterface fromIndex;
            interfacesByName.TryGetValue(name, out fromName);
            interfacesByIndex.TryGetValue(index, out fromIndex);

            if (fromName != fromIndex)
            {
                oni = null;
                return false;
            }
            else if (fromName == fromIndex && fromName == null)
            {
                oni = new OsxNetworkInterface((int)index, name);
                interfacesByName.Add(name, oni);
                interfacesByIndex.Add(index, oni);
            }
            else
            {
                oni = fromName;
            }

            return true;
        }

        public override IPInterfaceProperties GetIPProperties()
        {
            return _ipProperties;
        }

        public override IPInterfaceStatistics GetIPStatistics()
        {
            return new OsxIpInterfaceStatistics(Name);
        }

        public override OperationalStatus OperationalStatus
        {
            get
            {
                // This is a crude approximation, but does allow us to determine
                // whether an interface is operational or not. The OS exposes more information
                // (see ifconfig and the "Status" label), but it's unclear how closely
                // that information maps to the OperationalStatus enum we expose here.
                return Addresses.Count > 0 ? OperationalStatus.Up : OperationalStatus.Unknown;
            }
        }

        public override long Speed { get { return _speed; } }

        public override bool SupportsMulticast { get { return _ipProperties.MulticastAddresses.Count > 0; } }

        public override bool IsReceiveOnly { get { throw new PlatformNotSupportedException(SR.net_InformationUnavailableOnPlatform); } }
    }
}

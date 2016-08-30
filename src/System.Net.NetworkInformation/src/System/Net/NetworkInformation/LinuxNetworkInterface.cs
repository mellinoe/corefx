// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace System.Net.NetworkInformation
{
    /// <summary>
    /// Implements a NetworkInterface on Linux.
    /// </summary>
    internal class LinuxNetworkInterface : UnixNetworkInterface
    {
        private readonly OperationalStatus _operationalStatus;
        private readonly bool? _supportsMulticast;
        private readonly long? _speed;
        private readonly LinuxIPInterfaceProperties _ipProperties;

        internal LinuxNetworkInterface(int index, string name) : base(index, name)
        {
            _operationalStatus = GetOperationalStatus(name);
            _supportsMulticast = GetSupportsMulticast(name);
            _speed = GetSpeed(name);
            _ipProperties = new LinuxIPInterfaceProperties(this);
        }
        
        public unsafe static NetworkInterface[] GetLinuxNetworkInterfaces()
        {
            Dictionary<string, LinuxNetworkInterface> interfacesByName = new Dictionary<string, LinuxNetworkInterface>();
            Dictionary<uint, LinuxNetworkInterface> interfacesByIndex = new Dictionary<uint, LinuxNetworkInterface>();
            const int MaxRetries = 3;
            for (int attempt = 0; attempt < MaxRetries; attempt++)
            {
                interfacesByName.Clear();
                interfacesByIndex.Clear();
                bool invalidate = false;
                int result = Interop.Sys.EnumerateInterfaceAddresses(
                    (index, name, ipAddr, maskAddr) =>
                    {
                        LinuxNetworkInterface lni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out lni))
                        {
                            invalidate = true;
                        }
                        else
                        {
                            lni.ProcessIpv4Address(ipAddr, maskAddr);
                        }
                    },
                    (index, name, ipAddr, scopeId) =>
                    {
                        LinuxNetworkInterface lni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out lni))
                        {
                            invalidate = true;
                        }
                        else
                        {
                            lni.ProcessIpv6Address(ipAddr, *scopeId);
                        }
                    },
                    (index, name, llAddr) =>
                    {
                        LinuxNetworkInterface lni;
                        if (!GetOrCreate(interfacesByName, interfacesByIndex, index, name, out lni))
                        {
                            invalidate = true;
                        }
                        else
                        {
                            lni.ProcessLinkLayerAddress(llAddr);
                        }
                    });
                if (result == 0 && !invalidate)
                {
                    return interfacesByName.Values.ToArray();
                }
            }
            
            throw new NetworkInformationException(SR.net_PInvokeError);
        }

        /// <summary>
        /// Gets or creates a LinuxNetworkInterface, based on whether it already exists in the given
        /// Dictionaries. If the given index and names do not match what was previously given for
        /// either value, then this method returns false. If the values do match, true is returned
        /// and lni contains the cached interface. If the interface has not been cached, a new one
        /// is created and added to both dictionaries.
        /// </summary>
        /// <param name="interfacesByName">The Dictionary of existing interfaces, indexed by name.</param>
        /// <param name="interfacesByName">The Dictionary of existing interfaces, indexed by interface index.</param>
        /// <param name="name">The name of the interface.</param>
        /// <returns>The cached or new LinuxNetworkInterface with the given name.</returns>
        private static bool GetOrCreate(
            Dictionary<string, LinuxNetworkInterface> interfacesByName,
            Dictionary<uint, LinuxNetworkInterface> interfacesByIndex,
            uint index,
            string name,
            out LinuxNetworkInterface lni)
        {
            LinuxNetworkInterface fromName;
            LinuxNetworkInterface fromIndex;
            interfacesByName.TryGetValue(name, out fromName);
            interfacesByIndex.TryGetValue(index, out fromIndex);

            if (fromName != fromIndex)
            {
                lni = null;
                return false;
            }
            else if (fromName == fromIndex && fromName == null)
            {
                lni = new LinuxNetworkInterface((int)index, name);
                interfacesByName.Add(name, lni);
                interfacesByIndex.Add(index, lni);
            }
            else
            {
                lni = fromName;
            }

            return true;
        }

        public override bool SupportsMulticast
        {
            get
            {
                if (_supportsMulticast.HasValue)
                {
                    return _supportsMulticast.Value;
                }
                else
                {
                    throw new PlatformNotSupportedException(SR.net_InformationUnavailableOnPlatform);
                }
            }
        }

        private static bool? GetSupportsMulticast(string name)
        {
            // /sys/class/net/<interface_name>/flags
            string path = Path.Combine(NetworkFiles.SysClassNetFolder, name, NetworkFiles.FlagsFileName);

            if (File.Exists(path))
            {
                try
                {
                    Interop.LinuxNetDeviceFlags flags = (Interop.LinuxNetDeviceFlags)StringParsingHelpers.ParseRawHexFileAsInt(path);
                    return (flags & Interop.LinuxNetDeviceFlags.IFF_MULTICAST) == Interop.LinuxNetDeviceFlags.IFF_MULTICAST;
                }
                catch (FileNotFoundException)
                {
                }
            }

            return null;
        }

        public override IPInterfaceProperties GetIPProperties()
        {
            return _ipProperties;
        }

        public override IPInterfaceStatistics GetIPStatistics()
        {
            return new LinuxIPInterfaceStatistics(_name);
        }

        public override OperationalStatus OperationalStatus { get { return _operationalStatus; } }

        public override long Speed
        {
            get
            {
                if (_speed.HasValue)
                {
                    return _speed.Value;
                }
                else
                {
                    throw new PlatformNotSupportedException(SR.net_InformationUnavailableOnPlatform);
                }
            }
        }

        public override bool IsReceiveOnly { get { throw new PlatformNotSupportedException(SR.net_InformationUnavailableOnPlatform); } }

        private static long? GetSpeed(string name)
        {
            try
            {
                string path = Path.Combine(NetworkFiles.SysClassNetFolder, name, NetworkFiles.SpeedFileName);
                return StringParsingHelpers.ParseRawLongFile(path);
            }
            catch (IOException) // Some interfaces may give an "Invalid argument" error when opening this file.
            {
                return null;
            }
        }

        private static OperationalStatus GetOperationalStatus(string name)
        {
            // /sys/class/net/<name>/operstate
            string path = Path.Combine(NetworkFiles.SysClassNetFolder, name, NetworkFiles.OperstateFileName);
            if (File.Exists(path))
            {
                try
                {
                    string state = File.ReadAllText(path).Trim();
                    return MapState(state);
                }
                catch (FileNotFoundException)
                {
                }
            }

            return OperationalStatus.Unknown;
        }

        // Maps values from /sys/class/net/<interface>/operstate to OperationStatus values.
        private static OperationalStatus MapState(string state)
        {
            //
            // http://users.sosdg.org/~qiyong/lxr/source/Documentation/networking/operstates.txt?a=um#L41
            //
            switch (state)
            {
                case "unknown":
                    return OperationalStatus.Unknown;
                case "notpresent":
                    return OperationalStatus.NotPresent;
                case "down":
                    return OperationalStatus.Down;
                case "lowerlayerdown":
                    return OperationalStatus.LowerLayerDown;
                case "testing":
                    return OperationalStatus.Testing;
                case "dormant":
                    return OperationalStatus.Dormant;
                case "up":
                    return OperationalStatus.Up;
                default:
                    return OperationalStatus.Unknown;
            }
        }
    }
}

﻿namespace System.Net.NetworkInformation
{
    internal static class NetworkInterfacePal
    {
        /// Returns objects that describe the network interfaces on the local computer.
        public static NetworkInterface[] GetAllNetworkInterfaces()
        {
            return SystemNetworkInterface.GetNetworkInterfaces();
        }

        public static bool GetIsNetworkAvailable()
        {
            return SystemNetworkInterface.InternalGetIsNetworkAvailable();
        }

        public static int LoopbackInterfaceIndex
        {
            get
            {
                return SystemNetworkInterface.InternalLoopbackInterfaceIndex;
            }
        }

        public static int IPv6LoopbackInterfaceIndex
        {
            get
            {
                return SystemNetworkInterface.InternalIPv6LoopbackInterfaceIndex;
            }
        }
    }
}

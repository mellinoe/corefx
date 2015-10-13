﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Sockets;

namespace System.Net.NetworkInformation
{
    public delegate void NetworkAddressChangedEventHandler(object sender, EventArgs e);

    public delegate void NetworkAvailabilityChangedEventHandler(object sender, NetworkAvailabilityEventArgs e);

    // Linux implementation of NetworkChange
    public class NetworkChange
    {
        private static Socket s_netlinkSocket;

        static public event NetworkAvailabilityChangedEventHandler NetworkAvailabilityChanged
        {
            add
            {
                unsafe
                {
                    if (s_netlinkSocket == null)
                    {
                        s_netlinkSocket = Interop.Sys.CreateAndBindNetlinkSocket();
                    }
                }
            }
            remove
            {
                throw new PlatformNotSupportedException();
            }
        }

        static public event NetworkAddressChangedEventHandler NetworkAddressChanged
        {
            add
            {
                throw new PlatformNotSupportedException();
            }
            remove
            {
                throw new PlatformNotSupportedException();
            }
        }
    }
}

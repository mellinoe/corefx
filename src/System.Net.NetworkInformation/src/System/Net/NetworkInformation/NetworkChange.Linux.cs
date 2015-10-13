// Copyright (c) Microsoft. All rights reserved.
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
                        CreateSocket();
                    }
                }
            }
            remove
            {
                throw new PlatformNotSupportedException();
            }
        }

        private static unsafe void CreateSocket()
        {
            s_netlinkSocket = Interop.Sys.CreateAndBindNetlinkSocket();
            SocketAsyncEventArgs asyncArgs = new SocketAsyncEventArgs();
            byte[] buffer = new byte[4096];
            asyncArgs.SetBuffer(buffer, 0, buffer.Length);
            asyncArgs.Completed += OnSocketReceived;
            Console.WriteLine("Entering ReceiveAsync loop");
            while (s_netlinkSocket.ReceiveAsync(asyncArgs))
            {

            }
            Console.WriteLine("Exited ReceiveAsync loop.");
        }

        public static void OnSocketReceived(object sender, SocketAsyncEventArgs args)
        {
            Console.WriteLine("_-^-_ Receiving data from socket. _-^-_");
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

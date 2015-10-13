// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Sys
    {
        public enum NetworkInterfaceChangeEventType : uint
        {
            None = 0,
            LinkAdded,
            LinkDeleted,
            AddressAdded,
            AddressDeleted,
        };

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct NetworkInterfaceChangeInfo
        {
            public readonly NetworkInterfaceChangeEventType EventType;
        }

        public unsafe delegate void NetworkInterfaceChangeEvent(NetworkInterfaceChangeInfo* nici);

        [DllImport(Libraries.SystemNative)]
        public static extern int RegisterNetworkChangeCallback(NetworkInterfaceChangeEvent changeEvent);

        [DllImport(Libraries.SystemNative)]
        public static unsafe extern void CreateNetlinkSockaddr(
            byte* addressBuffer,
            int* bufferLength,
            int* addressFamily,
            int* protocolFamily);

        public static unsafe Socket CreateAndBindNetlinkSocket()
        {
            byte* addressBuffer = stackalloc byte[32];
            int bufferLength = 32;
            int addressFamily, protocolFamily;
            CreateNetlinkSockaddr(addressBuffer, &bufferLength, &addressFamily, &protocolFamily);
            
            Socket socket = new Socket((AddressFamily)addressFamily, SocketType.Raw, (ProtocolType)protocolFamily);
            SocketAddress sa = new SocketAddress(AddressFamily.Unknown, bufferLength);
            for (int i = 0; i < bufferLength; i++)
            {
                sa[i] = addressBuffer[i];
            }

            socket.Bind(new NetlinkEndPoint(sa));
            return socket;
        }

        private sealed class NetlinkEndPoint : EndPoint
        {
            private SocketAddress _socketAddress;

            public NetlinkEndPoint(SocketAddress addr)
            {
                _socketAddress = addr;
            }

            public override AddressFamily AddressFamily
            {
                get { return AddressFamily.Unknown; }
            }

            public override SocketAddress Serialize()
            {
                return _socketAddress;
            }

            public override EndPoint Create(SocketAddress socketAddress)
            {
                return _socketAddress == socketAddress ? this : new NetlinkEndPoint(socketAddress);   
            }
        }
    }
}
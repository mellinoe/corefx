﻿using System.Globalization;
using System.IO;

namespace System.Net.NetworkInformation
{
    internal class LinuxIPGlobalProperties : IPGlobalProperties
    {
        private static readonly string[] newLineSeparator = new string[] { Environment.NewLine }; // Used for string splitting

        public override string DhcpScopeName
        {
            get
            {
                throw new NotImplementedException();
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
                return false;
            }
        }

        public override NetBiosNodeType NodeType
        {
            get
            {
                // Could return NetBiosNodeType.Unknown (?)
                throw new NotImplementedException();
            }
        }

        public override TcpConnectionInformation[] GetActiveTcpConnections()
        {
            string tcp4FileContents = File.ReadAllText(LinuxNetworkFiles.Tcp4ConnectionsFile);
            string[] v4connections = tcp4FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string tcp6FileContents = File.ReadAllText(LinuxNetworkFiles.Tcp6ConnectionsFile);
            string[] v6connections = tcp6FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            TcpConnectionInformation[] connections = new TcpConnectionInformation[v4connections.Length + v6connections.Length - 2]; // First line is header in each file
            int index = 0;

            // UDP Connections
            for (int i = 1; i < v4connections.Length; i++) // Skip first line header
            {
                string line = v4connections[i];
                connections[index++] = ParseTcpConnectionInformationFromLine(line);
            }

            // UDP6 Connections
            for (int i = 1; i < v6connections.Length; i++) // Skip first line header
            {
                string line = v6connections[i];
                IPAddress remoteIPAddress;
                int remotePort;
                ParseRemoteConnectionInformation(line, out remoteIPAddress, out remotePort);

                connections[index++] = ParseTcpConnectionInformationFromLine(line);
            }

            return connections;
        }

        public override IPEndPoint[] GetActiveTcpListeners()
        {
            string tcp4FileContents = File.ReadAllText(LinuxNetworkFiles.Tcp4ConnectionsFile);
            string[] v4connections = tcp4FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string tcp6FileContents = File.ReadAllText(LinuxNetworkFiles.Tcp6ConnectionsFile);
            string[] v6connections = tcp6FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            IPEndPoint[] endPoints = new IPEndPoint[v4connections.Length + v6connections.Length - 2]; // First line is header in each file
            int index = 0;

            // TCP Connections
            for (int i = 1; i < v4connections.Length; i++) // Skip first line header
            {
                string line = v4connections[i];
                IPAddress remoteIPAddress;
                int remotePort;
                ParseRemoteConnectionInformation(line, out remoteIPAddress, out remotePort);

                endPoints[index++] = new IPEndPoint(remoteIPAddress, remotePort);
            }

            // TCP6 Connections
            for (int i = 1; i < v6connections.Length; i++) // Skip first line header
            {
                string line = v6connections[i];
                IPAddress remoteIPAddress;
                int remotePort;
                ParseRemoteConnectionInformation(line, out remoteIPAddress, out remotePort);

                endPoints[index++] = new IPEndPoint(remoteIPAddress, remotePort);
            }

            return endPoints;
        }

        public override IPEndPoint[] GetActiveUdpListeners()
        {
            string udp4FileContents = File.ReadAllText(LinuxNetworkFiles.Udp4ConnectionsFile);
            string[] v4connections = udp4FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string udp6FileContents = File.ReadAllText(LinuxNetworkFiles.Udp6ConnectionsFile);
            string[] v6connections = udp6FileContents.Split(newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            IPEndPoint[] endPoints = new IPEndPoint[v4connections.Length + v6connections.Length - 2]; // First line is header in each file
            int index = 0;

            // UDP Connections
            for (int i = 1; i < v4connections.Length; i++) // Skip first line header
            {
                string line = v4connections[i];
                IPAddress remoteIPAddress;
                int remotePort;
                ParseRemoteConnectionInformation(line, out remoteIPAddress, out remotePort);

                endPoints[index++] = new IPEndPoint(remoteIPAddress, remotePort);
            }

            // UDP6 Connections
            for (int i = 1; i < v6connections.Length; i++) // Skip first line header
            {
                string line = v6connections[i];
                IPAddress remoteIPAddress;
                int remotePort;
                ParseRemoteConnectionInformation(line, out remoteIPAddress, out remotePort);

                endPoints[index++] = new IPEndPoint(remoteIPAddress, remotePort);
            }

            return endPoints;
        }

        public override IcmpV4Statistics GetIcmpV4Statistics()
        {
            return LinuxIcmpV4Statistics.CreateIcmpV4Statistics();
        }

        public override IcmpV6Statistics GetIcmpV6Statistics()
        {
            return LinuxIcmpV6Statistics.CreateIcmpV6Statistics();
        }

        public override IPGlobalStatistics GetIPv4GlobalStatistics()
        {
            return LinuxIPGlobalStatistics.CreateIPv4Statistics();
        }

        public override IPGlobalStatistics GetIPv6GlobalStatistics()
        {
            return LinuxIPGlobalStatistics.CreateIPv6Statistics();
        }

        public override TcpStatistics GetTcpIPv4Statistics()
        {
            return LinuxTcpStatistics.CreateTcpStatistics(false);
        }

        public override TcpStatistics GetTcpIPv6Statistics()
        {
            return LinuxTcpStatistics.CreateTcpStatistics(true);
        }

        public override UdpStatistics GetUdpIPv4Statistics()
        {
            return LinuxUdpStatistics.CreateUdpIPv4Statistics();
        }

        public override UdpStatistics GetUdpIPv6Statistics()
        {
            return LinuxUdpStatistics.CreateUdpIPv6Statistics();
        }

        // Parsing logic for local and remote addresses and ports, as well as socket state.
        private static TcpConnectionInformation ParseTcpConnectionInformationFromLine(string line)
        {
            StringParser parser = new StringParser(line, ' ', true);
            parser.MoveNextOrFail(); // skip Index

            string localAddressAndPort = parser.MoveAndExtractNext(); // local_address
            IPAddress localAddress;
            int localPort;
            ParseAddressAndPort(localAddressAndPort, out localAddress, out localPort);

            string remoteAddressAndPort = parser.MoveAndExtractNext(); // rem_address
            IPAddress remoteAddress;
            int remotePort;
            ParseAddressAndPort(remoteAddressAndPort, out remoteAddress, out remotePort);

            string socketStateHex = parser.MoveAndExtractNext();
            int state;
            if (!int.TryParse(socketStateHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out state))
            {
                throw new InvalidOperationException("Invalid state value: " + socketStateHex);
            }
            TcpState tcpState = MapTcpState((LinuxTcpState)state);

            IPEndPoint localEndPoint = new IPEndPoint(localAddress, localPort);
            IPEndPoint remoteEndPoint = new IPEndPoint(remoteAddress, remotePort);

            return new LinuxTcpConnectionInformation(localEndPoint, remoteEndPoint, tcpState);
        }

        // Maps from Linux TCP states (include/net/tcp_states.h) to .NET TcpStates
        private static TcpState MapTcpState(LinuxTcpState state)
        {
            switch (state)
            {
                case LinuxTcpState.TCP_ESTABLISHED:
                    return TcpState.Established;
                case LinuxTcpState.TCP_SYN_SENT:
                    return TcpState.SynSent;
                case LinuxTcpState.TCP_SYN_RECV:
                    return TcpState.SynReceived;
                case LinuxTcpState.TCP_FIN_WAIT1:
                    return TcpState.FinWait1;
                case LinuxTcpState.TCP_FIN_WAIT2:
                    return TcpState.FinWait2;
                case LinuxTcpState.TCP_TIME_WAIT:
                    return TcpState.TimeWait;
                case LinuxTcpState.TCP_CLOSE:
                    return TcpState.Closing;
                case LinuxTcpState.TCP_CLOSE_WAIT:
                    return TcpState.CloseWait;
                case LinuxTcpState.TCP_LAST_ACK:
                    return TcpState.LastAck;
                case LinuxTcpState.TCP_LISTEN:
                    return TcpState.Listen;
                case LinuxTcpState.TCP_CLOSING:
                    return TcpState.Closing;
                case LinuxTcpState.TCP_NEW_SYN_RECV:
                    return TcpState.Unknown;
                case LinuxTcpState.TCP_MAX_STATES:
                    return TcpState.Unknown;
                default:
                    throw new InvalidOperationException("Invalid LinuxTcpState: " + state);
            }
        }

        // Common parsing logic for the remote connection information
        private static void ParseRemoteConnectionInformation(string line, out IPAddress remoteIPAddress, out int remotePort)
        {
            StringParser parser = new StringParser(line, ' ', true);
            parser.MoveNextOrFail(); // skip Index
            parser.MoveNextOrFail(); // skip local_address

            string remoteAddressAndPort = parser.MoveAndExtractNext();
            int indexOfColon = remoteAddressAndPort.IndexOf(':');
            if (indexOfColon == -1)
            {
                throw new InvalidOperationException("Parsing error. No colon in " + remoteAddressAndPort);
            }

            string remoteAddressString = remoteAddressAndPort.Substring(0, indexOfColon);
            remoteIPAddress = ParseHexIPAddress(remoteAddressString);

            string portString = remoteAddressAndPort.Substring(indexOfColon + 1, remoteAddressAndPort.Length - (indexOfColon + 1));
            if (!int.TryParse(portString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out remotePort))
            {
                throw new InvalidOperationException("Couldn't parse remote port number " + portString);
            }
        }

        private static void ParseAddressAndPort(string colonSeparatedAddress, out IPAddress ipAddress, out int port)
        {
            int indexOfColon = colonSeparatedAddress.IndexOf(':');
            if (indexOfColon == -1)
            {
                throw new InvalidOperationException("Parsing error. No colon in " + colonSeparatedAddress);
            }

            string remoteAddressString = colonSeparatedAddress.Substring(0, indexOfColon);
            ipAddress = ParseHexIPAddress(remoteAddressString);

            string portString = colonSeparatedAddress.Substring(indexOfColon + 1, colonSeparatedAddress.Length - (indexOfColon + 1));
            if (!int.TryParse(portString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out port))
            {
                throw new InvalidOperationException("Couldn't parse remote port number " + portString);
            }
        }

        private static IPAddress ParseHexIPAddress(string remoteAddressString)
        {
            if (remoteAddressString.Length <= 8) // IPv4 Address
            {
                return ParseIPv4HexString(remoteAddressString);
            }
            else // IPv6 Address
            {
                return ParseIPv6HexString(remoteAddressString);
            }
        }

        // Simply converst the hex string into a long and uses the IPAddress(long) constructor.
        // Strings passed to this method must be 8 or less characters in length (32-bit address).
        private static IPAddress ParseIPv4HexString(string hexAddress)
        {
            IPAddress ipAddress;
            long addressValue;
            if (!long.TryParse(hexAddress, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out addressValue))
            {
                throw new InvalidOperationException("Couldn't parse long from address string " + hexAddress);
            }
            ipAddress = new IPAddress(addressValue);
            return ipAddress;
        }

        // Parses a 128-bit IPv6 Address stored as a 32-character hex number.
        // Strings passed to this must be 32 characters in length.
        private static IPAddress ParseIPv6HexString(string hexAddress)
        {
            IPAddress ipAddress;
            // Dangerous Parsing Code
            byte[] addressBytes = new byte[16]
            {
                Convert.ToByte(hexAddress.Substring(0, 2), 16),
                Convert.ToByte(hexAddress.Substring(2, 2), 16),
                Convert.ToByte(hexAddress.Substring(4, 2), 16),
                Convert.ToByte(hexAddress.Substring(6, 2), 16),
                Convert.ToByte(hexAddress.Substring(8, 2), 16),
                Convert.ToByte(hexAddress.Substring(10, 2), 16),
                Convert.ToByte(hexAddress.Substring(12, 2), 16),
                Convert.ToByte(hexAddress.Substring(14, 2), 16),
                Convert.ToByte(hexAddress.Substring(16, 2), 16),
                Convert.ToByte(hexAddress.Substring(18, 2), 16),
                Convert.ToByte(hexAddress.Substring(20, 2), 16),
                Convert.ToByte(hexAddress.Substring(22, 2), 16),
                Convert.ToByte(hexAddress.Substring(24, 2), 16),
                Convert.ToByte(hexAddress.Substring(26, 2), 16),
                Convert.ToByte(hexAddress.Substring(28, 2), 16),
                Convert.ToByte(hexAddress.Substring(30, 2), 16),
            };

            ipAddress = new IPAddress(addressBytes);
            return ipAddress;
        }
    }
}
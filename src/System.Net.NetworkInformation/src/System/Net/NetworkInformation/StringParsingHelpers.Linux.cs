// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace System.Net.NetworkInformation
{
    /// <summary>
    /// A storage structure for the information parsed out of the
    /// /proc/net/snmp file, related to ICMPv4 protocol statistics.
    /// </summary>
    internal struct Icmpv4StatisticsTable
    {
        public int InMsgs;
        public int InErrors;
        public int InCsumErrors;
        public int InDestUnreachs;
        public int InTimeExcds;
        public int InParmProbs;
        public int InSrcQuenchs;
        public int InRedirects;
        public int InEchos;
        public int InEchoReps;
        public int InTimestamps;
        public int InTimeStampReps;
        public int InAddrMasks;
        public int InAddrMaskReps;
        public int OutMsgs;
        public int OutErrors;
        public int OutDestUnreachs;
        public int OutTimeExcds;
        public int OutParmProbs;
        public int OutSrcQuenchs;
        public int OutRedirects;
        public int OutEchos;
        public int OutEchoReps;
        public int OutTimestamps;
        public int OutTimestampReps;
        public int OutAddrMasks;
        public int OutAddrMaskReps;
    }

    /// <summary>
    /// A storage structure for the information parsed out of the
    /// /proc/net/snmp6 file, related to ICMPv6 protocol statistics.
    /// </summary>
    internal struct Icmpv6StatisticsTable
    {
        public int InDestUnreachs;
        public int OutDestUnreachs;
        public int InEchoReplies;
        public int InEchos;
        public int OutEchoReplies;
        public int OutEchos;
        public int InErrors;
        public int OutErrors;
        public int InGroupMembQueries;
        public int OutInGroupMembQueries;
        public int InGroupMembReductions;
        public int OutGroupMembReductions;
        public int InGroupMembResponses;
        public int OutGroupMembResponses;
        public int InMsgs;
        public int OutMsgs;
        public int InNeighborAdvertisements;
        public int OutNeighborAdvertisements;
        public int InNeighborSolicits;
        public int OutNeighborSolicits;
        public int InPktTooBigs;
        public int OutPktTooBigs;
        public int InParmProblems;
        public int OutParmProblems;
        public int InRedirects;
        public int OutRedirects;
        public int InRouterSolicits;
        public int OutRouterSolicits;
        public int InRouterAdvertisements;
        public int OutRouterAdvertisements;
        public int InTimeExcds;
        public int OutTimeExcds;
    }

    internal struct TcpGlobalStatisticsTable
    {
        public int RtoAlgorithm;
        public int RtoMin;
        public int RtoMax;
        public int MaxConn;
        public int ActiveOpens;
        public int PassiveOpens;
        public int AttemptFails;
        public int EstabResets;
        public int CurrEstab;
        public int InSegs;
        public int OutSegs;
        public int RetransSegs;
        public int InErrs;
        public int OutRsts;
        public int InCsumErrors;
    }

    internal struct UdpGlobalStatisticsTable
    {
        public int InDatagrams;
        public int NoPorts;
        public int InErrors;
        public int OutDatagrams;
        public int RcvbufErrors;
        public int SndbufErrors;
        public int InCsumErrors;
    }

    /// <summary>
    /// Storage structure for IP Global statistics from /proc/net/snmp
    /// </summary>
    internal struct IPGlobalStatisticsTable
    {
        // Information exposed in the snmp (ipv4) and snmp6 (ipv6) files under /proc/net
        // Each piece corresponds to a data item defined in the MIB-II specification:
        // http://www.ietf.org/rfc/rfc1213.txt
        // Each field's comment indicates the name as it appears in the snmp (snmp6) file.
        // In the snmp6 file, each name is prefixed with "IP6".

        public bool Forwarding; // Forwarding
        public int DefaultTtl; // DefaultTTL

        public int InReceives; // InReceives
        public int InHeaderErrors; // InHdrErrors
        public int InAddressErrors; // InAddrErrors
        public int ForwardedDatagrams; // ForwDatagrams (IP6OutForwDatagrams)
        public int InUnknownProtocols; // InUnknownProtos
        public int InDiscards; // InDiscards
        public int InDelivers; // InDelivers

        public int OutRequests; // OutRequestscat 
        public int OutDiscards; // OutDiscards
        public int OutNoRoutes; // OutNoRoutes

        public int ReassemblyTimeout; // ReasmTimeout
        public int ReassemblyRequireds; // ReasmReqds
        public int ReassemblyOKs; // ReasmOKs
        public int ReassemblyFails; // ReasmFails

        public int FragmentOKs; // FragOKs
        public int FragmentFails; // FragFails
        public int FragmentCreates; // FragCreates
    }

    internal struct IPInterfaceStatisticsTable
    {
        // Receive section
        public uint BytesReceived;
        public uint PacketsReceived;
        public uint ErrorsReceived;
        public uint IncomingPacketsDropped;
        public uint FifoBufferErrorsReceived;
        public uint PacketFramingErrorsReceived;
        public uint CompressedPacketsReceived;
        public uint MulticastFramesReceived;

        // Transmit section
        public uint BytesTransmitted;
        public uint PacketsTransmitted;
        public uint ErrorsTransmitted;
        public uint OutgoingPacketsDropped;
        public uint FifoBufferErrorsTransmitted;
        public uint CollisionsDetected;
        public uint CarrierLosses;
        public uint CompressedPacketsTransmitted;
    }

    internal static class LinuxStringParsingHelpers
    {
        private static readonly string[] s_newLineSeparator = new string[] { Environment.NewLine }; // Used for string splitting

        // Parses ICMP v4 statistics from /proc/net/snmp
        public static Icmpv4StatisticsTable ParseIcmpv4FromSnmpFile(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            int firstIpHeader = fileContents.IndexOf("Icmp:");
            int secondIpHeader = fileContents.IndexOf("Icmp:", firstIpHeader + 1);
            int endOfSecondLine = fileContents.IndexOf(Environment.NewLine, secondIpHeader);
            string icmpData = fileContents.Substring(secondIpHeader, endOfSecondLine - secondIpHeader);
            StringParser parser = new StringParser(icmpData, ' ');

            // NOTE: Need to verify that this order is consistent. Otherwise, we need to parse the first-line header
            // to determine the order of information contained in the file.

            parser.MoveNextOrFail(); // Skip Icmp:

            return new Icmpv4StatisticsTable()
            {
                InMsgs = parser.ParseNextInt32(),
                InErrors = parser.ParseNextInt32(),
                InCsumErrors = parser.ParseNextInt32(),
                InDestUnreachs = parser.ParseNextInt32(),
                InTimeExcds = parser.ParseNextInt32(),
                InParmProbs = parser.ParseNextInt32(),
                InSrcQuenchs = parser.ParseNextInt32(),
                InRedirects = parser.ParseNextInt32(),
                InEchos = parser.ParseNextInt32(),
                InEchoReps = parser.ParseNextInt32(),
                InTimestamps = parser.ParseNextInt32(),
                InTimeStampReps = parser.ParseNextInt32(),
                InAddrMasks = parser.ParseNextInt32(),
                InAddrMaskReps = parser.ParseNextInt32(),
                OutMsgs = parser.ParseNextInt32(),
                OutErrors = parser.ParseNextInt32(),
                OutDestUnreachs = parser.ParseNextInt32(),
                OutTimeExcds = parser.ParseNextInt32(),
                OutParmProbs = parser.ParseNextInt32(),
                OutSrcQuenchs = parser.ParseNextInt32(),
                OutRedirects = parser.ParseNextInt32(),
                OutEchos = parser.ParseNextInt32(),
                OutEchoReps = parser.ParseNextInt32(),
                OutTimestamps = parser.ParseNextInt32(),
                OutTimestampReps = parser.ParseNextInt32(),
                OutAddrMasks = parser.ParseNextInt32(),
                OutAddrMaskReps = parser.ParseNextInt32()
            };
        }

        public static Icmpv6StatisticsTable ParseIcmpv6FromSnmp6File(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            RowConfigReader reader = new RowConfigReader(fileContents);

            return new Icmpv6StatisticsTable()
            {
                InMsgs = reader.GetNextValueAsInt32("Icmp6InMsgs"),
                InErrors = reader.GetNextValueAsInt32("Icmp6InErrors"),
                OutMsgs = reader.GetNextValueAsInt32("Icmp6OutMsgs"),
                OutErrors = reader.GetNextValueAsInt32("Icmp6OutErrors"),
                InDestUnreachs = reader.GetNextValueAsInt32("Icmp6InDestUnreachs"),
                InPktTooBigs = reader.GetNextValueAsInt32("Icmp6InPktTooBigs"),
                InTimeExcds = reader.GetNextValueAsInt32("Icmp6InTimeExcds"),
                InParmProblems = reader.GetNextValueAsInt32("Icmp6InParmProblems"),
                InEchos = reader.GetNextValueAsInt32("Icmp6InEchos"),
                InEchoReplies = reader.GetNextValueAsInt32("Icmp6InEchoReplies"),
                InGroupMembQueries = reader.GetNextValueAsInt32("Icmp6InGroupMembQueries"),
                InGroupMembResponses = reader.GetNextValueAsInt32("Icmp6InGroupMembResponses"),
                InGroupMembReductions = reader.GetNextValueAsInt32("Icmp6InGroupMembReductions"),
                InRouterSolicits = reader.GetNextValueAsInt32("Icmp6InRouterSolicits"),
                InRouterAdvertisements = reader.GetNextValueAsInt32("Icmp6InRouterAdvertisements"),
                InNeighborSolicits = reader.GetNextValueAsInt32("Icmp6InNeighborSolicits"),
                InNeighborAdvertisements = reader.GetNextValueAsInt32("Icmp6InNeighborAdvertisements"),
                InRedirects = reader.GetNextValueAsInt32("Icmp6InRedirects"),
                OutDestUnreachs = reader.GetNextValueAsInt32("Icmp6OutDestUnreachs"),
                OutPktTooBigs = reader.GetNextValueAsInt32("Icmp6OutPktTooBigs"),
                OutTimeExcds = reader.GetNextValueAsInt32("Icmp6OutTimeExcds"),
                OutParmProblems = reader.GetNextValueAsInt32("Icmp6OutParmProblems"),
                OutEchos = reader.GetNextValueAsInt32("Icmp6OutEchos"),
                OutEchoReplies = reader.GetNextValueAsInt32("Icmp6OutEchoReplies"),
                OutInGroupMembQueries = reader.GetNextValueAsInt32("Icmp6OutGroupMembQueries"),
                OutGroupMembResponses = reader.GetNextValueAsInt32("Icmp6OutGroupMembResponses"),
                OutGroupMembReductions = reader.GetNextValueAsInt32("Icmp6OutGroupMembReductions"),
                OutRouterSolicits = reader.GetNextValueAsInt32("Icmp6OutRouterSolicits"),
                OutRouterAdvertisements = reader.GetNextValueAsInt32("Icmp6OutRouterAdvertisements"),
                OutNeighborSolicits = reader.GetNextValueAsInt32("Icmp6OutNeighborSolicits"),
                OutNeighborAdvertisements = reader.GetNextValueAsInt32("Icmp6OutNeighborAdvertisements"),
                OutRedirects = reader.GetNextValueAsInt32("Icmp6OutRedirects")
            };
        }

        public static IPGlobalStatisticsTable ParseIPv4GlobalStatisticsFromSnmpFile(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);

            int firstIpHeader = fileContents.IndexOf("Ip:");
            int secondIpHeader = fileContents.IndexOf("Ip:", firstIpHeader + 1);
            int endOfSecondLine = fileContents.IndexOf(Environment.NewLine, secondIpHeader);
            string ipData = fileContents.Substring(secondIpHeader, endOfSecondLine - secondIpHeader);
            StringParser parser = new StringParser(ipData, ' ');

            // NOTE: Need to verify that this order is consistent. Otherwise, we need to parse the first-line header
            // to determine the order of information contained in the file.

            parser.MoveNextOrFail(); // Skip Ip:

            // According to RFC 1213, "1" indicates "acting as a gateway". "2" indicates "NOT acting as a gateway".
            return new IPGlobalStatisticsTable()
            {
                Forwarding = parser.MoveAndExtractNext() == "1",
                DefaultTtl = parser.ParseNextInt32(),
                InReceives = parser.ParseNextInt32(),
                InHeaderErrors = parser.ParseNextInt32(),
                InAddressErrors = parser.ParseNextInt32(),
                ForwardedDatagrams = parser.ParseNextInt32(),
                InUnknownProtocols = parser.ParseNextInt32(),
                InDiscards = parser.ParseNextInt32(),
                InDelivers = parser.ParseNextInt32(),
                OutRequests = parser.ParseNextInt32(),
                OutDiscards = parser.ParseNextInt32(),
                OutNoRoutes = parser.ParseNextInt32(),
                ReassemblyTimeout = parser.ParseNextInt32(),
                ReassemblyRequireds = parser.ParseNextInt32(),
                ReassemblyOKs = parser.ParseNextInt32(),
                ReassemblyFails = parser.ParseNextInt32(),
                FragmentOKs = parser.ParseNextInt32(),
                FragmentFails = parser.ParseNextInt32(),
                FragmentCreates = parser.ParseNextInt32(),
            };
        }

        internal static IPGlobalStatisticsTable ParseIPv6GlobalStatisticsFromSnmp6File(string filePath)
        {
            // Read the remainder of statistics from snmp6.
            string fileContents = File.ReadAllText(filePath);
            RowConfigReader reader = new RowConfigReader(fileContents);

            return new IPGlobalStatisticsTable()
            {
                InReceives = reader.GetNextValueAsInt32("Ip6InReceives"),
                InHeaderErrors = reader.GetNextValueAsInt32("Ip6InHdrErrors"),
                InAddressErrors = reader.GetNextValueAsInt32("Ip6InAddrErrors"),
                InUnknownProtocols = reader.GetNextValueAsInt32("Ip6InUnknownProtos"),
                InDiscards = reader.GetNextValueAsInt32("Ip6InDiscards"),
                InDelivers = reader.GetNextValueAsInt32("Ip6InDelivers"),
                ForwardedDatagrams = reader.GetNextValueAsInt32("Ip6OutForwDatagrams"),
                OutRequests = reader.GetNextValueAsInt32("Ip6OutRequests"),
                OutDiscards = reader.GetNextValueAsInt32("Ip6OutDiscards"),
                OutNoRoutes = reader.GetNextValueAsInt32("Ip6OutNoRoutes"),
                ReassemblyTimeout = reader.GetNextValueAsInt32("Ip6ReasmTimeout"),
                ReassemblyRequireds = reader.GetNextValueAsInt32("Ip6ReasmReqds"),
                ReassemblyOKs = reader.GetNextValueAsInt32("Ip6ReasmOKs"),
                ReassemblyFails = reader.GetNextValueAsInt32("Ip6ReasmFails"),
                FragmentOKs = reader.GetNextValueAsInt32("Ip6FragOKs"),
                FragmentFails = reader.GetNextValueAsInt32("Ip6FragFails"),
                FragmentCreates = reader.GetNextValueAsInt32("Ip6FragCreates"),
            };
        }

        internal static TcpGlobalStatisticsTable ParseTcpGlobalStatisticsFromSnmpFile(string filePath)
        {
            // NOTE: There is no information in the snmp6 file regarding TCP statistics,
            // so the statistics are always pulled from /proc/net/snmp.
            string fileContents = File.ReadAllText(filePath);
            int firstTcpHeader = fileContents.IndexOf("Tcp:");
            int secondTcpHeader = fileContents.IndexOf("Tcp:", firstTcpHeader + 1);
            int endOfSecondLine = fileContents.IndexOf(Environment.NewLine, secondTcpHeader);
            string tcpData = fileContents.Substring(secondTcpHeader, endOfSecondLine - secondTcpHeader);
            StringParser parser = new StringParser(tcpData, ' ');

            // NOTE: Need to verify that this order is consistent. Otherwise, we need to parse the first-line header
            // to determine the order of information contained in the row.

            parser.MoveNextOrFail(); // Skip Tcp:

            return new TcpGlobalStatisticsTable()
            {
                RtoAlgorithm = parser.ParseNextInt32(),
                RtoMin = parser.ParseNextInt32(),
                RtoMax = parser.ParseNextInt32(),
                MaxConn = parser.ParseNextInt32(),
                ActiveOpens = parser.ParseNextInt32(),
                PassiveOpens = parser.ParseNextInt32(),
                AttemptFails = parser.ParseNextInt32(),
                EstabResets = parser.ParseNextInt32(),
                CurrEstab = parser.ParseNextInt32(),
                InSegs = parser.ParseNextInt32(),
                OutSegs = parser.ParseNextInt32(),
                RetransSegs = parser.ParseNextInt32(),
                InErrs = parser.ParseNextInt32(),
                OutRsts = parser.ParseNextInt32(),
                InCsumErrors = parser.ParseNextInt32()
            };
        }

        internal static UdpGlobalStatisticsTable ParseUdpv4GlobalStatisticsFromSnmpFile(string filePath)
        {
            string fileContents = File.ReadAllText(NetworkFiles.SnmpV4StatsFile);
            int firstUdpHeader = fileContents.IndexOf("Udp:");
            int secondUdpHeader = fileContents.IndexOf("Udp:", firstUdpHeader + 1);
            int endOfSecondLine = fileContents.IndexOf(Environment.NewLine, secondUdpHeader);
            string tcpData = fileContents.Substring(secondUdpHeader, endOfSecondLine - secondUdpHeader);
            StringParser parser = new StringParser(tcpData, ' ');

            // NOTE: Need to verify that this order is consistent. Otherwise, we need to parse the first-line header
            // to determine the order of information contained in the file.

            parser.MoveNextOrFail(); // Skip Udp:

            return new UdpGlobalStatisticsTable()
            {
                InDatagrams = parser.ParseNextInt32(),
                NoPorts = parser.ParseNextInt32(),
                InErrors = parser.ParseNextInt32(),
                OutDatagrams = parser.ParseNextInt32(),
                RcvbufErrors = parser.ParseNextInt32(),
                SndbufErrors = parser.ParseNextInt32(),
                InCsumErrors = parser.ParseNextInt32()
            };
        }

        internal static UdpGlobalStatisticsTable ParseUdpv6GlobalStatisticsFromSnmp6File(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            RowConfigReader reader = new RowConfigReader(fileContents);

            return new UdpGlobalStatisticsTable()
            {
                InDatagrams = reader.GetNextValueAsInt32("Udp6InDatagrams"),
                NoPorts = reader.GetNextValueAsInt32("Udp6NoPorts"),
                InErrors = reader.GetNextValueAsInt32("Udp6InErrors"),
                OutDatagrams = reader.GetNextValueAsInt32("Udp6OutDatagrams"),
                RcvbufErrors = reader.GetNextValueAsInt32("Udp6RcvbufErrors"),
                SndbufErrors = reader.GetNextValueAsInt32("Udp6SndbufErrors"),
                InCsumErrors = reader.GetNextValueAsInt32("Udp6InCsumErrors"),
            };
        }

        internal static int ParseNumSocketConnections(string filePath, string protocolName)
        {
            // Parse the number of active connections out of /proc/net/sockstat
            string sockstatFile = File.ReadAllText(filePath);
            int indexOfTcp = sockstatFile.IndexOf(protocolName);
            int endOfTcpLine = sockstatFile.IndexOf(Environment.NewLine, indexOfTcp + 1);
            string tcpLineData = sockstatFile.Substring(indexOfTcp, endOfTcpLine - indexOfTcp);
            StringParser sockstatParser = new StringParser(tcpLineData, ' ');
            sockstatParser.MoveNextOrFail(); // Skip "<name>:"
            sockstatParser.MoveNextOrFail(); // Skip: "inuse"
            return sockstatParser.ParseNextInt32();
        }

        internal static int ParseNumRoutesFromRouteFile(string filePath)
        {
            string routeFile = File.ReadAllText(filePath);
            return CountOccurences(Environment.NewLine, routeFile) - 1; // File includes one-line header
        }

        internal static int ParseNumIPInterfaces(string folderPath)
        {
            // Just count the number of files under /proc/sys/net/<ipv4/ipv6>/conf,
            // because GetAllNetworkInterfaces() is relatively expensive just for the count.
            int interfacesCount = 0;
            var files = new DirectoryInfo(folderPath).GetFiles();
            foreach (var file in files)
            {
                if (file.Name != NetworkFiles.AllNetworkInterfaceFileName && file.Name != NetworkFiles.DefaultNetworkInterfaceFileName)
                {
                    interfacesCount++;
                }
            }

            return interfacesCount;
        }

        internal static int ParseDefaultTtlFromFile(string filePath)
        {
            // snmp6 does not include Default TTL info. Read it from snmp.
            string snmp4FileContents = File.ReadAllText(filePath);
            int firstIpHeader = snmp4FileContents.IndexOf("Ip:");
            int secondIpHeader = snmp4FileContents.IndexOf("Ip:", firstIpHeader + 1);
            int endOfSecondLine = snmp4FileContents.IndexOf(Environment.NewLine, secondIpHeader);
            string ipData = snmp4FileContents.Substring(secondIpHeader, endOfSecondLine - secondIpHeader);
            StringParser parser = new StringParser(ipData, ' ');
            parser.MoveNextOrFail(); // Skip Ip:
            // According to RFC 1213, "1" indicates "acting as a gateway". "2" indicates "NOT acting as a gateway".
            parser.MoveNextOrFail(); // Skip forwarding
            return parser.ParseNextInt32();
        }

        internal static IPInterfaceStatisticsTable ParseInterfaceStatisticsTableFromFile(string filePath, string name)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                sr.ReadLine();
                sr.ReadLine();
                int index = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains(name))
                    {
                        string[] pieces = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                        return new IPInterfaceStatisticsTable()
                        {
                            BytesReceived = uint.Parse(pieces[1]),
                            PacketsReceived = uint.Parse(pieces[2]),
                            ErrorsReceived = uint.Parse(pieces[3]),
                            IncomingPacketsDropped = uint.Parse(pieces[4]),
                            FifoBufferErrorsReceived = uint.Parse(pieces[5]),
                            PacketFramingErrorsReceived = uint.Parse(pieces[6]),
                            CompressedPacketsReceived = uint.Parse(pieces[7]),
                            MulticastFramesReceived = uint.Parse(pieces[8]),

                            BytesTransmitted = uint.Parse(pieces[9]),
                            PacketsTransmitted = uint.Parse(pieces[10]),
                            ErrorsTransmitted = uint.Parse(pieces[11]),
                            OutgoingPacketsDropped = uint.Parse(pieces[12]),
                            FifoBufferErrorsTransmitted = uint.Parse(pieces[13]),
                            CollisionsDetected = uint.Parse(pieces[14]),
                            CarrierLosses = uint.Parse(pieces[15]),
                            CompressedPacketsTransmitted = uint.Parse(pieces[16])
                        };
                    }
                    index += 1;
                }

                throw new NetworkInformationException();
            }
        }

        // /proc/net/route contains some information about gateway addresses,
        // and seperates the information about by each interface.
        internal static Collection<GatewayIPAddressInformation> ParseGatewayAddressesFromRouteFile(string filePath, string interfaceName)
        {
            Collection<GatewayIPAddressInformation> collection = new Collection<GatewayIPAddressInformation>();
            // Columns are as follows (first-line header):
            // Iface  Destination  Gateway  Flags  RefCnt  Use  Metric  Mask  MTU  Window  IRTT
            string[] fileLines = File.ReadAllLines(filePath);
            foreach (string line in fileLines)
            {
                if (line.StartsWith(interfaceName))
                {
                    StringParser parser = new StringParser(line, '\t', skipEmpty: true);
                    parser.MoveNext();
                    parser.MoveNextOrFail();
                    string gatewayIPHex = parser.MoveAndExtractNext();
                    long addressValue = Convert.ToInt64(gatewayIPHex, 16);
                    IPAddress address = new IPAddress(addressValue);
                    collection.Add(new SimpleGatewayIPAddressInformation(address));
                }
            }

            return collection;
        }

        internal static Collection<IPAddress> ParseDhcpServerAddressesFromLeasesFile(string filePath, string name)
        {
            // Parse the /var/lib/dhcp/dhclient.leases file, if it exists.
            // If any errors occur, like the file not existing or being
            // improperly formatted, just bail and return an empty collection.
            Collection<IPAddress> collection = new Collection<IPAddress>();
            try
            {
                string fileContents = File.ReadAllText(filePath);
                int leaseIndex = -1;
                int secondBrace = -1;
                while ((leaseIndex = fileContents.IndexOf("lease", leaseIndex + 1)) != -1)
                {
                    int firstBrace = fileContents.IndexOf("{", leaseIndex);
                    secondBrace = fileContents.IndexOf("}", leaseIndex);
                    int blockLength = secondBrace - firstBrace;

                    int interfaceIndex = fileContents.IndexOf("interface", firstBrace, blockLength);
                    int afterName = fileContents.IndexOf(';', interfaceIndex);
                    int beforeName = fileContents.LastIndexOf(' ', afterName);
                    string interfaceName = fileContents.Substring(beforeName + 2, afterName - beforeName - 3);
                    if (interfaceName != name)
                    {
                        continue;
                    }

                    int indexOfDhcp = fileContents.IndexOf("dhcp-server-identifier", firstBrace, blockLength);
                    int afterAddress = fileContents.IndexOf(";", indexOfDhcp);
                    int beforeAddress = fileContents.LastIndexOf(' ', afterAddress);
                    string dhcpAddressString = fileContents.Substring(beforeAddress + 1, afterAddress - beforeAddress - 1);
                    IPAddress dhcpAddress;
                    if (IPAddress.TryParse(dhcpAddressString, out dhcpAddress))
                    {
                        collection.Add(dhcpAddress);
                    }
                }
            }
            catch
            {
                // If any parsing or file reading exception occurs, just ignore it and return the collection.
            }

            return collection;
        }

        internal static Collection<IPAddress> ParseWinsServerAddressesFromSmbConfFile(string smbConfFilePath)
        {
            Collection<IPAddress> collection = new Collection<IPAddress>();
            try
            {
                string fileContents = File.ReadAllText(smbConfFilePath);
                string label = "wins server = ";
                int labelIndex = fileContents.IndexOf(label);
                int labelLineStart = fileContents.LastIndexOf(Environment.NewLine, labelIndex);
                if (labelLineStart < labelIndex)
                {
                    int commentIndex = fileContents.IndexOf(';', labelLineStart, labelIndex - labelLineStart);
                    if (commentIndex != -1)
                    {
                        return collection;
                    }
                }
                int endOfLine = fileContents.IndexOf(Environment.NewLine, labelIndex);
                string addressString = fileContents.Substring(labelIndex + label.Length, endOfLine - (labelIndex + label.Length));
                IPAddress address = IPAddress.Parse(addressString);
                collection.Add(address);
            }
            catch
            {
                // If any parsing or file reading exception occurs, just ignore it and return the collection.
            }

            return collection;
        }

        internal static TcpConnectionInformation[] ParseActiveTcpConnectionsFromFiles(string tcp4ConnectionsFile, string tcp6ConnectionsFile)
        {
            string tcp4FileContents = File.ReadAllText(tcp4ConnectionsFile);
            string[] v4connections = tcp4FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string tcp6FileContents = File.ReadAllText(tcp6ConnectionsFile);
            string[] v6connections = tcp6FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            TcpConnectionInformation[] connections = new TcpConnectionInformation[v4connections.Length + v6connections.Length - 2]; // First line is header in each file
            int index = 0;

            // TCP Connections
            for (int i = 1; i < v4connections.Length; i++) // Skip first line header
            {
                string line = v4connections[i];
                connections[index++] = ParseTcpConnectionInformationFromLine(line);
            }

            // TCP6 Connections
            for (int i = 1; i < v6connections.Length; i++) // Skip first line header
            {
                string line = v6connections[i];
                connections[index++] = ParseTcpConnectionInformationFromLine(line);
            }

            return connections;
        }

        internal static IPEndPoint[] ParseActiveTcpListenersFromFiles(string tcp4ConnectionsFile, string tcpConnections6File)
        {
            string tcp4FileContents = File.ReadAllText(tcp4ConnectionsFile);
            string[] v4connections = tcp4FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string tcp6FileContents = File.ReadAllText(tcpConnections6File);
            string[] v6connections = tcp6FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

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

        public static IPEndPoint[] ParseActiveUdpListenersFromFiles(string udp4File, string udp6File)
        {
            string udp4FileContents = File.ReadAllText(udp4File);
            string[] v4connections = udp4FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

            string udp6FileContents = File.ReadAllText(udp6File);
            string[] v6connections = udp6FileContents.Split(s_newLineSeparator, StringSplitOptions.RemoveEmptyEntries);

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

        // Parsing logic for local and remote addresses and ports, as well as socket state.
        internal static TcpConnectionInformation ParseTcpConnectionInformationFromLine(string line)
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
            TcpState tcpState = MapTcpState((Interop.LinuxTcpState)state);

            IPEndPoint localEndPoint = new IPEndPoint(localAddress, localPort);
            IPEndPoint remoteEndPoint = new IPEndPoint(remoteAddress, remotePort);

            return new SimpleTcpConnectionInformation(localEndPoint, remoteEndPoint, tcpState);
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

        // Maps from Linux TCP states (include/net/tcp_states.h) to .NET TcpStates
        // TODO: Move this to the native shim.
        private static TcpState MapTcpState(Interop.LinuxTcpState state)
        {
            switch (state)
            {
                case Interop.LinuxTcpState.TCP_ESTABLISHED:
                    return TcpState.Established;
                case Interop.LinuxTcpState.TCP_SYN_SENT:
                    return TcpState.SynSent;
                case Interop.LinuxTcpState.TCP_SYN_RECV:
                    return TcpState.SynReceived;
                case Interop.LinuxTcpState.TCP_FIN_WAIT1:
                    return TcpState.FinWait1;
                case Interop.LinuxTcpState.TCP_FIN_WAIT2:
                    return TcpState.FinWait2;
                case Interop.LinuxTcpState.TCP_TIME_WAIT:
                    return TcpState.TimeWait;
                case Interop.LinuxTcpState.TCP_CLOSE:
                    return TcpState.Closing;
                case Interop.LinuxTcpState.TCP_CLOSE_WAIT:
                    return TcpState.CloseWait;
                case Interop.LinuxTcpState.TCP_LAST_ACK:
                    return TcpState.LastAck;
                case Interop.LinuxTcpState.TCP_LISTEN:
                    return TcpState.Listen;
                case Interop.LinuxTcpState.TCP_CLOSING:
                    return TcpState.Closing;
                case Interop.LinuxTcpState.TCP_NEW_SYN_RECV:
                    return TcpState.Unknown;
                case Interop.LinuxTcpState.TCP_MAX_STATES:
                    return TcpState.Unknown;
                default:
                    throw new InvalidOperationException("Invalid LinuxTcpState: " + state);
            }
        }

        private static IPAddress ParseHexIPAddress(string remoteAddressString)
        {
            if (remoteAddressString.Length <= 8) // IPv4 Address
            {
                return ParseIPv4HexString(remoteAddressString);
            }
            else if (remoteAddressString.Length == 32) // IPv6 Address
            {
                return ParseIPv6HexString(remoteAddressString);
            }
            else
            {
                throw new NetworkInformationException();
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
                throw new NetworkInformationException();
            }
            ipAddress = new IPAddress(addressValue);
            return ipAddress;
        }

        // Parses a 128-bit IPv6 Address stored as a 32-character hex number.
        // Strings passed to this must be 32 characters in length.
        private static IPAddress ParseIPv6HexString(string hexAddress)
        {
            Debug.Assert(hexAddress.Length == 32);
            byte[] addressBytes = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                addressBytes[i] = (byte)(HexToByte(hexAddress[(i * 2)])
                                    + HexToByte(hexAddress[(i * 2) + 1]));
            }

            IPAddress ipAddress = new IPAddress(addressBytes);
            return ipAddress;
        }

        private static byte HexToByte(char val)
        {
            if (val <= '9' && val >= '0')
                return (byte)(val - '0');
            else if (val >= 'a' && val <= 'f')
                return (byte)((val - 'a') + 10);
            else if (val >= 'A' && val <= 'F')
                return (byte)((val - 'A') + 10);
            else
                throw new InvalidOperationException("Invalid hex character.");
        }

        internal static int ParseRawIntFile(string filePath)
        {
            int ret;
            if (!int.TryParse(File.ReadAllText(filePath), out ret))
            {
                throw new NetworkInformationException();
            }

            return ret;
        }

        internal static long ParseRawLongFile(string filePath)
        {
            long ret;
            if (!long.TryParse(File.ReadAllText(filePath), out ret))
            {
                throw new NetworkInformationException();
            }

            return ret;
        }

        internal static int ParseRawHexFileAsInt(string filePath)
        {
            return Convert.ToInt32(File.ReadAllText(filePath), 16);
        }

        private static int CountOccurences(string value, string candidate)
        {
            Debug.Assert(candidate != null, "CountOcurrences: Candidate string was null.");
            int index = 0;
            int occurrences = 0;
            while (index != -1)
            {
                index = candidate.IndexOf(value, index + 1);
                if (index != -1)
                {
                    occurrences++;
                }
            }

            return occurrences;
        }
    }
}

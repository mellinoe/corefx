// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Xunit;

namespace System.Net.NetworkInformation.Tests
{
    public class StatisticsParsingTests
    {
        [Fact]
        public static void TestIcmpv4Parsing()
        {
            Icmpv4StatisticsTable table = StringParsingHelpers.ParseIcmpv4FromSnmpFile("snmp_example.txt");
            Assert.Equal(1, table.InMsgs);
            Assert.Equal(2, table.InErrors);
            Assert.Equal(3, table.InCsumErrors);
            Assert.Equal(4, table.InDestUnreachs);
            Assert.Equal(5, table.InTimeExcds);
            Assert.Equal(6, table.InParmProbs);
            Assert.Equal(7, table.InSrcQuenchs);
            Assert.Equal(8, table.InRedirects);
            Assert.Equal(9, table.InEchos);
            Assert.Equal(10, table.InEchoReps);
            Assert.Equal(20, table.InTimestamps);
            Assert.Equal(30, table.InTimeStampReps);
            Assert.Equal(40, table.InAddrMasks);
            Assert.Equal(50, table.InAddrMaskReps);
            Assert.Equal(60, table.OutMsgs);
            Assert.Equal(70, table.OutErrors);
            Assert.Equal(80, table.OutDestUnreachs);
            Assert.Equal(90, table.OutTimeExcds);
            Assert.Equal(100, table.OutParmProbs);
            Assert.Equal(255, table.OutSrcQuenchs);
            Assert.Equal(1024, table.OutRedirects);
            Assert.Equal(256, table.OutEchos);
            Assert.Equal(9001, table.OutEchoReps);
            Assert.Equal(42, table.OutTimestamps);
            Assert.Equal(4100414, table.OutTimestampReps);
            Assert.Equal(2147483647, table.OutAddrMasks);
            Assert.Equal(0, table.OutAddrMaskReps);
        }

        [Fact]
        public static void TestIcmpv6Parsing()
        {
            Icmpv6StatisticsTable table = StringParsingHelpers.ParseIcmpv6FromSnmp6File("snmp6_example.txt");
            Assert.Equal(1, table.InMsgs);
            Assert.Equal(2, table.InErrors);
            Assert.Equal(3, table.OutMsgs);
            Assert.Equal(4, table.OutErrors);
            Assert.Equal(6, table.InDestUnreachs);
            Assert.Equal(7, table.InPktTooBigs);
            Assert.Equal(8, table.InTimeExcds);
            Assert.Equal(9, table.InParmProblems);
            Assert.Equal(10, table.InEchos);
            Assert.Equal(11, table.InEchoReplies);
            Assert.Equal(12, table.InGroupMembQueries);
            Assert.Equal(13, table.InGroupMembResponses);
            Assert.Equal(14, table.InGroupMembReductions);
            Assert.Equal(15, table.InRouterSolicits);
            Assert.Equal(16, table.InRouterAdvertisements);
            Assert.Equal(17, table.InNeighborSolicits);
            Assert.Equal(18, table.InNeighborAdvertisements);
            Assert.Equal(19, table.InRedirects);
            Assert.Equal(21, table.OutDestUnreachs);
            Assert.Equal(22, table.OutPktTooBigs);
            Assert.Equal(23, table.OutTimeExcds);
            Assert.Equal(24, table.OutParmProblems);
            Assert.Equal(25, table.OutEchos);
            Assert.Equal(26, table.OutEchoReplies);
            Assert.Equal(27, table.OutInGroupMembQueries);
            Assert.Equal(28, table.OutGroupMembResponses);
            Assert.Equal(29, table.OutGroupMembReductions);
            Assert.Equal(30, table.OutRouterSolicits);
            Assert.Equal(31, table.OutRouterAdvertisements);
            Assert.Equal(32, table.OutNeighborSolicits);
            Assert.Equal(33, table.OutNeighborAdvertisements);
            Assert.Equal(34, table.OutRedirects);
        }
    }
}

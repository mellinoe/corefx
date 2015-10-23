using Xunit;

namespace System.Net.NetworkInformation.Tests
{
    public class StringParsingTests
    {
        [Fact]
        public static void TestIcmpv4Parsing()
        {
            Icmpv4StatisticsTable table = LinuxStringParsingHelpers.ParseIcmpv4FromSnmpFile("snmp_example.txt");
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
            Assert.Equal(25555555, table.OutAddrMasks);
            Assert.Equal(0, table.OutAddrMaskReps);
        }
    }
}

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;

namespace System.Net.NetworkInformation
{
    internal struct Icmpv4StatisticsTable
    {
        public readonly int InMsgs;
        public readonly int InErrors;
        public readonly int InCsumErrors;
        public readonly int InDestUnreachs;
        public readonly int InTimeExcds;
        public readonly int InParmProbs;
        public readonly int InSrcQuenchs;
        public readonly int InRedirects;
        public readonly int InEchos;
        public readonly int InEchoReps;
        public readonly int InTimestamps;
        public readonly int InTimeStampReps;
        public readonly int InAddrMasks;
        public readonly int InAddrMaskReps;
        public readonly int OutMsgs;
        public readonly int OutErrors;
        public readonly int OutDestUnreachs;
        public readonly int OutTimeExcds;
        public readonly int OutParmProbs;
        public readonly int OutSrcQuenchs;
        public readonly int OutRedirects;
        public readonly int OutEchos;
        public readonly int OutEchoReps;
        public readonly int OutTimestamps;
        public readonly int OutTimestampReps;
        public readonly int OutAddrMasks;
        public readonly int OutAddrMaskReps;

        public Icmpv4StatisticsTable(int inMsgs, int inErrors, int inCsumErrors, int inDestUnreachs, int inTimeExcds, int inParmProbs,
                                        int inSrcQuenchs, int inRedirects, int inEchos, int inEchoReps, int inTimestamps, int inTimeStampReps,
                                        int inAddrMasks, int inAddrMaskReps, int outMsgs, int outErrors, int outDestUnreachs, int outTimeExcds,
                                        int outParmProbs, int outSrcQuenchs, int outRedirects, int outEchos, int outEchoReps, int outTimestamps,
                                        int outTimestampReps, int outAddrMasks, int outAddrMaskReps)
        {
            InMsgs = inMsgs;
            InErrors = inErrors;
            InCsumErrors = inCsumErrors;
            InDestUnreachs = inDestUnreachs;
            InTimeExcds = inTimeExcds;
            InParmProbs = inParmProbs;
            InSrcQuenchs = inSrcQuenchs;
            InRedirects = inRedirects;
            InEchos = inEchos;
            InEchoReps = inEchoReps;
            InTimestamps = inTimestamps;
            InTimeStampReps = inTimeStampReps;
            InAddrMasks = inAddrMasks;
            InAddrMaskReps = inAddrMaskReps;
            OutMsgs = outMsgs;
            OutErrors = outErrors;
            OutDestUnreachs = outDestUnreachs;
            OutTimeExcds = outTimeExcds;
            OutParmProbs = outParmProbs;
            OutSrcQuenchs = outSrcQuenchs;
            OutRedirects = outRedirects;
            OutEchos = outEchos;
            OutEchoReps = outEchoReps;
            OutTimestamps = outTimestamps;
            OutTimestampReps = outTimestampReps;
            OutAddrMasks = outAddrMasks;
            OutAddrMaskReps = outAddrMaskReps;
        }
    }

    internal static class LinuxStringParsingHelpers
    {
        // Parses ICMP v4 statistics from /proc/net/snmp
        public static Icmpv4StatisticsTable ParseFromSnmpFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new NetworkInformationException();
            }

            string fileContents = File.ReadAllText(filePath);
            int firstIpHeader = fileContents.IndexOf("Icmp:");
            int secondIpHeader = fileContents.IndexOf("Icmp:", firstIpHeader + 1);
            int endOfSecondLine = fileContents.IndexOf(Environment.NewLine, secondIpHeader);
            string icmpData = fileContents.Substring(secondIpHeader, endOfSecondLine - secondIpHeader);
            StringParser parser = new StringParser(icmpData, ' ');

            // NOTE: Need to verify that this order is consistent. Otherwise, we need to parse the first-line header
            // to determine the order of information contained in the file.

            parser.MoveNextOrFail(); // Skip Icmp:

            return new Icmpv4StatisticsTable(
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32(),
                parser.ParseNextInt32());
        }
    }
}

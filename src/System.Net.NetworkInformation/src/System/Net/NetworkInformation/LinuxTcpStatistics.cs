﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace System.Net.NetworkInformation
{
    internal class LinuxTcpStatistics : TcpStatistics
    {
        private readonly TcpGlobalStatisticsTable _table;
        private readonly int _currentConnections;

        public LinuxTcpStatistics(bool ipv4)
        {
            string snmpFile = ipv4 ? NetworkFiles.SnmpV4StatsFile : NetworkFiles.SnmpV6StatsFile;
            _table = LinuxStringParsingHelpers.ParseTcpGlobalStatisticsFromSnmpFile(snmpFile);

            string sockstatFile = ipv4 ? NetworkFiles.SockstatFile : NetworkFiles.Sockstat6File;
            string protoName = ipv4 ? "TCP" : "TCP6";
            _currentConnections = LinuxStringParsingHelpers.ParseNumSocketConnections(sockstatFile, protoName);
        }

        public override long ConnectionsAccepted { get { throw new PlatformNotSupportedException(); } }
        public override long ConnectionsInitiated { get { throw new PlatformNotSupportedException(); } }
        public override long CumulativeConnections { get { throw new PlatformNotSupportedException(); } }
        public override long CurrentConnections { get { return _currentConnections; } }
        public override long ErrorsReceived { get { return _table.InErrs; } }
        public override long FailedConnectionAttempts { get { return _table.AttemptFails; } }
        public override long MaximumConnections { get { return _table.MaxConn; } }
        public override long MaximumTransmissionTimeout { get { throw new PlatformNotSupportedException(); } }
        public override long MinimumTransmissionTimeout { get { throw new PlatformNotSupportedException(); } }
        public override long ResetConnections { get { return _table.EstabResets; } }
        public override long ResetsSent { get { throw new PlatformNotSupportedException(); } }
        public override long SegmentsReceived { get { return _table.InSegs; } }
        public override long SegmentsResent { get { return _table.RetransSegs; } }
        public override long SegmentsSent { get { return _table.OutSegs; } }
    }
}

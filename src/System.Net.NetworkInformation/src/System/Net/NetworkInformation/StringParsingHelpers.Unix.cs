﻿using System.Collections.ObjectModel;
using System.IO;

namespace System.Net.NetworkInformation
{
    internal static class UnixStringParsingHelpers
    {
        internal static string ParseDnsSuffixFromResolvConfFile(string filePath)
        {
            string data = File.ReadAllText(filePath);
            RowConfigReader rcr = new RowConfigReader(data);
            string dnsSuffix;

            return rcr.TryGetNextValue("search", out dnsSuffix) ? dnsSuffix : string.Empty;
        }

        internal static Collection<IPAddress> ParseDnsAddressesFromResolvConfFile(string filepath)
        {
            // Parse /etc/resolv.conf for all of the "nameserver" entries.
            // These are the DNS servers the machine is configured to use.
            // On OSX, this file is not directly used by most processes for DNS
            // queries/routing, but it is automatically generated instead, with
            // the machine's DNS servers listed in it.
            string data = File.ReadAllText(NetworkFiles.EtcResolvConfFile);
            RowConfigReader rcr = new RowConfigReader(data);
            Collection<IPAddress> addresses = new Collection<IPAddress>();

            string addressString = null;
            while (rcr.TryGetNextValue("nameserver", out addressString))
            {
                IPAddress parsedAddress;
                if (IPAddress.TryParse(addressString, out parsedAddress))
                {
                    addresses.Add(parsedAddress);
                }
            }

            return addresses;
        }
    }
}

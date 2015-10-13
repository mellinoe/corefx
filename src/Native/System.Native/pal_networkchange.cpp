// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wcast-align"

#include "pal_config.h"

#if HAVE_LINUX_NETLINK_H

#include "pal_networkchange.h"

#include <assert.h>
#include <asm/types.h>
#include <sys/socket.h>
#include <unistd.h>
#include <errno.h>
#include <stdio.h>
#include <string.h>
#include <net/if.h>
#include <netinet/in.h>
#include <linux/netlink.h>
#include <linux/rtnetlink.h>
#include <stdlib.h>
#include <sys/time.h>
#include <sys/types.h>

extern "C" int32_t RegisterNetworkChangeCallback(NetworkInterfaceChangeEvent changeEvent)
{
    struct sockaddr_nl sanl;
    int sock;
    ssize_t len;
    uint8_t buffer[4096];
    nlmsghdr* nlh;

    memset(&sanl, 0, sizeof(sanl));
    sanl.nl_family = AF_NETLINK;
    sanl.nl_groups = RTMGRP_LINK | RTMGRP_IPV4_IFADDR;

    if ((sock = socket(AF_NETLINK, SOCK_RAW, NETLINK_ROUTE)) == -1)
    {
        perror("Error opening netlink socket.");
        return -1;
    }
    if (bind(sock, reinterpret_cast<sockaddr*>(&sanl), sizeof(sanl)) == -1)
    {
        perror("Error binding netlink socket.");
        return -1;
    }

    nlh = reinterpret_cast<nlmsghdr*>(buffer);
    while ((len = recv(sock, nlh, 4096, 0)) > 0)
    {
        while ((NLMSG_OK(nlh, len)) && (nlh->nlmsg_type != NLMSG_DONE))
        {
            switch (nlh->nlmsg_type)
            {
                case RTM_NEWADDR:
                case RTM_DELADDR:
                {
                    ifaddrmsg *ifa = reinterpret_cast<ifaddrmsg*>(NLMSG_DATA(nlh));
                    rtattr* rth = IFA_RTA(ifa);
                    uint64_t rtl = IFA_PAYLOAD(nlh);

                    printf(">>>>RTM_NEWADDR or RTM_DELADDR\n");
                    while (rtl && RTA_OK(rth, rtl))
                    {
                        printf("*** RTM_NEWADDR or RTM_DELADDR event, rta_type=%d ***\n", rth->rta_type);
                        if (rth->rta_type == IFA_LOCAL)
                        {
                            uint32_t ipaddr = htonl(*(reinterpret_cast<uint32_t*>(RTA_DATA(rth))));
                            char name[IFNAMSIZ];
                            if_indextoname(ifa->ifa_index, name);
                            printf("%s has new or deleted address: %d.%d.%d.%d\n",
                                name,
                                (ipaddr >> 24) & 0xff,
                                (ipaddr >> 16) & 0xff,
                                (ipaddr >> 8) & 0xff,
                                ipaddr & 0xff);
                            NetworkInterfaceChangeInfo nici;
                            nici.EventType = (nlh->nlmsg_type == RTM_NEWADDR)
                                ? AddressAdded
                                : AddressDeleted;
                            changeEvent(&nici);
                        }

                        rth = RTA_NEXT(rth, rtl);
                    }

                    break;
                }
                case RTM_NEWLINK:
                case RTM_DELLINK:
                {
                    ifaddrmsg *ifa = reinterpret_cast<ifaddrmsg*>(NLMSG_DATA(nlh));
                    rtattr* rth = IFA_RTA(ifa);
                    uint64_t rtl = IFA_PAYLOAD(nlh);
                    printf(">>>>RTM_NEWLINK or RTM_DELLINK\n");
                    while (rtl != 0 && RTA_OK(rth, rtl))
                    {
                        printf("*** RTM_NEWLINK or RTM_DELLINK event, rta_type=%d ***\n", rth->rta_type);
                        if (rth->rta_type == IFLA_IFNAME)
                        {
                            printf("Got an IFLA_IFName event.\n");
                            NetworkInterfaceChangeInfo nici;
                            nici.EventType = (nlh->nlmsg_type == RTM_NEWLINK)
                                ? LinkAdded
                                : LinkDeleted;
                            changeEvent(&nici);
                        }

                        rth = RTA_NEXT(rth, rtl);
                    }

                    break;
                }
                default:
                {
                    printf("Received a message of type %u, not proessing.\n", nlh->nlmsg_type);
                    break;
                }
            }
            nlh = NLMSG_NEXT(nlh, len);
        }
        printf("^___Waiting for next socket event___^\n");
    }
    printf("Exited socket loop, len=%zd\n", len);
    close(sock);
    return -1;
}

extern "C" void CreateNetlinkSockaddr(
    uint8_t* addressBuffer,
    int32_t* bufferLength,
    int32_t* addressFamily,
    int32_t* protocolFamily)
{
    assert(addressBuffer != nullptr && bufferLength != nullptr
            && addressFamily != nullptr && protocolFamily != nullptr);

    *reinterpret_cast<sockaddr_nl*>(addressBuffer) =
    {
        .nl_family = AF_NETLINK,
        .nl_groups = RTMGRP_LINK | RTMGRP_IPV4_IFADDR
    };

    *bufferLength = sizeof(sockaddr_nl);
    *addressFamily = AF_NETLINK;
    *protocolFamily = NETLINK_ROUTE;
}

#endif // HAVE_LINUX_NETLINK_H

#pragma clang diagnostic pop

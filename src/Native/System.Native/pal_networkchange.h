// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#include "pal_types.h"

enum NetworkInterfaceChangeEventType : uint32_t
{
    None = 0,
    LinkAdded,
    LinkDeleted,
    AddressAdded,
    AddressDeleted,
};

struct NetworkInterfaceChangeInfo
{
    NetworkInterfaceChangeEventType EventType;
};

typedef void (*NetworkInterfaceChangeEvent)(NetworkInterfaceChangeInfo* changeInfo);

extern "C" int32_t RegisterNetworkChangeCallback(NetworkInterfaceChangeEvent event);

extern "C" void CreateNetlinkSockaddr(
    uint8_t* addressBuffer,
    int32_t* bufferLength,
    int32_t* addressFamily,
    int32_t* protocolFamily);

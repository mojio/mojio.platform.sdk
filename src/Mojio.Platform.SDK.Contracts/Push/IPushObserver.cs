#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Push
{
    public enum ObserverEntity
    {
        Vehicles,
        Users,
        Mojios,
        Activities
    }

    public enum TransportTypes
    {
        Android,
        Apple,
        HttpPost,
        Mqtt,
        SignalR,
        MongoDB,
        Websocket,
        EventHub,
        ServiceBusQueue
    }

    [Flags]
    public enum Timings
    {
        High = 1 << 0,
        Leading = 1 << 1,
        Trailing = 1 << 2,

        Edge = Leading | Trailing,
        Change = Edge,
        Enter = Leading,
        Exit = Trailing
    }

    public interface IPushObserver
    {
        string Key { get; set; }

        IList<ITransport> Transports { get; set; }

        IList<string> Fields { get; set; }

        string Conditions { get; set; }

        int? Debounce { get; set; }

        Timings? Timing { get; set; }

        TimeSpan? Throttle { get; set; }

        TimeSpan? TimeToLive { get; set; }
    }
}
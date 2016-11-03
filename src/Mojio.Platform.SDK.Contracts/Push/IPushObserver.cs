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

        IList<ITransport> Transport { get; set; }

        IList<string> Fields { get; set; }

        IList<string> Conditions { get; set; }

        int? Debounce { get; set; }

        Timings? Timing { get; set; }

        TimeSpan? Throttle { get; set; }

        TimeSpan? TimeToLive { get; set; }
    }
}
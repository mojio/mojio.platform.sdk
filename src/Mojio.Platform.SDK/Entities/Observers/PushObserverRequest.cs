using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class PushObserverRequest : IPushObserver
    {
        public PushObserverRequest()
        {
            Key = Guid.NewGuid().ToString();
            Transports = new List<ITransport>();
        }
        public string Key { get; set; }
        public IList<ITransport> Transports { get; set; }
        public IList<string> Fields { get; set; }
        public string Conditions { get; set; }
        public int? Debounce { get; set; }
        public Timings? Timing { get; set; }
        public TimeSpan? Throttle { get; set; }
        public TimeSpan? TimeToLive { get; set; }
    }
}

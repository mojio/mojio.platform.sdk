using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK
{
    public class EventTimingRecorderFactory : IEventTimingFactory
    {
        public IDisposable EventTimer(ILog log, string category, string method)
        {
            return new EventTimingRecorder(log, category, method);
        }
    }
}

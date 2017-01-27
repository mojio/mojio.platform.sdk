using System;

namespace Mojio.Platform.SDK.Contracts.Instrumentation
{
    public interface IEventTimingFactory
    {
        IDisposable EventTimer(ILog log, string category, string method);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK
{
    internal class EventTimingRecorder : IDisposable
    {
        private readonly ILog _log;
        private readonly string _category;
        private readonly string _method;
        private readonly long _startTime;

        public EventTimingRecorder(ILog log, string category, string method)
        {
            _log = log;
            _category = category;
            _method = method;
            _startTime = Stopwatch.GetTimestamp();

        }
        public void Dispose()
        {
            var endTime = Stopwatch.GetTimestamp();
            var delta = endTime - _startTime;
            var elapsedMs = delta * 1000 / Stopwatch.Frequency;
            _log.Event("Timing", new Dictionary<string, string>() { { "category", _category}, {"method", _method}}, new Dictionary<string, double>() { {"Duration", elapsedMs } });
        
        }
    }
}

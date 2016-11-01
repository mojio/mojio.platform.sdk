using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;

namespace Mojio.Platform.SDK.CLI
{
    public class LoggingObserver<T> : IObserver<T>

    {
        private readonly ILog _log;

        public LoggingObserver(ILog log)
        {
            _log = log;
        }

        public void OnCompleted()
        {
            _log.Info($"Observer completed:{this.GetHashCode()}");
        }

        public void OnError(Exception error)
        {
            _log.Error(error, $"Observer completed:{this.GetHashCode()}");
        }

        public void OnNext(T value)
        {
            _log.Debug(new { value, message = $"Observer completed:{this.GetHashCode()}" });
        }
    }
}
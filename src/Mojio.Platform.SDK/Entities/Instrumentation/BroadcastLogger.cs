using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio.Platform.SDK.Entities.Instrumentation
{
    public class BroadcastLogger : ILog
    {
        private readonly IEnumerable<ILog> _loggers;
        private readonly bool enabled;

        public BroadcastLogger(IList<ILog> ll)
        {
            //var loggers = container.ResolveAllInstances<ILog>();
            _loggers = from l in ll where l.GetType() != typeof(BroadcastLogger) select l;
            enabled = _loggers.Count() > 0;
        }

        public void Info(string message, params object[] args)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Info(message, args);
            }
        }

        public void Debug(object obj)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Debug(obj);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Debug(message, args);
            }
        }

        public void Error(Exception e, string message = null, params object[] args)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Error(e, message, args);
            }
        }

        public void Fatal(Exception e, string message = null, params object[] args)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Fatal(e, message, args);
            }
        }

        public void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            if (!enabled) return;
            foreach (var l in _loggers)
            {
                l.Event(message, properties, metrics);
            }
        }
    }
}
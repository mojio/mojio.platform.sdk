using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Mojio.Platform.SDK.Entities.Instrumentation
{
    public class BroadcastLogger : ILog
    {
        private static ImmutableArray<ILog> _loggers;
        private readonly bool _enabled = false;

        public BroadcastLogger(IList<ILog> ll)
        {
            var d = new List<ILog>();
            foreach (var l in ll)
            {
                if (!(l is BroadcastLogger))
                {
                    d.Add(l);
                }
            }
            _loggers = d.ToImmutableArray();

            _enabled = _loggers.Any();
        }

        public void Info(string message, params object[] args)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Info(message, args);
            }
        }

        public void Debug(object obj)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Debug(obj);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Debug(message, args);
            }
        }

        public void Error(Exception e, string message = null, params object[] args)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Error(e, message, args);
            }
        }

        public void Fatal(Exception e, string message = null, params object[] args)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Fatal(e, message, args);
            }
        }

        public void Event(string message, IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null)
        {
            if (!_enabled) return;
            foreach (var l in _loggers)
            {
                l.Event(message, properties, metrics);
            }
        }
    }
}
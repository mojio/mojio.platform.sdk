using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Entities.Instrumentation
{
    public class BroadcastLogger : ILog
    {
        private static ConcurrentQueue<Tuple<string, IDictionary<string, string>, IDictionary<string, double>>>
            _eventQueue = new ConcurrentQueue<Tuple<string, IDictionary<string, string>, IDictionary<string, double>>>();

        private static ImmutableArray<ILog> _loggers;
        private readonly bool _enabled = false;

        static BroadcastLogger()
        {
            Task.Factory.StartNew(() => { WaitLoop(); }, TaskCreationOptions.LongRunning);
        }

        private static SemaphoreSlim _lock = new SemaphoreSlim(1);

        private static async Task WaitLoop()
        {
            while (true)
            {
                try
                {
                    await _lock.WaitAsync();
                    var list = _eventQueue.ToArray();
                    _eventQueue =
                        new ConcurrentQueue<Tuple<string, IDictionary<string, string>, IDictionary<string, double>>>();

                    foreach (var e in list)
                    {
                        foreach (var l in _loggers)
                        {
                            l.Event(e.Item1, e.Item2, e.Item3);
                        }
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    _lock.Release();
                }

                await Task.Delay(500);
            }
        }

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
            _eventQueue.Enqueue(new Tuple<string, IDictionary<string, string>, IDictionary<string, double>>(message, properties, metrics));
        }
    }
}
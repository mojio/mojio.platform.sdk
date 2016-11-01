using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.SampleApp.Shared.Entities
{
    public class DebugLogger : ILog
    {
        private readonly ISerialize _serializer;

        public DebugLogger(ISerialize serializer)
        {
            _serializer = serializer;
        }

        public void Info(string message, params object[] args)
        {
            if (string.IsNullOrEmpty(message)) message = "{0}";
            System.Diagnostics.Debug.WriteLine("[INFO] " + message, args);
        }

        public void Debug(object obj)
        {
            string json = "null";
            if (obj != null) json = _serializer.SerializeToString(obj);

            System.Diagnostics.Debug.WriteLine("[DEBUG] " + json);
        }

        public void Debug(string message, params object[] args)
        {
            if (string.IsNullOrEmpty(message)) message = "{0}";
            System.Diagnostics.Debug.WriteLine("[DEBUG] " + message, args);
        }

        public void Error(Exception e, string message = null, params object[] args)
        {
            if (string.IsNullOrEmpty(message)) message = "{0}";
            System.Diagnostics.Debug.WriteLine("[ERROR] " + message, args);
            System.Diagnostics.Debug.WriteLine(_serializer.SerializeToString(e));
        }

        public void Fatal(Exception e, string message = null, params object[] args)
        {
            if (string.IsNullOrEmpty(message)) message = "{0}";
            System.Diagnostics.Debug.WriteLine("[FATAL] " + message, args);
            System.Diagnostics.Debug.WriteLine(_serializer.SerializeToString(e));
        }

        public void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            System.Diagnostics.Debug.WriteLine("[EVENT] " + message);
            if (properties != null && properties.Count > 0) System.Diagnostics.Debug.WriteLine(_serializer.SerializeToString(properties));
            if (metrics != null && metrics.Count > 0) System.Diagnostics.Debug.WriteLine(_serializer.SerializeToString(metrics));
        }
    }
}
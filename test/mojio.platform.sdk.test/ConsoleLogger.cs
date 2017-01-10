using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace mojio.platform.sdk.test
{
    public class ConsoleLogger : ILog
    {
        private readonly ISerialize _serializer;

        public ConsoleLogger(ISerialize serializer)
        {
            _serializer = serializer;
        }

        public void Info(string message, params object[] args)
        {
            Console.WriteLine("[INFO] " + message, args);
        }

        public void Debug(object obj)
        {
            var json = "null";
            if (obj != null) json = _serializer.SerializeToString(obj);

            Console.WriteLine("[DEBUG] " + json);
        }

        public void Debug(string message, params object[] args)
        {
            Console.WriteLine("[DEBUG] " + message, args);
        }

        public void Error(Exception e, string message = null, params object[] args)
        {
            Console.WriteLine("[ERROR] " + message ?? "", args);
            try
            {
                Console.WriteLine(_serializer.SerializeToString(e));
            }
            catch (Exception)
            {
            }
        }

        public void Fatal(Exception e, string message = null, params object[] args)
        {
            Console.WriteLine("[FATAL] " + message ?? "", args);
            Console.WriteLine(_serializer.SerializeToString(e));
        }

        public void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            Console.WriteLine("[EVENT] " + message);
            if (properties != null && properties.Count > 0) Console.WriteLine(_serializer.SerializeToString(properties));
            if (metrics != null && metrics.Count > 0) Console.WriteLine(_serializer.SerializeToString(metrics));
        }
    }
}
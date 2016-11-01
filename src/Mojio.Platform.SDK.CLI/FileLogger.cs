using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mojio.Platform.SDK.CLI
{
    public class FileLogger : ILog
    {
        private readonly ISerialize _serializer;
        public string Outfile = string.Empty;

        public FileLogger(ISerialize serializer)
        {
            _serializer = serializer;
        }

        public void Info(string message, params object[] args)
        {
            Emit("[INFO] " + message, args);
        }

        public void Debug(object obj)
        {
            var json = "null";
            if (obj != null) json = _serializer.SerializeToString(obj);

            Emit("[DEBUG] " + json);
        }

        public void Debug(string message, params object[] args)
        {
            Emit("[DEBUG] " + message, args);
        }

        public void Error(Exception e, string message = null, params object[] args)
        {
            Emit("[ERROR] " + message ?? "", args);
            try
            {
                Emit(_serializer.SerializeToString(e));
            }
            catch (Exception)
            {
            }
        }

        public void Fatal(Exception e, string message = null, params object[] args)
        {
            Emit("[FATAL] " + message ?? "", args);
            Emit(_serializer.SerializeToString(e));
        }

        public void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            Emit("[EVENT] " + message);
            if (properties != null && properties.Count > 0) Emit(_serializer.SerializeToString(properties));
            if (metrics != null && metrics.Count > 0) Emit(_serializer.SerializeToString(metrics));
        }

        private void Emit(string message, params object[] args)
        {
            if (!string.IsNullOrEmpty(Outfile))
            {
                if (args == null || args.Length <= 0)
                {
                    File.AppendAllText(Outfile, message);
                }
                else
                {
                    File.AppendAllText(Outfile, string.Format(message, args));
                }
            }
        }
    }
}
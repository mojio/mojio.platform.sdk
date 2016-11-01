using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Instrumentation
{
    public interface ILog
    {
        void Debug(object obj);

        void Debug(string message, params object[] args);

        void Info(string message, params object[] args);

        void Error(Exception e, string message = null, params object[] args);

        void Fatal(Exception e, string message = null, params object[] args);

        void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class GetTripsTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;

        public int Skip { get; set; } = 0;
        public int Top { get; set; } = 10;
        public string Filter { get; set; }
        public string Select { get; set; }
        public string OrderBy { get; set; }

        public GetTripsTask(ILog log, ISerializer serializer)
        {
            _log = log;
            _serializer = serializer;
            Key = "GetTrips";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(IClient client, IDictionary<string, string> properties)
        {
                var results = await client.Trips(Skip, Top, Filter, Select, OrderBy);
        }
    }
}
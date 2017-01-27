using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class GetCapabilitiesTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;

        public GetCapabilitiesTask(ILog log, ISerializer serializer)
        {
            _log = log;
            _serializer = serializer;
            Key = "GetCapabilities";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(IClient client, IDictionary<string, string> properties)
        {
            if (properties != null && properties.ContainsKey("Mojio_List"))
            {
                var listString = properties["Mojio_List"];
                if (!string.IsNullOrEmpty(listString))
                {
                    var list = from l in listString.Split(';') where !string.IsNullOrEmpty(l) select l;
                    foreach (var mojioId in list)
                    {
                        Guid mojioIdGuid;
                        if (Guid.TryParse(mojioId, out mojioIdGuid))
                        {
                            var results = await client.Capabilities(mojioIdGuid);
                        }
                    }
                }
            }
        }
    }
}
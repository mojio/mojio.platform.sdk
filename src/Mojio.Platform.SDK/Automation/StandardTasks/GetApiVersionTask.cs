using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class GetApiVersionTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;

        public GetApiVersionTask(ILog log, ISerializer serializer)
        {
            _log = log;
            _serializer = serializer;
            Key = "GetApiVersion";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(IClient client, IDictionary<string, string> properties)
        {
                var version = await client.GetServerStatus();
                properties.Add("version", _serializer.SerializeToString(version));
        }
    }
}
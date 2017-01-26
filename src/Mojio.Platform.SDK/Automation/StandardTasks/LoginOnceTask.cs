using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class LoginOnceTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;

        public LoginOnceTask(ILog log, ISerializer serializer)
        {
            _log = log;
            _serializer = serializer;
            Key = "LoginOnce";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(IClient client, IDictionary<string, string> properties)
        {

            if (!string.IsNullOrEmpty(client?.Authorization?.MojioApiToken)) return;

            if (properties != null && properties.ContainsKey("LoadTestProfile"))
            {
                LoadTestProfile = false;
            }

            if (!LoadTestProfile)
            {
                if (properties != null && properties.ContainsKey("username") && properties.ContainsKey("password"))
                {
                    var username = properties["username"];
                    var password = properties["password"];

                    var results = await client.Login(username, password);

                }
            }
            else
            {
                var username = $"loadtest{Rnd.Next(0, 20000)}";
                var password = "Password1";
                var results = await client.Login(username, password);
            }
        }
    }
}
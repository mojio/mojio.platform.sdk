using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class LoginAlwaysTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly IEventTimingFactory _timerFactory;

        public LoginAlwaysTask(ILog log, ISerializer serializer, IEventTimingFactory timerFactory)
        {
            _log = log;
            _serializer = serializer;
            _timerFactory = timerFactory;
            Key = "LoginAlways";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {
            using (_timerFactory.EventTimer(timingLogger, Key, "Execute"))
            {

                if (properties != null && properties.ContainsKey("LoadTestProfile"))
                {
                    LoadTestProfile = false;
                }

                if (!LoadTestProfile)
                {
                    if (properties != null && properties.ContainsKey("username") && properties.ContainsKey("password"))
                    {
                        var results = await client.Login(properties["username"], properties["password"]);
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
}
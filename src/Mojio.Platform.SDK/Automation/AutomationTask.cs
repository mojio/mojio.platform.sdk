using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation
{
    public class AutomationTask : IAutomationTask
    {
        public string Key { get; set; }
        public Task  Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {
            return Task.FromResult(false);
        }
    }
}

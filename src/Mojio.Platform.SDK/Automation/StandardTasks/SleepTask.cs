using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class SleepTask : BaseAutomationTask
    {
        public int Delay { get; set; } = 100;

        public override async Task Execute(IClient client, IDictionary<string, string> properties)
        {
            await Task.Delay(Delay);
        }
    }
}

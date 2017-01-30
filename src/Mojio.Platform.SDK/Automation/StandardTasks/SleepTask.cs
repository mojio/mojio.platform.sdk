using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class SleepTask : BaseAutomationTask
    {
        public SleepTask()
        {
            Key = "Sleep";
        }
        public int Delay { get; set; } = 100;

        public override async Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {
            await Task.Delay(Delay);
        }
    }
}

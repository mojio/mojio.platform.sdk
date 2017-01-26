using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation
{
    public class AutomationProfile : IAutomationProfile
    {
        private readonly ILog _log;
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public IList<IAutomationTask> Tasks { get; set; }
        public bool RunOnce { get; set; }
        public double DueTime { get; set; }
        public double Period { get; set; }

        public AutomationProfile(ILog log)
        {
            _log = log;
        }


        public async Task Execute(IClient client, IDictionary<string, string> properties)
        {
            if (this.Properties != null && properties != null)
            {
                foreach (var p in properties)
                {
                    if (!Properties.ContainsKey(p.Key)) Properties.Add(p.Key, p.Value);
                }
            }

            if (Tasks == null) return;

            foreach (var t in Tasks)
            {
                try
                {
                    await t.Execute(client, Properties);

                }
                catch (Exception e)
                {
                    _log.Fatal(e, t.Key);
                }
            }
        }
    }
}
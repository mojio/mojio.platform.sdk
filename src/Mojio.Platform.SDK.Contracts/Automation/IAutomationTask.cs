using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Contracts.Automation
{
    public interface IAutomationTask
    {
        string Key { get; set; }
        Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties);
    }
}

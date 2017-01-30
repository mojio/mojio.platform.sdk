using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Contracts.Automation
{
    public interface IAutomationProfile
    {
        IDictionary<string, string> Properties { get; set; }
        IList<IAutomationTask> Tasks { get; set; }
        bool RunOnce { get; set; }
        double DueTime { get; set; }
        double Period { get; set; }
        Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;

namespace Mojio.Platform.SDK.Contracts.Automation
{
    public interface IAutomationProfile
    {
        IList<IAutomationTask> Tasks { get; set; }

        bool RunOnce { get; set; }
        double DueTime { get; set; }
        double Period { get; set; }

        Task Execute(IClient client, IDictionary<string, string> properties);
    }
}
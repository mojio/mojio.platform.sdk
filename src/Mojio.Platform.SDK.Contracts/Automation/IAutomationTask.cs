using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;

namespace Mojio.Platform.SDK.Contracts.Automation
{
    public interface IAutomationTask
    {
        string Key { get; set; }
        Task Execute(IClient client, IDictionary<string, string> properties);
    }
}

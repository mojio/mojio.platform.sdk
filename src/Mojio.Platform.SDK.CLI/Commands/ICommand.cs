using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    public interface ICommand
    {
        string AuthorizationFile { get; set; }
        ILog Log { get; set; }
        string Out { get; set; }
        IClient SimpleClient { get; set; }

        Task Execute();
    }
}
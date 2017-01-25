using System;
using System.IO;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Entities.DI;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "status", Description = "Query the server for its status", Usage = "status")]
    public class ServerStatusCommand : BaseCommand
    {
        private readonly ISerialize _serialize;

        public ServerStatusCommand()
        {
            _serialize = DIContainer.Current.Resolve<ISerialize>();
        }
        public override async Task Execute()
        {
            var result = await SimpleClient.GetServerStatus();
            Log.Debug(result);

        }
    }
}
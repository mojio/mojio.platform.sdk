using System;
using System.IO;
using System.Threading.Tasks;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "ls", Description = "List out all .json files used for authentication", Usage = "ls")]
    public class LSCommand : BaseCommand
    {
        public override async Task Execute()
        {
            var files = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.json");
            foreach (var f in files)
            {
                Log.Debug((new FileInfo(f)).Name);
            }
            await TaskExtensions.CompletedTask;
        }
    }
}
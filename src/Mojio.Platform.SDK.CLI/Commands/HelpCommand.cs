using System.Threading.Tasks;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "help", Description = "This help", Usage = "help")]
    public class HelpCommand : BaseCommand
    {
        public override async Task Execute()
        {
            Log.Debug("\nMojio.Platform.SDK.CLI.exe command [args0...argsN]  Executes the command and exits immediately");
            Log.Debug("Mojio.Platform.SDK.CLI.exe filename  Executes the commands listed in the file, exists");
            Log.Debug("Mojio.Platform.SDK.CLI.exe starts the REPL");
            Log.Debug("");

            CommandFactory.DumpHelp();
            await TaskExtensions.CompletedTask;
        }
    }
}
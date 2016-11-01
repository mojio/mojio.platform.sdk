using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "show-client", Description = "Shows the current instance of the mojio client", Usage = "show-client")]
    public class ShowClientCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            Log.Debug(SimpleClient);

            UpdateAuthorization();
        }
    }
}
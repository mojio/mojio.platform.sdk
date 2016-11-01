using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "me", Description = "List the current user", Usage = "me")]
    public class MeCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.Me();
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}
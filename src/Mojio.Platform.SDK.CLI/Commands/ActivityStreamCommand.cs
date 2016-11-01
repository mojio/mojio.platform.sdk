using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-user-stream", Description = "List the current users activity stream", Usage = "get-user-stream")]
    public class ActivityStreamCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.UserActivityStream();
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}
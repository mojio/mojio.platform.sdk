using System;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-user", Description = "Gets the specified user", Usage = "get-user  /id:<user-id>")]
    public class GetUserCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();
            var g = Guid.Empty;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.GetUser(g);
                Log.Debug(result);
                UpdateAuthorization();
            }
            else
            {
                Log.Info("Invalid Id specified.");
            }
        }
    }
}

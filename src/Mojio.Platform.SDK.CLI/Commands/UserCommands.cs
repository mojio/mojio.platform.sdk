using System;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-user", Description = "Gets the specified user", Usage = "get-user  /i:<user-id>")]
    public class GetUserCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.GetUser(Id);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
    [CommandDescriptor(Name = "get-users", Description = "Gets the specified user", Usage = "get-users")]
    public class GetUsersCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Filter { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "se")]
        public string Select { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "order")]
        public string OrderBy { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.Users(Skip, Top, Filter, Select, OrderBy);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}

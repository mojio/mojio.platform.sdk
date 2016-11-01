using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Entities.DI;
using System.IO;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "auth", Description = "Load an authentication file", Usage = "auth /auth:<filename>")]
    public class AuthCommand : BaseCommand
    {
        private readonly ISerialize _serialize;

        public AuthCommand()
        {
            _serialize = DIContainer.Current.Resolve<ISerialize>();
        }

        public override async Task Execute()
        {
            await Authorize();

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "login", Description = "Login to Mojio", Usage = "login /u:username /p:password5")]
    public class LoginCommand : BaseCommand
    {
        private readonly ISerialize _serialize;

        public LoginCommand()
        {
            _serialize = DIContainer.Current.Resolve<ISerialize>();
        }

        [Argument(ArgumentType.Required, ShortName = "u")]
        public string Username { get; set; }

        [Argument(ArgumentType.Required, ShortName = "p")]
        public string Password { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            IPlatformResponse<IAuthorization> result = null;
            if (SimpleClient?.Authorization?.UserName == Username && SimpleClient?.Authorization?.Password == Password)
            {
                result = await SimpleClient.Login(SimpleClient.Authorization);
            }
            else
            {
                var auth = DIContainer.Current.Resolve<IAuthorization>();
                auth.UserName = Username;
                auth.Password = Password;
                result = await SimpleClient.Login(auth);
            }

            if (!string.IsNullOrEmpty(AuthorizationFile) && result.Success && !string.IsNullOrEmpty(result?.Response?.AccessToken))
            {
                File.WriteAllText(AuthorizationFile, _serialize.SerializeToString(result.Response));
                result.Response.Refreshed = false;
            }
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}
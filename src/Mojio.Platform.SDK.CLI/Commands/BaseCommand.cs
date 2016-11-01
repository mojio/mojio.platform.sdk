using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using System.IO;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private static IAuthorization _authorization;

        [Argument(ArgumentType.AtMostOnce, ShortName = "o", HelpText = "Output the result to a file")]
        public string Out { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "auth")]
        public string AuthorizationFile { get; set; }

        public ILog Log { get; set; }
        public IClient SimpleClient { get; set; }

        public abstract Task Execute();

        public void UpdateAuthorization()
        {
            if (SimpleClient?.Authorization?.Refreshed == true && !string.IsNullOrEmpty(AuthorizationFile) && File.Exists(AuthorizationFile))
            {
                if (File.Exists(AuthorizationFile)) File.Delete(AuthorizationFile);
                var serializer = DIContainer.Current.Resolve<ISerializer>();
                var json = serializer.SerializeToString(SimpleClient.Authorization);
                File.WriteAllText(AuthorizationFile, json);
                SimpleClient.Authorization.Refreshed = false;
            }
        }

        public async Task Authorize()
        {
            if (_authorization != null) return;

            if (!string.IsNullOrEmpty(AuthorizationFile) && File.Exists(AuthorizationFile))
            {
                var json = File.ReadAllText(AuthorizationFile);
                if (!string.IsNullOrEmpty(json))
                {
                    var deserializer = DIContainer.Current.Resolve<IDeserialize>();
                    _authorization = deserializer.Deserialize<IAuthorization>(json);
                    if (_authorization != null)
                    {
                        await SimpleClient.Login(_authorization);
                        _authorization.Refreshed = true;
                        UpdateAuthorization();
                    }
                }
            }
        }
    }
}
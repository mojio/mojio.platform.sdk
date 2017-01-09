using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.SimpleClient;

namespace Mojio.Platform.SDK.Tests
{
    public static class Mother
    {
        public static IDIContainer DIContainer => Mojio.Platform.SDK.Entities.DI.DIContainer.Current;

        public static string Username
        {
            get
            {
                var user = _configurationRoot["test_username"];
                if(string.IsNullOrEmpty(user)) user = "robc@moj.io";
                return user;
            }
        }

        public static string Password
        {
            get
            {
                var password = _configurationRoot["test_password"];
                if (string.IsNullOrEmpty(password)) password = "1080HoweVehicles";
                return password;                
            }   
        }

        private static IConfigurationRoot _configurationRoot;

        public static IClient SimpleClient
        {
            get
            {
                var env = Environments.Production;
                var configBuilder = new ConfigurationBuilder();
                //configBuilder.AddCommandLine(args);

                configBuilder.AddEnvironmentVariables();

                if (System.IO.File.Exists("appsettings.json"))
                {
                    configBuilder.AddJsonFile(path: "appsettings.json", optional: true);
                }

                _configurationRoot = configBuilder.Build();
                Entities.DI.DIContainer.Current.RegisterInstance<IConfigurationRoot>(_configurationRoot);

                var Environment = _configurationRoot["Environment"];
                if (!string.IsNullOrEmpty(Environment))
                {
                    Enum.TryParse(Environment, out env);
                }
                var ClientId = _configurationRoot["ClientId"];
                if (string.IsNullOrEmpty(ClientId)) ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052";
                var ClientSecret = _configurationRoot["ClientSecret"];
                if (string.IsNullOrEmpty(ClientSecret)) ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c";
                var RedirectUri = _configurationRoot["RedirectUri"];
                if (string.IsNullOrEmpty(RedirectUri)) RedirectUri = "https://www.moj.io";

                return new SimpleClient.SimpleClient(env, new Configuration { ClientId = ClientId, ClientSecret = ClientSecret, RedirectUri = RedirectUri });

            }
        }

    }


}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mojio.platform.sdk.test;
using Microsoft.Extensions.Configuration;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.SimpleClient;

namespace Mojio.Platform.SDK.Tests
{
    public static class Mother
    {
        static Mother()
        {
            var configBuilder = new ConfigurationBuilder();


            configBuilder.AddEnvironmentVariables();

            if (System.IO.File.Exists("appsettings.json"))
            {
                Console.WriteLine("Mother:appsettings.json found, and loaded");
                configBuilder.AddJsonFile(path: "appsettings.json", optional: true);                
                Console.WriteLine(System.IO.File.ReadAllText("appsettings.json"));
            }

            _configurationRoot = configBuilder.Build();
            Entities.DI.DIContainer.Current.RegisterInstance<IConfigurationRoot>(_configurationRoot);

            var configEnvironment = _configurationRoot["Environment"];
            if (!string.IsNullOrEmpty(configEnvironment))
            {
                Environments env;
                if (Enum.TryParse(configEnvironment, out env))
                {
                    Environment = env;
                }
            }

            Console.WriteLine($"Mother:Environment:{Environment}");

            ClientId = _configurationRoot["ClientId"];
            if (string.IsNullOrEmpty(ClientId)) ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052";
            ClientSecret = _configurationRoot["ClientSecret"];
            if (string.IsNullOrEmpty(ClientSecret)) ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c";
            RedirectUri = _configurationRoot["RedirectUri"];
            if (string.IsNullOrEmpty(RedirectUri)) RedirectUri = "https://www.moj.io";


            Entities.DI.DIContainer.Current.Register<ILog, ConsoleLogger>(B"Debug");



        }

        private static string ClientId;
        private static string ClientSecret;
        private static string RedirectUri;
        private static Environments Environment = Environments.Production;

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

        public static IClient GetNewSimpleClient
        {
            get
            {

                return new SimpleClient.SimpleClient(Environment, new Configuration { ClientId = ClientId, ClientSecret = ClientSecret, RedirectUri = RedirectUri });

            }
        }

    }


}

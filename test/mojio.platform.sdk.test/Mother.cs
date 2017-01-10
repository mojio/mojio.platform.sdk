using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using mojio.platform.sdk.test;
using Microsoft.Extensions.Configuration;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.DryIoc;
using Mojio.Platform.SDK.SimpleClient;

namespace Mojio.Platform.SDK.Tests
{
    public static class Mother
    {
        static Mother()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddEnvironmentVariables();

            var root = SetupTestingPath(configBuilder);

            //automated testing via VSO will automatically create this file
            //which just sets the Envrionment variable
            AddConfigFile(configBuilder, root, "appsettings.environment.json");
            _configurationRoot = configBuilder.Build();
            
            //our root settings should have provided us with an Environment var in our config file, if so, lets wire it up
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

            //finally add our environment specific settings
            AddConfigFile(configBuilder, root, $"appsettings.{Environment}.json");


            _configurationRoot = configBuilder.Build();

            ClientId = _configurationRoot["ClientId"];
            if (string.IsNullOrEmpty(ClientId)) ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052";
            ClientSecret = _configurationRoot["ClientSecret"];
            if (string.IsNullOrEmpty(ClientSecret)) ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c";
            RedirectUri = _configurationRoot["RedirectUri"];
            if (string.IsNullOrEmpty(RedirectUri)) RedirectUri = "https://www.moj.io";

            Entities.DI.DIContainer.Current.Register<ILog, ConsoleLogger>("Debug");
            Entities.DI.DIContainer.Current.RegisterInstance(_configurationRoot);

            Log = Entities.DI.DIContainer.Current.Resolve<ILog>();

            Log.Debug(new {ClientId, ClientSecret, RedirectUri, Environment, Username, Password});


        }

        private static void AddConfigFile(ConfigurationBuilder configBuilder, string root, string name)
        { 
            var p = System.IO.Path.Combine(root, name);
            if (System.IO.File.Exists(p))
            {
                configBuilder.AddJsonFile(path: p, optional: true);
                Console.WriteLine("Config File Added:" + p);
                Console.WriteLine(System.IO.File.ReadAllText(p));
            }
        }

        private static string SetupTestingPath(ConfigurationBuilder configBuilder, string root = null, bool checkProjectStructure = true)
        {
            
            var fileName = "appsettings.json";
            if (string.IsNullOrEmpty(root))
            {
                root = typeof(Mother).GetAssembly().CodeBase;
                //root = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
                System.Uri uri = new Uri(root, UriKind.RelativeOrAbsolute);
                System.IO.FileInfo fi = new FileInfo(uri.LocalPath);
                root = fi.DirectoryName;
            }

            var appSettingsFilePath = System.IO.Path.Combine(root, fileName);

            Console.WriteLine("--Resolving appsettings--");

            Console.WriteLine($"==Checking:{appSettingsFilePath}==");
            if (System.IO.File.Exists(appSettingsFilePath))
            {
                Console.WriteLine($"==IS GOOD:{root}==");
                configBuilder.SetBasePath(root);
                return root;
            }
            else
            {
                System.IO.DirectoryInfo rootDirectoryInfo = new DirectoryInfo(root);
                root = rootDirectoryInfo.Parent.FullName;
                appSettingsFilePath = System.IO.Path.Combine(root, fileName);

                Console.WriteLine($"==Checking:{appSettingsFilePath}==");
                if (System.IO.File.Exists(appSettingsFilePath))
                {
                    Console.WriteLine($"==IS GOOD:{root}==");
                    configBuilder.SetBasePath(root);
                    return root;
                }
                else
                {
                    root = rootDirectoryInfo.GetDirectories()?.FirstOrDefault()?.FullName;
                    if (root != null)
                    {
                        appSettingsFilePath = System.IO.Path.Combine(root, fileName);
                    }
                    Console.WriteLine($"==Checking:{appSettingsFilePath}==");
                    if (System.IO.File.Exists(appSettingsFilePath))
                    {
                        Console.WriteLine($"==IS GOOD:{root}==");
                        configBuilder.SetBasePath(root);
                        return root;
                    }
                    else
                    {
                        if (checkProjectStructure)
                        {
                            root = System.IO.Path.GetFullPath(".");
                            return SetupTestingPath(configBuilder, root, false);
                        }
                        else
                        {
                            throw new Exception("--Configuration not found--");
                        }
                    }
                }
            }
        }

        public static ILog Log = null;

        private static string ClientId;
        private static string ClientSecret;
        private static string RedirectUri;
        private static Environments Environment = Environments.Production;

        public static IDIContainer DIContainer => Mojio.Platform.SDK.Entities.DI.DIContainer.Current;

        public static System.Random Random => new System.Random();

        private static int RandomId = Random.Next(0, 999);

        public static string Username
        {
            get
            {
                var user = _configurationRoot["test_username"];
                if (string.IsNullOrEmpty(user))
                {
                    if (Environment == Environments.Load)
                    {
                        user = "loadtest" + RandomId;
                    }
                    else
                    {
                        user = "robc@moj.io";
                    }
                }
                return user;
            }
        }

        public static string Password
        {
            get
            {
                var password = _configurationRoot["test_password"];
                if (string.IsNullOrEmpty(password))
                {
                    if (Environment == Environments.Load)
                    {
                        password = "Password1";

                    }
                    else
                    {
                        password = "1080HoweVehicles";

                    }
                }
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

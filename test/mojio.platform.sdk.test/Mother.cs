using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.DryIoc;
using Mojio.Platform.SDK.SimpleClient;
using Newtonsoft.Json.Linq;

namespace mojio.platform.sdk.test
{
    public static class Mother
    {
        public static ILog Log;

        private static readonly JObject Config;
        public static string ClientId;
        public static string ClientSecret;
        public static string RedirectUri;
        public static Environments Environment = Environments.NaStaging;

        public static IDIContainer DiContainer => Mojio.Platform.SDK.Entities.DI.DIContainer.Current;
        public static IClient GetNewSimpleClient => new SimpleClient(Environment, new Configuration { ClientId = ClientId, ClientSecret = ClientSecret, RedirectUri = RedirectUri });

        public static Random Random => new Random();

        public static Tuple<string, string, string> Credentials
        {
            get
            {
                var username = Config["NaStaging"]["Credentials"].First["username"].ToString();
                var email = Config["NaStaging"]["Credentials"].First["email"].ToString();
                var password = Config["NaStaging"]["Credentials"].First["password"].ToString();

                return Tuple.Create(username, email, password);
            }
        }

        public static Tuple<string, string, string> CredentialsWithSpecialCasePassword
        {
            get
            {
                var accounts = Config["NaStaging"]["Credentials"];
                var regex = new Regex("[!+* /]");

                foreach (var account in accounts)
                {
                    var username = account["username"].ToString();
                    var email = account["email"].ToString();
                    var password = account["password"].ToString();

                    if (regex.IsMatch(password))
                    {
                        return Tuple.Create(username, email, password);
                    }
                }
                return Tuple.Create("", "", "");
            }
        }

        static Mother()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddEnvironmentVariables();

            var configurationRoot = configBuilder.Build();

            var root = SetupTestingPath(configBuilder);
            var json = File.ReadAllText(root + "\\config.json");

            Config = JObject.Parse(json);

            ClientId = Config["NaStaging"]["ClientId"].ToString();
            ClientSecret = Config["NaStaging"]["SecretKey"].ToString();
            RedirectUri = Config["NaStaging"]["RedirectUri"].ToString();

            Mojio.Platform.SDK.Entities.DI.DIContainer.Current.Register<ILog, ConsoleLogger>("Debug");
            Mojio.Platform.SDK.Entities.DI.DIContainer.Current.RegisterInstance(configurationRoot);

            Log = Mojio.Platform.SDK.Entities.DI.DIContainer.Current.Resolve<ILog>();

            Log.Debug(new { ClientId, ClientSecret, RedirectUri, Environment, Credentials.Item1, Credentials.Item3 });
            
        }

        private static string SetupTestingPath(ConfigurationBuilder configBuilder, string root = null, bool checkProjectStructure = true)
        {
            
            var fileName = "config.json";
            if (string.IsNullOrEmpty(root))
            {
                root = typeof(Mother).GetAssembly().CodeBase;
                //root = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
                var uri = new Uri(root, UriKind.RelativeOrAbsolute);
                var fi = new FileInfo(uri.LocalPath);
                root = fi.DirectoryName;
            }

            var appSettingsFilePath = Path.Combine(root, fileName);

            Console.WriteLine("--Resolving appsettings--");

            Console.WriteLine($"==Checking:{appSettingsFilePath}==");
            if (File.Exists(appSettingsFilePath))
            {
                Console.WriteLine($"==IS GOOD:{root}==");
                configBuilder.SetBasePath(root);
                return root;
            }
            else
            {
                var rootDirectoryInfo = new DirectoryInfo(root);
                root = rootDirectoryInfo.Parent.FullName;
                appSettingsFilePath = Path.Combine(root, fileName);

                Console.WriteLine($"==Checking:{appSettingsFilePath}==");
                if (File.Exists(appSettingsFilePath))
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
                        appSettingsFilePath = Path.Combine(root, fileName);
                    }
                    Console.WriteLine($"==Checking:{appSettingsFilePath}==");
                    if (File.Exists(appSettingsFilePath))
                    {
                        Console.WriteLine($"==IS GOOD:{root}==");
                        configBuilder.SetBasePath(root);
                        return root;
                    }
                    else
                    {
                        if (checkProjectStructure)
                        {
                            root = Path.GetFullPath(".");
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

    }


}

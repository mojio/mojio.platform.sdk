using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using Mojio.Platform.SDK.CLI.Commands;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Configuration = Mojio.Platform.SDK.SimpleClient.Configuration;

namespace Mojio.Platform.SDK.CLI
{
    public class Program
    {
        private static ILog Logger;
        public IClient Client { get; set; }

        public static void Main(string[] args)
        {
            var env = Environments.Production;
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddCommandLine(args);
            if (System.IO.File.Exists("appsettings.json")) configBuilder.AddJsonFile("appsettings.json");
            var configuration = configBuilder.Build();
            DIContainer.Current.RegisterInstance<IConfigurationRoot>(configuration);

            var Environment = configuration["Environment"];
            if (!string.IsNullOrEmpty(Environment))
            {
                Enum.TryParse(Environment, out env);
            }
            var ClientId = configuration["ClientId"];
            if (string.IsNullOrEmpty(ClientId)) ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052";
            var ClientSecret = configuration["ClientSecret"];
            if (string.IsNullOrEmpty(ClientSecret)) ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c";
            var RedirectUri = configuration["RedirectUri"];
            if (string.IsNullOrEmpty(RedirectUri)) RedirectUri = "https://www.moj.io";

            var client = new SimpleClient.SimpleClient(env, new Configuration { ClientId = ClientId, ClientSecret = ClientSecret, RedirectUri = RedirectUri });

            var p = new Program();
            p.Run(args, Logger, client).Wait();
        }

        public async Task Run(string[] args, ILog logger = null, IClient client = null)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            DIContainer.Current.Register<ILog, ConsoleLogger>("Debug");
            DIContainer.Current.Register(typeof(IObserver<>), typeof(LoggingObserver<>));

#if DOTNETCORE
            var asm = System.Reflection.Assembly.Load(new AssemblyName("Mojio.Platform.SDK.Live.WebSocket"));
            if (asm != null)
            {
                var containerType = asm.GetType("Mojio.Platform.SDK.Live.WebSocket.WebSocketRegistrationContainer");
                if (containerType != null)
                {
                    var instance = asm.CreateInstance(containerType.FullName) as IRegistrationContainer;
                    if (instance != null)
                    {
                        instance.Register(DIContainer.Current);
                    }
                }
            }
#endif

            if (logger == null)
            {
                Logger = DIContainer.Current.Resolve<ILog>();
            }
            else
            {
                Logger = logger;
            }
            if (client == null)
            {
                //     insert application code here
                Client = new SimpleClient.SimpleClient(Environments.Production, new Configuration
                {
                    ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052",
                    ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c",
                    RedirectUri = "https://www.moj.io"
                });
            }
            else
            {
                Client = client;
            }
            string input = null;
            if (args != null)
            {
                input = string.Join(" ", args);
            }
            if (!string.IsNullOrEmpty(input) && File.Exists(input))
            {
                await ExecuteFile(input, Client);
                return;
            }
            if (!string.IsNullOrEmpty(input))
            {
                await ExecuteSingle(input, Client);
                return;
            }

            while (true)
            {
                try
                {
                    var username = Client?.Authorization?.UserName;
                    if (string.IsNullOrEmpty(username)) username = "anonymous";
                    Console.Write($"{Client.Configuration.Environment.SelectedEnvironment}:{username}-mojio-:>");
                    input = Console.ReadLine();
                    var check = input.ToLowerInvariant().Trim();
                    if (check == "q" || check == "quit" || check == "exit") break;
                    Console.WriteLine("");
                    await Execute(input, Client);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }

        private async Task ExecuteFile(string fileName, IClient client)
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var l in lines)
            {
                var lTrim = l.TrimStart();
                if (!string.IsNullOrEmpty(l) && !lTrim.StartsWith("##"))
                {
                    await ExecuteSingle(l, client);
                }
            }
        }

        private async Task ExecuteSingle(string line, IClient client)
        {
            await Execute(line, client);
        }

        private async Task Execute(string line, IClient client)
        {
            var factory = new CommandFactory(DIContainer.Current.Resolve<ISerializer>());
            ICommand command;
            try
            {
                command = factory.GetCommand(line, client, Logger);

                if (command != null)
                {
                    await command.Execute();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Logger.Fatal(e.Exception, sender.ToString());
            e.SetObserved();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            var source = DIContainer.Current.Resolve<CancellationTokenSource>();
            if (source != null) source.Cancel();
        }
    }
}
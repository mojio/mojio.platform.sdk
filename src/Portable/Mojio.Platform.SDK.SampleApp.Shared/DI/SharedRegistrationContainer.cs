using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using Mojio.Platform.SDK.SampleApp.Shared.Entities;

namespace Mojio.Platform.SDK.SampleApp.Shared.DI
{
    public class SharedRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            container.Register<ILocalization, Localization>();
            container.Register(typeof (IRelayCommand<>), typeof (RelayCommand<>));

            Setup(container);
        }

        private void Setup(IDIContainer container)
        {
            var factory = DIContainer.Current.Resolve<IEnvironmentFactory>();
            var environment = factory.GetEnvironment(Environments.Production);
            DIContainer.Current.RegisterInstance(environment);

            container.RegisterInstance(new HardCodedConfiguration
            {
                ClientId = "f1b18a19-f810-4f16-8a39-d6135f5ec052",
                ClientSecret = "aead4980-c966-4a26-abee-6bdb1ea23e5c",
                RedirectUri = "https://accounts.moj.io",
                Environment = DIContainer.Current.Resolve<IEnvironment>()
            } as IConfiguration);

            DIContainer.Current.Register<ILog, DebugLogger>("Debug");
        }
    }
}
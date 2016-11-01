using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.Entities.Environments
{
    public class EnvironmentFactory : IEnvironmentFactory
    {
        private readonly IDIContainer _container;

        public EnvironmentFactory(IDIContainer container)
        {
            _container = container;
        }

        public IEnvironment GetEnvironment(Contracts.Environments environment)
        {
            IEnvironment env = null;
            try
            {
                env = _container.Resolve<IEnvironment>(environment.ToString());
                if (env != null) return env;
            }
            catch
            {
                //intentionally swallow
            }

            env = new Environment();
            env.SelectedEnvironment = environment;
            var prefix = "";

            switch (environment)
            {
                case Contracts.Environments.Develop:
                    prefix = "develop-";
                    break;
                case Contracts.Environments.Trial:
                    prefix = "trial-";
                    break;

                case Contracts.Environments.NaStaging:
                    prefix = "na-staging-";
                    break;

                case Contracts.Environments.NaProduction:
                    prefix = "na-production-";
                    break;

                case Contracts.Environments.EuProduction:
                    prefix = "eu-production-";
                    break;

                case Contracts.Environments.EuStaging:
                    prefix = "eu-staging-";
                    break;

                case Contracts.Environments.Staging:
                    prefix = "staging-";
                    break;

                default: //US Production
                    break;
            }

            env.AccountsUri = string.Format("https://{0}accounts.moj.io/", prefix);
            env.APIUri = string.Format("https://{0}api.moj.io/", prefix);
            env.ImagesUri = string.Format("https://{0}images.moj.io/", prefix);
            env.PushUri = string.Format("https://{0}push.moj.io/", prefix);
            //_container.RegisterInstance(env, environment.ToString());

            return env;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK
{
    public class InMemoryAuthorizationManager : IAuthorizationManager
    {
        private readonly IDIContainer _container;
        private static IAuthorization _authorization;

        public InMemoryAuthorizationManager(IDIContainer container)
        {
            _container = container;
        }
        public Task Logout()
        {
            _authorization = null;
            return Mojio.Platform.SDK.Contracts.Extension.TaskExtensions.CompletedTask;
        }

        public Task SaveAuthorization(IAuthorization authorization)
        {
            if (authorization != null)
            {
                if (authorization.Success)
                {
                    authorization.Refreshed = false;
                    _authorization = authorization;
                    _container.RegisterInstance<IAuthorization>(_authorization, "Session");
                }
            }
            return Mojio.Platform.SDK.Contracts.Extension.TaskExtensions.CompletedTask;

        }

        public Task<IAuthorization> LoadAuthorization()
        {
            if (_authorization != null && !_authorization.HasExpired)
            {
                _container.RegisterInstance<IAuthorization>(_authorization, "Session");
                var client = _container.Resolve<IClient>();
                client.Authorization = _authorization;
                _container.RegisterInstance<IClient>(client, "Session");
                _authorization.Refreshed = false;
            }   
            return Task.FromResult(_authorization);
        }
    }
}

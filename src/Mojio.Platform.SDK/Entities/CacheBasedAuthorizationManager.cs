using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Entities
{
    public class CacheBasedAuthorizationManager : IAuthorizationManager
    {
        private readonly ICache _cache;
        private readonly IDIContainer _container;
        private readonly ILog _log;

        public CacheBasedAuthorizationManager(ICache cache, IDIContainer container, ILog log)
        {
            _cache = cache;
            _container = container;
            _log = log;
        }

        public async Task Logout()
        {
            if (_cache != null)
            {
                await _cache.Clear();
            }
            try
            {
                _container.Unregister<IAuthorization>("Session");
            }
            catch (Exception)
            {
            }
            try
            {
                _container.Unregister<IClient>("Session");
            }
            catch (Exception)
            {
            }
        }

        public async Task SaveAuthorization(IAuthorization authorization)
        {
            if (_cache != null && authorization != null)
            {
                if (authorization.Success)
                {
                    authorization.Refreshed = false;
                    await _cache.Set(KnownCacheKeys.AuthenticationToken, authorization);
                    _log.Debug("Authorization was saved");
                }
            }
        }

        public async Task<IAuthorization> LoadAuthorization()
        {
            if (_cache != null)
            {
                if (await _cache.Exists(KnownCacheKeys.AuthenticationToken))
                {
                    var auth = await _cache.Get<IAuthorization>(KnownCacheKeys.AuthenticationToken);
                    if (!string.IsNullOrEmpty(auth?.Item?.AccessToken))
                    {
                        if (auth.Item.HasExpired)
                        {
                            await _cache.Delete(KnownCacheKeys.AuthenticationToken);
                            return null;
                        }

                        _container.RegisterInstance<IAuthorization>(auth.Item, "Session");
                        var client = _container.Resolve<IClient>();
                        client.Authorization = auth.Item;
                        _container.RegisterInstance<IClient>(client, "Session");

                        auth.Item.Refreshed = false;

                        _log.Debug("Authorization was loaded");
                        return auth.Item;
                    }
                }
            }
            return null;
        }
    }
}
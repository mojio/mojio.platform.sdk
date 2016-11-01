using Mojio.Platform.SDK.Contracts;
using System.Threading.Tasks;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.Entities
{
    public class NullCacheProvider : ICache
    {
        public async Task<bool> Exists(string key)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> Delete(string key)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> Delete(KnownCacheKeys key)
        {
            return await Task.FromResult(false);
        }

        public Task Clear()
        {
            return TaskExtensions.CompletedTask;
        }

        public async Task<bool> Exists(KnownCacheKeys key)
        {
            return await Task.FromResult(false);
        }

        public async Task<ICacheItem<T>> Get<T>(string key)
        {
            return await Task.FromResult<ICacheItem<T>>(null);
        }

        public async Task<ICacheItem<T>> Get<T>(KnownCacheKeys key)
        {
            return await Task.FromResult<ICacheItem<T>>(null);
        }

        public async Task Set<T>(string key, T value)
        {
            await TaskExtensions.CompletedTask;
        }

        public async Task Set<T>(KnownCacheKeys key, T value)
        {
            await Task.FromResult(false);
        }
    }
}
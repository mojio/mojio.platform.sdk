using System;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public enum KnownCacheKeys
    {
        AuthenticationToken
    }

    public interface ICacheItem<T>
    {
        DateTime StoredDateTime { get; set; }
        T Item { get; set; }
    }

    public interface ICache
    {
        Task<bool> Exists(string key);

        Task<bool> Delete(string key);

        Task<bool> Delete(KnownCacheKeys key);

        Task Clear();

        Task<bool> Exists(KnownCacheKeys key);

        Task<ICacheItem<T>> Get<T>(string key);

        Task<ICacheItem<T>> Get<T>(KnownCacheKeys key);

        Task Set<T>(string key, T value);

        Task Set<T>(KnownCacheKeys key, T value);
    }
}
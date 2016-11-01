using Mojio.Platform.SDK.Contracts;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.SampleApp.Entities
{
    public class StorageCache : ICache
    {
        private readonly IDIContainer _container;
        private readonly ISerializer _serializer;
        private readonly IsolatedStorageFile _storage;
        private readonly SemaphoreSlim consistencyLock = new SemaphoreSlim(1);

        public StorageCache(ISerializer serializer, IDIContainer container)
        {
            _serializer = serializer;
            _container = container;
            _storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (!_storage.DirectoryExists("cache")) _storage.CreateDirectory("cache");
        }

        public async Task<bool> Exists(string key)
        {
            return await Task.FromResult(_storage.FileExists(Path(key)));
        }

        public async Task<bool> Delete(string key)
        {
            if ((await Exists(key))) _storage.DeleteFile(Path(key));
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(KnownCacheKeys key)
        {
            return await Delete(key.ToString());
        }

        public async Task Clear()
        {
            await consistencyLock.WaitAsync();

            if (_storage.DirectoryExists("cache"))
            {
                foreach (var file in _storage.GetFileNames("cache/*.*"))
                {
                    try
                    {
                        _storage.DeleteFile(Path(file));
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    _storage.DeleteDirectory("cache");
                }
                catch (Exception)
                {
                }
            }
            consistencyLock.Release();
        }

        public async Task<bool> Exists(KnownCacheKeys key)
        {
            return await Exists(key.ToString());
        }

        public async Task<ICacheItem<T>> Get<T>(string key)
        {
            if (!(await Exists(key))) return default(ICacheItem<T>);
            await consistencyLock.WaitAsync();
            ICacheItem<T> result = null;
            try
            {
                using (var isoStream = new IsolatedStorageFileStream(Path(key), FileMode.Open, _storage))
                {
                    using (var reader = new StreamReader(isoStream))
                    {
                        var json = await reader.ReadToEndAsync();
                        if (string.IsNullOrEmpty(json)) return default(ICacheItem<T>);
                        try
                        {
                            result = _serializer.Deserialize<ICacheItem<T>>(json);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            consistencyLock.Release();
            return result;
        }

        public async Task<ICacheItem<T>> Get<T>(KnownCacheKeys key)
        {
            return await Get<T>(key.ToString());
        }

        public async Task Set<T>(string key, T value)
        {
            try
            {
                if ((await Exists(key))) _storage.DeleteFile(Path(key));
            }
            catch (Exception)
            {
            }
            await consistencyLock.WaitAsync();
            try
            {
                var cacheItem = _container.Resolve<ICacheItem<T>>();
                cacheItem.Item = value;
                cacheItem.StoredDateTime = DateTime.Now;

                var json = _serializer.SerializeToString(cacheItem);
                if (!string.IsNullOrEmpty(json))
                {
                    using (var isoStream = new IsolatedStorageFileStream(Path(key), FileMode.CreateNew, _storage))
                    {
                        using (var writer = new StreamWriter(isoStream))
                        {
                            await writer.WriteAsync(json);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            consistencyLock.Release();
        }

        public async Task Set<T>(KnownCacheKeys key, T value)
        {
            await Set(key.ToString(), value);
        }

        private string Path(string key)
        {
            return string.Format("cache\\{0}.json", key);
        }
    }
}
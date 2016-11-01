using Mojio.Platform.SDK.Contracts;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class CacheItem<T> : ICacheItem<T>
    {
        public DateTime StoredDateTime { get; set; }
        public T Item { get; set; }
    }
}
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client : IClient
    {
        private readonly ICache _cache;
        private readonly IHttpClientBuilder _clientBuilder;
        private readonly IDIContainer _container;
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly int DefaultCacheExpiry = 0;

        private static Random Rand = new Random();

        public Client(IDIContainer container, IConfiguration configuration, IHttpClientBuilder clientBuilder, ILog log,
            ISerializer serializer, ICache cache, CancellationToken? defaultCancellationToken = null,
            IProgress<ISDKProgress> defaultProgress = null)
        {
            Configuration = configuration;
            _container = container;
            _clientBuilder = clientBuilder;
            if (defaultCancellationToken != null) DefaultCancellationToken = defaultCancellationToken.Value;
            DefaultProgress = defaultProgress;
            _log = log;
            _serializer = serializer;
            _cache = cache;
        }

        private string RandomQueryString()
        {
            return $"";//rnd={Rand.Next(0, 999999)}";
        }

        public CancellationToken DefaultCancellationToken { get; set; }
        public IProgress<ISDKProgress> DefaultProgress { get; set; }
        public IConfiguration Configuration { get; set; }

        public async Task<IPlatformResponse<IAuthorization>> Login(string mojioApiToken,
            CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            if (this.Authorization == null) this.Authorization = new CoreAuthorization();
            this.Authorization.ExpiresIn = int.MaxValue;
            this.Authorization.MojioApiToken = mojioApiToken;

            return await Login(this.Authorization);
        }

        public async Task<byte[]> DownloadImage(IImage image, ImageType type = ImageType.Thumbnail)
        {
            if (image == null) return null;

            var url = image.Thumbnail;
            if (type == ImageType.Normal) url = image.Normal;
            if (type == ImageType.Src) url = image.Src;
            if (string.IsNullOrEmpty(url)) return null;

            var downloadClient = new HttpClient();
            return await downloadClient.GetByteArrayAsync(url);
        }

        private TokenAndProgress IssueNewTokenAndProgressContainer(CancellationToken? cancellationToken = null,
            IProgress<ISDKProgress> progress = null)
        {
            var result = new TokenAndProgress { Progress = DefaultProgress, CancellationToken = DefaultCancellationToken };

            if (cancellationToken.HasValue) result.CancellationToken = cancellationToken.Value;
            if (progress != null) result.Progress = progress;

            return result;
        }

        private async Task<IPlatformResponse<T>> CacheHitOrMiss<T>(string key, Func<Task<IPlatformResponse<T>>> callback,
            TimeSpan? expiryTimeSpan = null)
        {
            if (expiryTimeSpan == null) expiryTimeSpan = TimeSpan.FromMinutes(DefaultCacheExpiry);

            var hitService = true;
            IPlatformResponse<T> response = null;
            if (_cache != null && await _cache.Exists(key))
            {
                try
                {
                    var cachedContent = await _cache.Get<IPlatformResponse<T>>(key);
                    if (cachedContent != null)
                    {
                        cachedContent.Item.CacheHit = true;

                        var dateDiff = DateTime.Now - cachedContent.StoredDateTime;
                        if (expiryTimeSpan.Value.TotalMilliseconds <= 0 || dateDiff.TotalMilliseconds < expiryTimeSpan.Value.TotalMilliseconds)
                        {
                            hitService = false;
                            response = cachedContent.Item;
                        }
                    }
                }
                catch (Exception e)
                {
                    _log.Error(e, key);
                }
            }

            if (hitService)
            {
                response = await callback();
                if (response.Success)
                {
                    await _cache.Set(key, response);
                }
            }
            return response;
        }

        private class TokenAndProgress
        {
            public CancellationToken CancellationToken { get; set; }
            public IProgress<ISDKProgress> Progress { get; set; }
        }
    }
}
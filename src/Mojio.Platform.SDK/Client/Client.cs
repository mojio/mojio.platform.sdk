#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

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
        private readonly IHttpClientBuilder _clientBuilder;
        private readonly IDIContainer _container;
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly int DefaultCacheExpiry = 0;

        private static Random Rand = new Random();

        public Client(IDIContainer container, IConfiguration configuration, IHttpClientBuilder clientBuilder, ILog log,
            ISerializer serializer, CancellationToken? defaultCancellationToken = null,
            IProgress<ISDKProgress> defaultProgress = null)
        {
            Configuration = configuration;
            _container = container;
            _clientBuilder = clientBuilder;
            if (defaultCancellationToken != null) DefaultCancellationToken = defaultCancellationToken.Value;
            DefaultProgress = defaultProgress;
            _log = log;
            _serializer = serializer;
        }

        private string RandomQueryString()
        {
            return $"rnd={Rand.Next(0, 999999)}";
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

        private class TokenAndProgress
        {
            public CancellationToken CancellationToken { get; set; }
            public IProgress<ISDKProgress> Progress { get; set; }
        }
    }
}
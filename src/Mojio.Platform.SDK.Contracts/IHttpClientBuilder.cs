using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IHttpClientBuilder
    {
        IAuthorization Authorization { get; set; }
        HttpClient Client { get; }

        Task<IPlatformResponse<T>> Request<T>(ApiEndpoint endpoint, string relativePath, CancellationToken cancellationToken, IProgress<ISDKProgress> progress = null, HttpMethod method = null, string body = null, byte[] rawData = null, string contentType = "application/json", IDictionary<string, string> headers = null);
    }
}
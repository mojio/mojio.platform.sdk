using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client

    {
        public async Task<IPlatformResponse<IList<string>>> SaveTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IList<string>>(ApiEndpoint.Api, $"v2/{entityType}/{entityId}/tags/{WebUtility.UrlEncode(tag)}", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IList<string>>>(null);
        }
        public async Task<IPlatformResponse<IMessageResponse>> DeleteTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/{entityType}/{entityId}/tags/{WebUtility.UrlEncode(tag)}", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }
    }
}
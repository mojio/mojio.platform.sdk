using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public async Task<IPlatformResponse<IActivityStreamApiResponse>> UserActivityStream(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await CacheHitOrMiss($"UserActivityStream.{Authorization.UserName}",
                    () => _clientBuilder.Request<IActivityStreamApiResponse>(
                        ApiEndpoint.Api, "v2/Users/activities", tokenP.CancellationToken, tokenP.Progress),
                    TimeSpan.FromMinutes(1));
            }
            _log.Fatal(new Exception("Authorization Failed"));

            return await Task.FromResult<IPlatformResponse<IActivityStreamApiResponse>>(null);
        }
    }
}
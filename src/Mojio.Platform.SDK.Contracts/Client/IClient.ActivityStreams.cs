using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientActivityStreams
    {
        Task<IPlatformResponse<IActivityStreamApiResponse>> UserActivityStream(
            CancellationToken? cancellationToken = null,
            IProgress<ISDKProgress> progress = null
            );
    }
}
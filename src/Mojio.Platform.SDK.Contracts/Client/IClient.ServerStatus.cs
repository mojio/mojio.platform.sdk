using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientServerStatus
    {
        Task<IPlatformResponse<IServerStatus>> GetServerStatus(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

    }
}

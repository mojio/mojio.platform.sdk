using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientMe
    {
        Task<IPlatformResponse<IUser>> Me(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
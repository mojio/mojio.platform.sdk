using System;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientUsers
    {
        Task<IPlatformResponse<IUser>> GetUser(string userId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}

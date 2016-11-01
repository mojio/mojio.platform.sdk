using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Machine;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientSimulator
    {
        Task<IPlatformResponse<string>> Simulate(IMachineRequest request, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
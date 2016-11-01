using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientMojio
    {
        Task<IPlatformResponse<IMojioResponse>> Mojios(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMojio>> ClaimMojio(string imei, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMojio>> RenameMojio(Guid id, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> DeleteMojio(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
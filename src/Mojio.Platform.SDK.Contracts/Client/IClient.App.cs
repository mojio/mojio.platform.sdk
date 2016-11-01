using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientApp
    {
        IAuthorization Authorization { get; set; }

        Task<IPlatformResponse<IAppResponse>> Apps(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IApp>> CreateApp(IApp application, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> DeleteApp(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IApp>> UpdateApp(IApp app, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);


        Task<IPlatformResponse<IMessageResponse>> GetAppSecret(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> DeleteAppSecret(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
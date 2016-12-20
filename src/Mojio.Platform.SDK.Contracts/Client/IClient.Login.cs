using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientLogin
    {
        Task<IPlatformResponse<IAuthorization>> Login(string username, string password, string scope = "full", CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IAuthorization>> Login(string mojioApiToken, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IAuthorization>> Login(IAuthorization authorization, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> Register(string email, string password, string username = null, string mobileNumber = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IAuthorization>> RefreshToken(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
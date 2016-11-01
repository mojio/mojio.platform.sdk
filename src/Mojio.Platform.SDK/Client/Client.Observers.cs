using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public System.Uri WebSocketObserverUri(ObserverEntity entity = ObserverEntity.Vehicles, string id = null)
        {
            if (id == null) id = "";
            return
                new Uri(
                    $"{_container.Resolve<IConfiguration>().Environment.APIUri.Replace("https://", "wss://")}v2/vehicles/{id}");
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> Observe(ObserverEntity entity, Guid? entityId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}";
                if (entityId.HasValue && entityId.Value != Guid.Empty)
                {
                    fragment = $"{fragment}/{entityId}";
                }
                if (!string.IsNullOrEmpty(key))
                {
                    fragment = $"{fragment}/{key}";
                }

                var json = _serializer.SerializeToString(observer);
                return await _clientBuilder.Request<IPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }

            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IPushObserverResponse>>(null);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveVehicle(Guid vehicleId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Vehicles, vehicleId, observer, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveMojio(Guid mojioId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Mojios, mojioId, observer, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveUser(Guid userId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Users, userId, observer, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IGetPushObserverResponse>> GetObservers(ObserverEntity entity, Guid? entityId = null, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}";
                if (entityId.HasValue && entityId.Value != Guid.Empty)
                {
                    fragment = $"{fragment}/{entityId}";
                }
                if (!string.IsNullOrEmpty(key))
                {
                    fragment = $"{fragment}/{key}";
                }
                return await _clientBuilder.Request<IGetPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IGetPushObserverResponse>>(null);
        }
    }
}
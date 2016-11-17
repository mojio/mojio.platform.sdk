using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public Uri WebSocketObserverUri(ObserverEntity entity = ObserverEntity.Vehicles, string id = null)
        {
            return new Uri($"{_container.Resolve<IConfiguration>().Environment.APIUri.Replace("https://", "wss://")}v2/{entity}/{id}");
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> Observe(ObserverEntity entity, Guid? entityId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);
            
            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}";
                if (entityId.HasValue && entityId.Value != Guid.Empty)
                {
                    fragment = $"{fragment}/{entityId}";
                }

                var json = _serializer.SerializeToString(observer);
                return await _clientBuilder.Request<IPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }

            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IPushObserverResponse>>(null);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveVehicle(Guid vehicleId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Vehicles, vehicleId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveMojio(Guid mojioId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Mojios, mojioId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveUser(Guid userId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            return await Observe(ObserverEntity.Users, userId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<IPushObserver>>> GetObservers(ObserverEntity entity, Guid? entityId = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}";
                if (entityId.HasValue && entityId.Value != Guid.Empty)
                {
                    fragment = $"{fragment}/{entityId}";
                }
                var result = await _clientBuilder.Request<IList<IPushObserver>>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress);
                return result;
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IList<IPushObserver>>>(null);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> GetObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{key}";
                return await _clientBuilder.Request<IPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IPushObserverResponse>>(null);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> DeleteObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{key}";
                return await _clientBuilder.Request<IPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IPushObserverResponse>>(null);
        }

        public async Task<IPlatformResponse<TTr>> AddObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{observerKey}/transports";
                var json = _serializer.SerializeToString(transport);

                return await _clientBuilder.Request<TTr>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<TTr>>(null);
        }

        public async Task<IPlatformResponse<TTr>> AddOrUpdateObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{observerKey}/transports";
                var json = _serializer.SerializeToString(transport);

               return await _clientBuilder.Request<TTr>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Put, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<TTr>>(null);
        }

        public async Task<IPlatformResponse<IList<ITransport>>> GetObserverTransports(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{key}/transports";
                return await _clientBuilder.Request<IList<ITransport>>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IList<ITransport>>>(null);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> DeleteObserverTransport(ObserverEntity entity, string observerKey, string transportKey, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var fragment = $"v2/{entity}/{observerKey}/transports/{transportKey}";

                return await _clientBuilder.Request<IPushObserverResponse>(ApiEndpoint.Push, fragment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IPushObserverResponse>>(null);
        }
    }
}
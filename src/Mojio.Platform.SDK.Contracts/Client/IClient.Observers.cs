using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientObservers
    {
        System.Uri WebSocketObserverUri(ObserverEntity entity = ObserverEntity.Vehicles, string id = null);

        Task<IPlatformResponse<IPushObserverResponse>> Observe(ObserverEntity entity, Guid? entityId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveVehicle(Guid vehicleId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveMojio(Guid mojioId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveUser(Guid userId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IList<IPushObserver>>> GetObservers(ObserverEntity entity, Guid? entityId = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> GetObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> DeleteObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IList<ITransport>>> GetObserverTransports(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<TTr>> AddObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport;

        Task<IPlatformResponse<TTr>> AddOrUpdateObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport;

        Task<IPlatformResponse<IPushObserverResponse>> DeleteObserverTransport(ObserverEntity entity, string observerKey, string transportKey, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
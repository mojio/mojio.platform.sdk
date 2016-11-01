using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientObservers
    {
        System.Uri WebSocketObserverUri(ObserverEntity entity = ObserverEntity.Vehicles, string id = null);

        Task<IPlatformResponse<IPushObserverResponse>> Observe(ObserverEntity entity, Guid? entityId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveVehicle(Guid vehicleId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveMojio(Guid mojioId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IPushObserverResponse>> ObserveUser(Guid userId, IPushObserver observer, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IGetPushObserverResponse>> GetObservers(ObserverEntity entity, Guid? entityId = null, string key = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
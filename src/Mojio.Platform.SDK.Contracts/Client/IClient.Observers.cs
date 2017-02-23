#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

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
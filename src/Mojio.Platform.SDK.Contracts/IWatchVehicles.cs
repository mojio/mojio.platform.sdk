using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IWatchVehicles
    {
        Task<IObservable<IVehicle>> WatchVehicles(IClient client, string vehicleId = null, CancellationToken cancellationToken = default(CancellationToken), Action<IVehicle> changedAction = null);
    }
}
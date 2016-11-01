using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IWatchVehicles
    {
        Task<IObservable<IVehicle>> WatchVehicles(IClient client, CancellationToken cancellationToken, Action<IVehicle> changedAction = null);
    }
}
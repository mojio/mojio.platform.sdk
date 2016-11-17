using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IWatchUsers
    {
        Task<IObservable<IUser>> WatchUsers(IClient client, string userId = null, CancellationToken cancellationToken = default(CancellationToken), Action<IVehicle> changedAction = null);
    }
}
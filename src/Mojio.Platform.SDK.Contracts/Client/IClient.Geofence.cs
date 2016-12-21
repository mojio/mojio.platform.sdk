using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientGeofence
    {
        Task<IPlatformResponse<IList<IClientGeofence>>> BrowseGeofences(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null );
        Task<IPlatformResponse<IClientGeofence>> ReadGeofences(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null );
        Task<IPlatformResponse<IClientGeofence>> EditGeofence(IGeofenceRegion region, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null );
        Task<IPlatformResponse<IClientGeofence>> AddGeofence(IGeofenceRegion region, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null );
        Task<IPlatformResponse<IClientGeofence>> DeleteGeofence(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null );

    }
}

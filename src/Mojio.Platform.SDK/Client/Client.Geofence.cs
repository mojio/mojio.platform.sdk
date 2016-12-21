using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK
{
    public partial class Client : IClientGeofence 
    {
        public Task<IPlatformResponse<IList<IClientGeofence>>> BrowseGeofences(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPlatformResponse<IClientGeofence>> ReadGeofences(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPlatformResponse<IClientGeofence>> EditGeofence(IGeofenceRegion region, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPlatformResponse<IClientGeofence>> AddGeofence(IGeofenceRegion region, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPlatformResponse<IClientGeofence>> DeleteGeofence(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            throw new NotImplementedException();
        }
    }
}

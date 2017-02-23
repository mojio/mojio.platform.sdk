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

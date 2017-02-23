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

using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public enum ImageType
    {
        Src,
        Normal,
        Thumbnail
    }

    public enum ApiEndpoint
    {
        Api,
        Accounts,
        Images,
        Push
    }

    public interface IClient : IClientApp, IClientLogin, IClientMe, IClientTrip, IClientMojio, IClientVehicle, IClientSimulator, IClientObservers, IClientImage, IClientTags, IClientGroups, IClientActivityStreams, IClientUsers, IClientWifi, IClientCapabilities, IClientGeofence, IClientServerStatus
    {
        IProgress<ISDKProgress> DefaultProgress { get; set; }
        CancellationToken DefaultCancellationToken { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
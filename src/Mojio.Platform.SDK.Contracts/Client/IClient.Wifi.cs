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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientWifi
    {
        Task<IPlatformResponse<IUpdateWifiSettingsStatus>> UpdateWifiSettings(Guid mojioId, string ssid = null, string password = null, WifiRadioStatus? radioStatus = null, TimeSpan? timeToLive = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);

        Task<IPlatformResponse<IUpdateWifiSettingsStatus>> GetWifiSettingsAfterUpdate(Guid mojioId, Guid transactionId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);
    }

    public interface IClientCapabilities
    {
        Task<IPlatformResponse<ICapabilities>> Capabilities(Guid mojioId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);
    }
}
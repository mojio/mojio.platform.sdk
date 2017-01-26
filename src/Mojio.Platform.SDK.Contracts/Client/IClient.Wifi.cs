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
        Task<IPlatformResponse<IUpdateWifiSettingsStatus>> UpdateWifiSettings(string mojioId, string ssid = null, string password = null, WifiRadioStatus? radioStatus = null, TimeSpan? timeToLive = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);

        Task<IPlatformResponse<IUpdateWifiSettingsStatus>> GetWifiSettingsAfterUpdate(string mojioId, string transactionId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);
    }

    public interface IClientCapabilities
    {
        Task<IPlatformResponse<ICapabilities>> Capabilities(Guid mojioId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false);
    }
}
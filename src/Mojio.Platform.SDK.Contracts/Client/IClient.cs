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

    public interface IClient : IClientApp, IClientLogin, IClientMe, IClientTrip, IClientMojio, IClientVehicle, IClientSimulator, IClientObservers, IClientImage, IClientTags, IClientGroups, IClientActivityStreams, IClientUsers
    {
        IProgress<ISDKProgress> DefaultProgress { get; set; }
        CancellationToken DefaultCancellationToken { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
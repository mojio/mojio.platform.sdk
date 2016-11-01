using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientTrip
    {
        Task<IPlatformResponse<IVehiclesResponse>> TripHistoryStates(string tripId, int skip = 0, int top = 10, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IVehicleLocationResponse>> TripHistoryLocations(string tripId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<ITrip>> UpdateTripName(string tripId, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<ITrip>> GetTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> DeleteTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<ITripsResponse>> Trips(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
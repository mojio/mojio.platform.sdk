using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public interface IClientVehicle
    {
        Task<IPlatformResponse<IVehiclesResponse>> Vehicles(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IVehiclesResponse>> VehicleHistoryStates(Guid vehicleId, int skip = 0, int top = 10, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IVinDetails>> VehicleVinLookup(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IServiceScheduleResponse>> VehicleNextService(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<ITripsResponse>> VehicleTrips(Guid vehicleId, int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IVehicleLocationResponse>> VehicleLocations(Guid vehicleId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IVehicle>> CreateNewVehicle(IVehicle vehicle, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
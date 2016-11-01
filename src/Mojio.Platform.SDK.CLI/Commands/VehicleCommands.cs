using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Entities.DI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-vehicle-locations", Description = "List out the locations for a vehicle", Usage = "get-vehicle-locations")]
    public class GetVehicleLocationsCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.VehicleLocations(g, Skip, Top);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid Vehicle id specified");
            }
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-vehicle-history-states", Description = "Vehicle state history", Usage = "get-vehicle-history-states /id:<vehicleid>")]
    public class GetVehicleHistoryStates : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Fields { get; set; } = null;

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.VehicleHistoryStates(g, Skip, Top, Fields);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid Vehicle id specified");
            }
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "create-vehicle", Description = "Create a new vehicle", Usage = "create-vehicle /licenseplate:<license plate> /name:<name> /odometer:<odometer>")]
    public class CreateVehicleCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "l")]
        public string LicensePlate { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "n")]
        public string Name { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "o")]
        public float? Odometer { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var vehicle = DIContainer.Current.Resolve<IVehicle>();
            if (!string.IsNullOrEmpty(Name)) vehicle.Name = Name;
            if (!string.IsNullOrEmpty(LicensePlate)) vehicle.LicensePlate = LicensePlate;
            if (Odometer.HasValue)
            {
                vehicle.Odometer = DIContainer.Current.Resolve<IOdometer>();
                vehicle.Odometer.Value = Odometer.Value;
            }

            var result = await SimpleClient.CreateNewVehicle(vehicle);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-vehicle-next-service", Description = "List out the next service for a vehicle", Usage = "get-vehicle-next-service")]
    public class GetVehicleNextServiceCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.VehicleNextService(g);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid Vehicle id specified");
            }
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-vehicles", Description = "List out all vehicles", Usage = "get-vehicles")]
    public class GetVehiclesCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Filter { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "se")]
        public string Select { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "order")]
        public string OrderBy { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.Vehicles(Skip, Top, Filter, Select, OrderBy);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-vehicle-trips", Description = "List out the locations for a vehicle", Usage = "get-vehicle-trips")]
    public class GetVehicleTripsCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Filter { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "se")]
        public string Select { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "order")]
        public string OrderBy { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.VehicleTrips(g, Skip, Top, Filter, Select, OrderBy);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid Vehicle id specified");
            }
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-vehicle-vin-details", Description = "List out all VIN information for a vehicle", Usage = "get-vehicle-vin-details")]
    public class VehicleCommands : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.VehicleVinLookup(g);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid Vehicle id specified");
            }

            UpdateAuthorization();
        }
    }

#if DOTNETCORE

    [CommandDescriptor(Name = "watch-vehicle", Description = "Begin watching the vehlce",
         Usage = "watch-vehicle /id:VehicleId")]
    public class WatchVehicleCommand : BaseCommand
    {
        [Argument(ArgumentType.Multiple, ShortName = "id")]
        public string[] Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var watch = DIContainer.Current.Resolve<IWatchVehicles>();
            if (watch != null)
            {
                var observer = DIContainer.Current.Resolve<IObserver<IVehicle>>();
                var observeable = await watch.WatchVehicles(SimpleClient, DIContainer.Current.Resolve<CancellationToken>(), vehicle =>
                {
                    Log.Debug(vehicle);
                });
                observeable.Subscribe(observer);
            }
            else
            {
                Log.Debug("Could not watch the vehicle. App level issue.");
            }

            //                var result = await SimpleClient.VehicleTrips(g, Skip, Top, Filter, Select, OrderBy);
            //                Log.Debug(result);
            UpdateAuthorization();
        }
    }

#endif
}
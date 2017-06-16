using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Entities.DI;
using Nustache.Core;
using Mojio.Platform.SDK.Entities.Machine;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "export-trips", Description = "Export trip data", Usage = "export-trips")]
    public class TripExportCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public string Start { get; set; } = DateTimeOffset.UtcNow.AddDays(-1).ToString();

        [Argument(ArgumentType.AtMostOnce, ShortName = "v")]
        public string VehicleId { get; set; } = null;

        [Argument(ArgumentType.AtMostOnce, ShortName = "e")]
        public string End { get; set; } = DateTimeOffset.UtcNow.ToString();

        [Argument(ArgumentType.AtMostOnce, ShortName = "t", DefaultValue = "DefaultTemplate.tmpl")]
        public string ItemTemplate { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "x", DefaultValue = "Output.csv")]
        public string Export { get; set; }

        public override async Task Execute()
        {
            var spinner = new ConsoleSpinner();

            DateTimeOffset start = DateTimeOffset.UtcNow.AddDays(-1);
            DateTimeOffset end = DateTimeOffset.UtcNow;

            if (!string.IsNullOrEmpty(Start))
            {
                if (!DateTimeOffset.TryParse(Start, out start))
                {
                    Console.WriteLine("Could not parse the start date:" + Start);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(End))
            {
                if (!DateTimeOffset.TryParse(End, out end))
                {
                    Console.WriteLine("Could not parse the end date:" + End);
                    return;
                }
            }

            if (start >= end)
            {
                Console.WriteLine("Start date has to be before the End date");
                return;
            }

            spinner.Turn();

            if (string.IsNullOrEmpty(ItemTemplate)) ItemTemplate = "DefaultTemplate.tmpl";

            await Authorize();
            var page = 0;
            var pageSize = 10;

            var exportedList = new List<ITrip>();

            bool keepScrolling = true;

            var vehicles = await SimpleClient.Vehicles(0, 1000);

            var exportedVehicles = new List<IVehicle>();
            foreach (var v in vehicles.Response.Data)
            {
                var customV = new CustomVehicle(v);
                exportedVehicles.Add(customV);
            }

            Guid g = Guid.Empty;
            var hasVehicle = Guid.TryParse(VehicleId, out g);

            while (keepScrolling)
            {
                IPlatformResponse<ITripsResponse> result;
                if (hasVehicle)
                {
                    result = await SimpleClient.VehicleTrips(g, page, pageSize, orderby: "CreatedOn desc"/*, filter: $"CreatedOn >= '{Start}' AND CreatedOn <= '{End}'"*/);
                }
                else
                {
                    result = await SimpleClient.Trips(page, pageSize, orderby: "CreatedOn desc"/*, filter: $"CreatedOn >= '{Start}' AND CreatedOn <= '{End}'"*/);
                }

                UpdateStatusBar(exportedList, vehicles, null, page);

                spinner.Turn();

                if (result.Success)
                {
                    if (result.Response.Data.Count == 0) break;

                    foreach (var trip in result.Response.Data)
                    {
                        ///scroll through the list of trips
                        ///if the createdon date is within the start/end, then add it
                        ///keep scrolling until the createdon date is older than the START date
                        var date = trip.CreatedOn;
                        if (IsInRange(start, end, date))
                        {
                            var ct = new CustomTrip(trip);
                            ct.Vehicle = (from v in vehicles.Response.Data where v.Id == ct.VehicleId.ToString() select v).FirstOrDefault();
                            var locations = await SimpleClient.TripHistoryLocations(trip.Id, 0, 9999);

                            spinner.Turn();
                            UpdateStatusBar(exportedList, vehicles, trip, page);
                            if (locations.Success)
                            {
                                ct.Path = locations.Response.Data;
                            }
                            exportedList.Add(ct);
                        }

                        if (IsOlderThanStart(start, date)) keepScrolling = false;
                        //if (hasVehicle && IsNewerThanEnd(start, date)) keepScrolling = false;
                    }
                }
                else
                {
                    keepScrolling = false;
                }
                page = page + pageSize;
            }
            foreach (var t in exportedList)
            {
                var vehicle = (from v in exportedVehicles where v.Id == t.VehicleId.ToString() select v).FirstOrDefault();
                if (vehicle != null)
                {
                    (vehicle as CustomVehicle).Trips.Add(t);
                }
            }

            var final = new { Trips = exportedList, Vehicles = exportedVehicles };

            if (string.IsNullOrEmpty(ItemTemplate) || !System.IO.File.Exists(ItemTemplate))

            {
                Log.Debug(final);

                if (!string.IsNullOrEmpty(Export)) System.IO.File.WriteAllText(Export, DIContainer.Current.Resolve<ISerialize>().SerializeToString(final));
            }
            else
            {
                if (System.IO.File.Exists(ItemTemplate))
                {
                    try
                    {
                        Console.WriteLine("Binding to template:" + ItemTemplate);
                        var output = Render.FileToString(ItemTemplate, final);
                        Console.WriteLine(output);

                        if (!string.IsNullOrEmpty(Export)) System.IO.File.WriteAllText(Export, output);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            UpdateAuthorization();
        }

        private void UpdateStatusBar(List<ITrip> trips, IPlatformResponse<IVehiclesResponse> vehicles, ITrip trip, int page)
        {
            var pos = new { Console.CursorLeft, Console.CursorTop };

            Console.SetCursorPosition(pos.CursorLeft, pos.CursorTop - 1);
            if (trip != null)
            {
                Console.Write($"Trips:{trips.Count}, Page:{page}, Current:{trip.Id} - {trip.StartTimestamp} {new string(' ', 10)}");
            }
            else
            {
                Console.Write($"Trips:{trips.Count}, Page:{page}, Scanning for trips in range. {new string(' ', 30)}");
            }
            Console.SetCursorPosition(pos.CursorLeft, pos.CursorTop);
        }

        private bool IsInRange(DateTimeOffset start, DateTimeOffset end, DateTimeOffset current)
        {
            return current.LocalDateTime >= start.LocalDateTime && current.LocalDateTime <= end.LocalDateTime;
        }

        private bool IsOlderThanStart(DateTimeOffset start, DateTimeOffset current)
        {
            return current.LocalDateTime <= start.LocalDateTime;
        }

        private bool IsNewerThanEnd(DateTimeOffset end, DateTimeOffset current)
        {
            return current.LocalDateTime > end.LocalDateTime;
        }
    }

    public class CustomTrip : ITrip
    {
        private readonly ITrip _trip;

        public CustomTrip(ITrip trip)
        {
            _trip = trip;
        }

        public string StartLocalDateTime { get { return StartTimestamp.ToLocalTime().ToString("F"); } }
        public string EndLocalDateTime { get { return EndTimestamp.ToLocalTime().ToString("F"); } }

        public string Name { get { return _trip.Name; } set { _trip.Name = value; } }
        public Guid VehicleId { get { return _trip.VehicleId; } set { _trip.VehicleId = value; } }
        public object[] Tags { get { return _trip.Tags; } set { _trip.Tags = value; } }
        public Guid MojioId { get { return _trip.MojioId; } set { _trip.MojioId = value; } }
        public bool Completed { get { return _trip.Completed; } set { _trip.Completed = value; } }
        public TimeSpan Duration { get { return _trip.Duration; } set { _trip.Duration = value; } }
        public DateTime StartTimestamp { get { return _trip.StartTimestamp; } set { _trip.StartTimestamp = value; } }
        public DateTime EndTimestamp { get { return _trip.EndTimestamp; } set { _trip.EndTimestamp = value; } }
        public IOdometer StartOdometer { get { return _trip.StartOdometer; } set { _trip.StartOdometer = value; } }
        public IOdometer EndOdometer { get { return _trip.EndOdometer; } set { _trip.EndOdometer = value; } }
        public ILocation StartLocation { get { return _trip.StartLocation; } set { _trip.StartLocation = value; } }
        public ILocation EndLocation { get { return _trip.EndLocation; } set { _trip.EndLocation = value; } }
        public IMeasurement MaxSpeed { get { return _trip.MaxSpeed; } set { _trip.MaxSpeed = value; } }
        public IMeasurement MaxRPM { get { return _trip.MaxRPM; } set { _trip.MaxRPM = value; } }
        public IMeasurement MaxAcceleration { get { return _trip.MaxAcceleration; } set { _trip.MaxAcceleration = value; } }
        public IMeasurement MaxDeceleration { get { return _trip.MaxDeceleration; } set { _trip.MaxDeceleration = value; } }
        public IMeasurement FuelEfficiency { get { return _trip.FuelEfficiency; } set { _trip.FuelEfficiency = value; } }
        public IMeasurement EndFuelLevel { get { return _trip.EndFuelLevel; } set { _trip.EndFuelLevel = value; } }
        public string Id { get { return _trip.Id; } set { _trip.Id = value; } }
        public DateTime CreatedOn { get { return _trip.CreatedOn; } set { _trip.CreatedOn = value; } }
        public DateTime LastModified { get { return _trip.LastModified; } set { _trip.LastModified = value; } }
        public IDictionary<string, string> Links { get { return _trip.Links; } set { _trip.Links = value; } }
        public IMeasurement StartFuelLevel { get { return _trip.StartFuelLevel; } set { _trip.StartFuelLevel = value; } }
        public float? Distance { get { return EndOdometer?.Value - StartOdometer?.Value; } }

        public IVehicle Vehicle { get; set; }

        public IList<ILocation> Path { get; set; }
    }

    public class CustomVehicle : IVehicle
    {
        private readonly IVehicle _vehicle;

        public CustomVehicle(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public bool Selected { get { return _vehicle.Selected; } set { _vehicle.Selected = value; } }
        public IImage Image { get { return _vehicle.Image; } set { _vehicle.Image = value; } }
        public string Name { get { return _vehicle.Name; } set { _vehicle.Name = value; } }
        public string VIN { get { return _vehicle.VIN; } set { _vehicle.VIN = value; } }
        public Guid MojioId { get { return _vehicle.MojioId; } set { _vehicle.MojioId = value; } }
        public DateTimeOffset LastContactTime { get { return _vehicle.LastContactTime; } set { _vehicle.LastContactTime = value; } }
        public IList<IDiagnosticCode> DiagnosticCodes { get { return _vehicle.DiagnosticCodes; } set { _vehicle.DiagnosticCodes = value; } }
        public IAccelerometer Accelerometer { get { return _vehicle.Accelerometer; } set { _vehicle.Accelerometer = value; } }
        public IMeasurement Acceleration { get { return _vehicle.Acceleration; } set { _vehicle.Acceleration = value; } }
        public IMeasurement Deceleration { get { return _vehicle.Deceleration; } set { _vehicle.Deceleration = value; } }
        public IMeasurement Speed { get { return _vehicle.Speed; } set { _vehicle.Speed = value; } }
        public IOdometer Odometer { get { return _vehicle.Odometer; } set { _vehicle.Odometer = value; } }
        public IMeasurement RPM { get { return _vehicle.RPM; } set { _vehicle.RPM = value; } }
        public IMeasurement FuelEfficiency { get { return _vehicle.FuelEfficiency; } set { _vehicle.FuelEfficiency = value; } }
        public string FuelEfficiencyCalculationMethod { get { return _vehicle.FuelEfficiencyCalculationMethod; } set { _vehicle.FuelEfficiencyCalculationMethod = value; } }
        public IRiskMeasurement FuelLevel { get { return _vehicle.FuelLevel; } set { _vehicle.FuelLevel = value; } }
        public string FuelType { get { return _vehicle.FuelType; } set { _vehicle.FuelType = value; } }
        public DateTimeOffset GatewayTime { get { return _vehicle.GatewayTime; } set { _vehicle.GatewayTime = value; } }
        public IState HarshEventState { get { return _vehicle.HarshEventState; } set { _vehicle.HarshEventState = value; } }
        public IState IdleState { get { return _vehicle.IdleState; } set { _vehicle.IdleState = value; } }
        public IState IgnitionState { get { return _vehicle.IgnitionState; } set { _vehicle.IgnitionState = value; } }
        public IBattery Battery { get { return _vehicle.Battery; } set { _vehicle.Battery = value; } }
        public IHeading Heading { get { return _vehicle.Heading; } set { _vehicle.Heading = value; } }
        public ILocation Location { get { return _vehicle.Location; } set { _vehicle.Location = value; } }
        public IState AccidentState { get { return _vehicle.AccidentState; } set { _vehicle.AccidentState = value; } }
        public IVinCommon VinDetails { get { return _vehicle.VinDetails; } set { _vehicle.VinDetails = value; } }
        public IState TowState { get { return _vehicle.TowState; } set { _vehicle.TowState = value; } }
        public IState ParkedState { get { return _vehicle.ParkedState; } set { _vehicle.ParkedState = value; } }
        public IList<string> Tags { get { return _vehicle.Tags; } set { _vehicle.Tags = value; } }
        public IList<string> OwnerGroups { get { return _vehicle.OwnerGroups; } set { _vehicle.OwnerGroups = value; } }
        public string Id { get { return _vehicle.Id; } set { _vehicle.Id = value; } }
        public DateTimeOffset CreatedOn { get { return _vehicle.CreatedOn; } set { _vehicle.CreatedOn = value; } }
        public DateTimeOffset LastModified { get { return _vehicle.LastModified; } set { _vehicle.LastModified = value; } }
        public IDictionary<string, string> Links { get { return _vehicle.Links; } set { _vehicle.Links = value; } }
        public string LicensePlate { get { return _vehicle.LicensePlate; } set { _vehicle.LicensePlate = value; } }
        public bool MilStatus { get { return _vehicle.MilStatus; } set { _vehicle.MilStatus = value; } }
        public string CurrentTrip { get { return _vehicle.CurrentTrip; } set { _vehicle.CurrentTrip = value; } }
        public IState DisturbanceState { get { return _vehicle.DisturbanceState; } set { _vehicle.DisturbanceState = value; } }
        public IVirtualodometer VirtualOdometer { get { return _vehicle.VirtualOdometer; } set { _vehicle.VirtualOdometer = value; } }
        public DateTimeOffset Time { get { return _vehicle.Time; } set { _vehicle.Time = value; } }
        public IMeasurement VirtualFuelConsumption { get { return _vehicle.VirtualFuelConsumption; } set { _vehicle.VirtualFuelConsumption = value; } }
        public IMeasurement VirtualFuelEfficiency { get { return _vehicle.VirtualFuelEfficiency; } set { _vehicle.VirtualFuelEfficiency = value; } }
        public IList<Guid> WithinGeofences { get { return _vehicle.WithinGeofences; } set { _vehicle.WithinGeofences = value; } }

        public IList<ITrip> Trips { get; set; } = new List<ITrip>();

        public Contracts.Entities.VehicleState VehicleState { get { return _vehicle.VehicleState; } }
    }
}
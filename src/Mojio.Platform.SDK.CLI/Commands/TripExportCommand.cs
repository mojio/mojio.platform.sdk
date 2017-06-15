using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Entities.DI;
using Nustache.Core;

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

            Guid g = Guid.Empty;
            var hasVehicle = Guid.TryParse(VehicleId, out g);

            while (keepScrolling)
            {
                IPlatformResponse<ITripsResponse> result;
                if (hasVehicle)
                {
                    result = await SimpleClient.VehicleTrips(g, page, pageSize);
                }
                else
                {
                    result = await SimpleClient.Trips(page, pageSize);
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
                            var locations = await SimpleClient.TripHistoryLocations(trip.Id, 0, 9999);

                            spinner.Turn();
                            UpdateStatusBar(exportedList, vehicles, trip, page);
                            if (locations.Success)
                            {
                                ct.Path = locations.Response.Data;
                            }
                            exportedList.Add(ct);
                        }
                        //if (!hasVehicle && IsOlderThanStart(start, date)) keepScrolling = false;
                        //if (hasVehicle && IsNewerThanEnd(start, date)) keepScrolling = false;
                    }
                }
                else
                {
                    keepScrolling = false;
                }
                page = page + pageSize;
            }

            var final = new { Trips = exportedList, Vehicles = vehicles };

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
                Console.Write($"Trips:{trips.Count}, Page:{page}, Scanning for trips in range. {new string(' ', 20)}");
            }
            Console.SetCursorPosition(pos.CursorLeft, pos.CursorTop);
        }

        private bool IsInRange(DateTimeOffset start, DateTimeOffset end, DateTimeOffset current)
        {
            return current.LocalDateTime >= start.LocalDateTime && start.LocalDateTime < end.LocalDateTime;
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

        public IList<ILocation> Path { get; set; }
    }
}
using System;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-trips", Description = "List out all trips", Usage = "get-trips")]
    public class GetTripsCommand : BaseCommand
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

            var result = await SimpleClient.Trips(Skip, Top, Filter, Select, OrderBy);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-trip-history-states", Description = "Trip state history",
         Usage = "get-trip-history-states /id:<tripid>")]
    public class GetTripHistoryStates : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Fields { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            var result = await SimpleClient.TripHistoryStates(Id, Skip, Top, Fields);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-trip-history-locations", Description = "Trip location history",
         Usage = "get-trip-history-locations /id:<tripid>")]
    public class GetTripHistoryLOcations : BaseCommand
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
            var result = await SimpleClient.TripHistoryLocations(Id, Skip, Top);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}
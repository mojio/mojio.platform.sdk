using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Entities.DI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-user-stream", Description = "List the current users activity stream", Usage = "get-user-stream")]
    public class ActivityStreamCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.UserActivityStream();
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

#if DOTNETCORE

    [CommandDescriptor(Name = "watch-activities", Description = "Begin watching user activities",
         Usage = "watch-activities")]
    public class WatchActivityCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var watch = DIContainer.Current.Resolve<IWatchActivities>();
            if (watch != null)
            {
                var observer = DIContainer.Current.Resolve<IObserver<IActivity>>();
                var observeable = await watch.WatchActivities(SimpleClient, DIContainer.Current.Resolve<CancellationToken>(), vehicle =>
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
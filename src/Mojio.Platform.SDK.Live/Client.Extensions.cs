using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Live
{
    public static class Client
    {
        private static bool monitoring;
        private static readonly object _lock = new object();
        private static readonly Dictionary<string, DateTimeOffset> lastContactTimes = new Dictionary<string, DateTimeOffset>();
        public static IList<IObservable<IVehicle>> VehicleObservers { get; } = new List<IObservable<IVehicle>>();

        public static IObservable<IVehicle> WatchVehicles(this IClient client, CancellationToken? cancellationToken = null, Action<IVehicle> changedAction = null)
        {
            lock (_lock)
            {
                if (!monitoring)
                {
                    Task.Factory.StartNew(() => MonitorVehicles(client, cancellationToken, changedAction), TaskCreationOptions.LongRunning);
                    monitoring = true;
                }
            }
            var newObserver = new SimpleObservable<IVehicle>();
            VehicleObservers.Add(newObserver);
            return newObserver;
        }

        private static async Task MonitorVehicles(IClient client, CancellationToken? cancellationToken = null, Action<IVehicle> changedAction = null)
        {
            var log = DIContainer.Current.Resolve<ILog>();
            if (client == null || client.Configuration == null || client.Configuration.Environment == null) return;
            if (cancellationToken == null) cancellationToken = DIContainer.Current.Resolve<CancellationToken>();

            while (!cancellationToken.Value.IsCancellationRequested)
            {
                var vehicles = await client.Vehicles(top: 1000, cancellationToken: cancellationToken);
                if (vehicles != null && vehicles.Response != null && vehicles.Response.Data != null)
                {
                    foreach (var v in vehicles.Response.Data)
                    {
                        if (cancellationToken.Value.IsCancellationRequested) return;
                        var fire = false;
                        if (lastContactTimes.ContainsKey(v.Id))
                        {
                            var last = lastContactTimes[v.Id];
                            if (v.LastContactTime > last) // || (DateTimeOffset.UtcNow - v.LastContactTime) > TimeSpan.FromSeconds(10))
                            {
                                //there was a change, fire
                                fire = true;
                                lastContactTimes[v.Id] = v.LastContactTime;
                                log.Info("last contact time changed, fire observer:{0} at {1}", v.Id, v.LastContactTime);
                            }
                        }
                        else
                        {
                            //new vehicle, fire
                            fire = true;
                            lastContactTimes.Add(v.Id, v.LastContactTime);
                            log.Info("new vehicle, fire observer:{0} at {1}", v.Id, v.LastContactTime);
                        }

                        if (fire)
                        {
                            if (changedAction != null) changedAction(v);
                            if (VehicleObservers != null)
                            {
                                foreach (var o in VehicleObservers)
                                {
                                    var simpleObserver = o as SimpleObservable<IVehicle>;
                                    if (simpleObserver != null)
                                    {
                                        simpleObserver.Next(v);
                                    }
                                }
                            }
                        }
                    }
                }
                await Task.Delay(5000);
            }
        }
    }
}
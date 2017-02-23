#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using System;
using System.Threading;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Push;
using Mojio.Platform.SDK.Entities.DI;

namespace Mojio.Platform.SDK.CLI.Commands
{
    
#if DOTNETCORE

    [CommandDescriptor(Name = "watch-mojio", Description = "Begin watching a mojio or all mojios", Usage = "watch-mojio /id:MojioId")]
    public class WatchMojoCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "id")]
        public string Id { get; set; } = null;

        public override async Task Execute()
        {
            await Authorize();

            var watch = DIContainer.Current.Resolve<IWatchMojios>();
            if (watch != null)
            {
                var observer = DIContainer.Current.Resolve<IObserver<IMojio>>();
                var observeable = await watch.WatchMojios(SimpleClient, Id, DIContainer.Current.Resolve<CancellationToken>(), vehicle =>
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

    [CommandDescriptor(Name = "watch-user", Description = "Begin watching a user or all users", Usage = "watch-user /id:UserId")]
    public class WatchUserCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "id")]
        public string Id { get; set; } = null;

        public override async Task Execute()
        {
            await Authorize();

            var watch = DIContainer.Current.Resolve<IWatchMojios>();
            if (watch != null)
            {
                var observer = DIContainer.Current.Resolve<IObserver<IMojio>>();
                var observeable = await watch.WatchMojios(SimpleClient, Id, DIContainer.Current.Resolve<CancellationToken>(), vehicle =>
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

    [CommandDescriptor(Name = "list-watched-mojios", Description = "List currently watched mojios", Usage = "list-watched-mojios")]
    public class ListWatchedMojiosCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.GetObservers(ObserverEntity.Mojios);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-watched-mojio", Description = "Delete specified watched mojio", Usage = "delete-watched-mojio /id:<observer-id>")]
    public class DeleteWatchedMojioCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.DeleteObserver(ObserverEntity.Mojios, Id);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-watched-mojios", Description = "Deletes all watched mojios", Usage = "delete-watched-mojios")]
    public class DeleteWatchedMojiosCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var listResult = await SimpleClient.GetObservers(ObserverEntity.Mojios);
            if (!listResult.Success || listResult.Response == null)
            {
                Log.Debug(listResult);
                return;
            }

            foreach (var watched in listResult.Response)
            {
                var result = await SimpleClient.DeleteObserver(ObserverEntity.Mojios, watched.Key);
                Log.Debug(result);
            }

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "list-watched-users", Description = "List currently watched users", Usage = "list-watched-users")]
    public class ListWatchedUsersCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.GetObservers(ObserverEntity.Users);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-watched-user", Description = "Delete specified watched user", Usage = "delete-watched-user /id:<observer-id>")]
    public class DeleteWatchedUserCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.DeleteObserver(ObserverEntity.Users, Id);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-watched-users", Description = "Deletes all watched users", Usage = "delete-watched-users")]
    public class DeleteWatchedUsersCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var listResult = await SimpleClient.GetObservers(ObserverEntity.Users);
            if (!listResult.Success || listResult.Response == null)
            {
                Log.Debug(listResult);
                return;
            }

            foreach (var watched in listResult.Response)
            {
                var result = await SimpleClient.DeleteObserver(ObserverEntity.Users, watched.Key);
                Log.Debug(result);
            }

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-watched-mojio-transports", Description = "Gets all watched mojio transports", Usage = "get-watched-mojio-transports /i:<observer-id>")]
    public class GetWatchedMojioTransportsCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.GetObserverTransports(ObserverEntity.Mojios, Id);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-watched-user-transports", Description = "Gets all watched user transports", Usage = "get-watched-user-transports /i:<observer-id>")]
    public class GetWatchedUserTransportsCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.GetObserverTransports(ObserverEntity.Users, Id);
            Log.Debug(result);

            UpdateAuthorization();
        }
    }
}

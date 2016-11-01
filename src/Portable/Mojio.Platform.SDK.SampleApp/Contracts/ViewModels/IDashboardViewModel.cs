using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.SampleApp.Contracts.ViewModels
{
    public interface IDashboardViewModel
    {
        IRelayCommand<object> LogoutCommand { get; }
        IAuthorization Authorization { get; set; }
        IDictionary<string, IVehicle> Vehicles { get; set; }
        IUser Me { get; set; }
        ILocation MapCenterLocation { get; set; }
        double MapZoomLevel { get; set; }
        IVehicle SelectedVehicle { get; set; }
    }
}
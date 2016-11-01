using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Live;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class DashboardViewModel : BaseViewModel, IDashboardViewModel, IHaveMe, IObserver<IVehicle>
    {
        private readonly IAuthorizationManager _authManager;
        private readonly ILocationHelper _locationHelper;
        private readonly ILog _log;
        private readonly INavigationService _navigationService;
        private readonly IObservable<IVehicle> _vehicleObservable;
        private ILocation _mapCenterLocation;
        private double _mapZoomLevel;
        private IUser _me;
        private IVehicle _selectedVehicle;
        private IDictionary<string, IVehicle> _vehicles = new Dictionary<string, IVehicle>();

        public DashboardViewModel(IDIContainer container, IAuthorizationManager authManager, INavigationService navigationService, ILocationHelper locationHelper, ILog log)
        {
            _authManager = authManager;
            _navigationService = navigationService;
            _locationHelper = locationHelper;
            _log = log;

            Client.Me().ContinueWith(t => { Me = t.Result.Response; });
            Client.Vehicles().ContinueWith(t =>
            {
                foreach (var v in t?.Result?.Response?.Data)
                {
                    OnNext(v);
                }
            });

            _vehicleObservable = Client.WatchVehicles();
            _vehicleObservable.Subscribe(this);

            LogoutCommand = container.Resolve<IRelayCommand<object>>();

            LogoutCommand.ExecuteAction = async b =>
            {
                await authManager.Logout();
                _navigationService.Navigate(this, "Logout", null);
            };

            MapZoomLevel = 7;
        }

        public IDictionary<string, IVehicle> Vehicles
        {
            get { return _vehicles; }
            set
            {
                _vehicles = value;
                OnPropertyChanged();
            }
        }

        public ILocation MapCenterLocation
        {
            get { return _mapCenterLocation; }
            set
            {
                _mapCenterLocation = value;
                OnPropertyChanged();
            }
        }

        public double MapZoomLevel
        {
            get { return _mapZoomLevel; }
            set
            {
                _mapZoomLevel = value;
                OnPropertyChanged();
            }
        }

        public IVehicle SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                _selectedVehicle = value;
                if (Vehicles != null)
                {
                    foreach (var v in Vehicles)
                    {
                        Vehicles[v.Key].Selected = v.Key == value.Id;
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged("Vehicles");
            }
        }

        public IRelayCommand<object> LogoutCommand { get; }

        public IUser Me
        {
            get { return _me; }
            set
            {
                _me = value;
                OnPropertyChanged();
            }
        }

        public void OnCompleted()
        {
            _log.Info("Vehicles observer completed.");
        }

        public void OnError(Exception error)
        {
            _log.Error(error);
        }

        public void OnNext(IVehicle value)
        {
            if (Vehicles.ContainsKey(value.Id))
            {
                Vehicles[value.Id] = value;
            }
            else
            {
                Vehicles.Add(value.Id, value);
            }

            _log.Info("Vehicles observer OnNext. Count:{0}", Vehicles.Keys.Count);

            OnPropertyChanged("Vehicles");
            OnPropertyChanged("Vehicles.Values");
            UpdateCenter();
        }

        private void UpdateCenter()
        {
            if (_vehicles != null && _vehicles.Count > 0)
            {
                var locations = (from v in _vehicles.Values select v.Location).ToList<ILocation>();
                MapCenterLocation = _locationHelper.FindCenter(locations);
                double sum = 0;

                foreach (var l in locations)
                {
                    if (l != null)
                    {
                        sum += (l.Dilution * 6);
                    }
                }
                MapZoomLevel = (sum / locations.Count);

                OnPropertyChanged("MapCenterLocation.Lat");
                OnPropertyChanged("MapCenterLocation.Lng");
                OnPropertyChanged("MapZoomLevel");
            }
        }
    }
}
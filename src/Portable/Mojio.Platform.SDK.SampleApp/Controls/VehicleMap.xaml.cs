using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Mojio.Platform.SDK.SampleApp.Controls
{
    public sealed partial class VehicleMap : UserControl
    {
        private const double BUFFER = 2.5;
        private readonly ILog _log = DIContainer.Current.Resolve<ILog>();
        private IDashboardViewModel _dashboardViewModel;
        private bool setInitialView;

        public VehicleMap()
        {
            InitializeComponent();
            MainMap.Style = MapStyle.Terrain;
            MainMap.PedestrianFeaturesVisible = true;
            MainMap.TrafficFlowVisible = true;
            MainMap.LandmarksVisible = true;
            MainMap.BusinessLandmarksEnabled = true;
            MainMap.BusinessLandmarksVisible = true;
        }

        //Bing.Maps.Map
        public IDashboardViewModel DashboardViewModel
        {
            get { return _dashboardViewModel; }
            set
            {
                _dashboardViewModel = value;
                (_dashboardViewModel as INotifyPropertyChanged).PropertyChanged += VehicleMap_PropertyChanged;
            }
        }

        private async void VehicleMap_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!setInitialView && e.PropertyName == "MapCenterLocation")
            {
                await CenterMap();
                setInitialView = true;
            }
            if (e.PropertyName == "Vehicles")
            {
                _log.Info("Vehicles view changing");

                MapItems.ItemsSource = FetchPOIs();
            }
        }

        public List<PointOfInterest> FetchPOIs()
        {
            var vehicleArray = new IVehicle[DashboardViewModel.Vehicles.Count];
            DashboardViewModel.Vehicles.Values.ToList().CopyTo(vehicleArray);

            var pois = new List<PointOfInterest>();
            foreach (var v in vehicleArray)
            {
                if (v != null && v.Location != null)
                {
                    var p = new PointOfInterest
                    {
                        Id = v.Id,
                        Location =
                            new Geopoint(new BasicGeoposition
                            {
                                Latitude = v.Location.Lat,
                                Longitude = v.Location.Lng,
                                Altitude = v.Location.Altitude
                            }),
                        DisplayName = v.Name,
                        MoreInfo =
                            string.Format("{1} {2} {3}\nOdometer:{4}\nVin: {0}", v.VIN, v?.VinDetails?.Year,
                                v?.VinDetails?.Make, v?.VinDetails?.Model, v?.Odometer?.Value)
                    };

                    if (v.Image != null && !string.IsNullOrEmpty(v.Image.Thumbnail))
                    {
                        p.ImageSourceUri = new Uri(v.Image.Thumbnail, UriKind.RelativeOrAbsolute);
                    }
                    pois.Add(p);
                }
            }
            return pois;
        }

        private void mapItemButton_Click(object sender, RoutedEventArgs e)
        {
            var buttonSender = sender as Button;
            var poi = buttonSender.DataContext as PointOfInterest;
            if (poi != null)
            {
                var vehicle = (from v in DashboardViewModel.Vehicles.Values where v.Id == poi.Id select v).FirstOrDefault();
                if (vehicle == null) return;
                _dashboardViewModel.SelectedVehicle = vehicle;
            }
        }

        private async void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            await CenterMap();
        }

        public async Task<BasicGeoposition> CenterMap()
        {
            var list = new IVehicle[DashboardViewModel.Vehicles.Values.Count];
            DashboardViewModel.Vehicles.Values.CopyTo(list, 0);

            var c = (
                from v in list
                where v?.Location != null
                select
                new Geopoint(new BasicGeoposition
                {
                    Altitude = v.Location.Altitude,
                    Latitude = v.Location.Lat,
                    Longitude = v.Location.Lng
                })
            ).ToList();

            var scene = MapScene.CreateFromLocations(c);

            await MainMap.TrySetSceneAsync(scene);

            return MainMap.Center.Position;
        }

        private void MapStyle_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var button = sender as Button;
            var title = button?.Content?.ToString();
            switch (title)
            {
                case "Aerial":
                    MainMap.Style = MapStyle.Aerial;
                    break;

                case "Aerial 3D":
                    MainMap.Style = MapStyle.Aerial3D;
                    break;

                case "Aerial 3D With Roads":
                    MainMap.Style = MapStyle.Aerial3DWithRoads;
                    break;

                case "Aerial With Roads":
                    MainMap.Style = MapStyle.AerialWithRoads;
                    break;

                case "None":
                    MainMap.Style = MapStyle.None;
                    break;

                case "Road":
                    MainMap.Style = MapStyle.Road;
                    break;

                case "Terrain":
                    MainMap.Style = MapStyle.Terrain;
                    break;
            }
        }
    }
}
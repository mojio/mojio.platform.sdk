using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class ActivityStreamViewModel : BaseViewModel, IActivityStreamViewModel
    {
        private IList<IActivityViewModel> _activityStream;

        public ActivityStreamViewModel(IDIContainer container)
        {
        }

        public async Task Init()
        {
            var t = await Client.UserActivityStream();

            var list = new List<IActivityViewModel>();
            if (t?.Response?.Data != null)
            {
                foreach (var d in t.Response.Data)
                {
                    var a = DIContainer.Current.Resolve<IActivityViewModel>();
                    var containsKey = d.SummaryMap?.ContainsKey("en");
                    if (containsKey != null && (bool)containsKey)
                    {
                        a.TextDescription = d.SummaryMap["en"];
                    }
                    else
                    {
                        a.TextDescription = d.Name;
                    }

                    if (a.TextDescription.StartsWith("Your"))
                        a.TextDescription = a.TextDescription.Substring("Your".Length).Trim();

                    a.Source = d;

                    if (d.Published != null)
                    {
                        a.PublishedDateTime = Humanizer.DateHumanizeExtensions.Humanize(d.Published.Value,
                            DateTimeOffset.Now);
                    }
                    if (d.Location != null && Math.Abs(d.Location.Latitude) > 0 && Math.Abs(d.Location.Longitude) > 0)
                    {
                        a.MapUrl =
                            new System.Uri(
                                $"https://www.google.com/maps?q={d.Location.Latitude},{d.Location.Longitude}",
                                UriKind.RelativeOrAbsolute);
                        a.HasMapLink = Visibility.Visible;

                        a.StaticMapLink =
                            new System.Uri(
                                $"https://maps.googleapis.com/maps/api/staticmap?center={d.Location.Latitude},{d.Location.Longitude}&zoom=11&size=300x150&maptype=roadmap&markers=color:blue%7Clabel:{d.Location.Name}%7C{d.Location.Latitude},{d.Location.Longitude}");
                        a.StaticMapVisibility = Visibility.Visible;
                    }

                    if (d.Duration != null)
                    {
                        a.Duration = $"Duration: {Humanizer.TimeSpanHumanizeExtensions.Humanize(d.Duration.Value)}";
                        a.HasDuration = Visibility.Visible;
                    }

                    //string vehicleId = null;
                    //if (d.Actor != null && d.Actor.Type == "Vehicle" && !string.IsNullOrEmpty(d.Actor.Id))
                    //{
                    //    vehicleId = d.Actor.Id;
                    //}
                    //else if (d.Target != null && d.Target.Type == "Vehicle" && !string.IsNullOrEmpty(d.Target.Id))
                    //{
                    //    vehicleId = d.Target.Id;
                    //}
                    //else if (d.Result != null && d.Result.Type == "Vehicle" && !string.IsNullOrEmpty(d.Result.Id))
                    //{
                    //    vehicleId = d.Result.Id;
                    //}

                    //if (!string.IsNullOrEmpty(vehicleId))
                    //{
                    //    var guidVehicle = new Guid();
                    //    if (Guid.TryParse(vehicleId, out guidVehicle))
                    //    {
                    //        var image = Client.GetImage(ImageEntities.Vehicles, guidVehicle).Result;
                    //        if (image?.Response?.Thumbnail != null &&
                    //            image.Response.Thumbnail.ToLowerInvariant().StartsWith("h"))
                    //        {
                    //            a.VehicleImage = new BitmapImage { UriSource = new Uri(image.Response.Thumbnail) };
                    //        }
                    //    }
                    //}
                    if (!string.IsNullOrEmpty(d.Name))
                    {
                        var str = d.Name;
                        a.SummaryInitials = string.Join("",
                            str.Where((ch, index) => ch != ' ' && (index == 0 || str[index - 1] == ' ')));

                        var uri = new Uri($"ms-appx:///Assets/{a.SummaryInitials}.png", UriKind.RelativeOrAbsolute);
                        a.VehicleImage = new BitmapImage(uri);

                        var activity = d.Name.Trim().ToLowerInvariant();
                        if (activity.EndsWith("virtual fence") || activity == "trip completed" || activity == "trip started")
                        {
                            if (d.Location != null && Math.Abs(d.Location.Latitude) > 0 &&
                                Math.Abs(d.Location.Longitude) > 0)
                            {
                                a.StaticMapLink =
                                    new System.Uri(
                                        $"https://maps.googleapis.com/maps/api/streetview?location={d.Location.Latitude},{d.Location.Longitude}&size=300x150&heading={180 - d.Location.Altitude}");
                                a.StaticMapVisibility = Visibility.Visible;
                            }
                        }

                        //if (a.SummaryInitials == "TC")
                        //{
                        //    var uriMyFile = new Uri($"ms-appx:///Assets/{a.SummaryInitials}.png");
                        //    a.SummaryImage = new BitmapImage()
                        //    {
                        //        UriSource = uriMyFile
                        //    };
                        //}
                    }
                    list.Add(a);
                }
            }
            ActivityStream = list;
        }

        public IList<IActivityViewModel> ActivityStream
        {
            get { return _activityStream; }
            set
            {
                _activityStream = value;
                OnPropertyChanged();
            }
        }
    }

    public class ActivityViewModel : BaseViewModel, IActivityViewModel
    {
        private string _display;
        private IActivity _source;
        private string _publishedDateTime;
        private System.Uri _mapUrl;
        private Visibility _hasMapLink = Visibility.Collapsed;
        private string _duration;
        private Visibility _hasDuration;
        private ImageSource _vehicleImage;
        private string _summaryInitials;
        private Uri _staticMapLink;
        private Visibility _staticMapVisibility;
        private ImageSource _summaryImage;

        public ImageSource SummaryImage
        {
            get { return _summaryImage; }
            set
            {
                _summaryImage = value;
                OnPropertyChanged();
            }
        }

        public string PublishedDateTime
        {
            get { return _publishedDateTime; }
            set { _publishedDateTime = value; OnPropertyChanged(); }
        }

        public string TextDescription
        {
            get { return _display; }
            set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        public System.Uri MapUrl
        {
            get { return _mapUrl; }
            set
            {
                _mapUrl = value;
                OnPropertyChanged();
            }
        }

        public Visibility HasMapLink
        {
            get { return _hasMapLink; }
            set
            {
                _hasMapLink = value;
                OnPropertyChanged();
            }
        }

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged(); }
        }

        public Visibility HasDuration
        {
            get { return _hasDuration; }
            set { _hasDuration = value; OnPropertyChanged(); }
        }

        public IActivity Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public ImageSource VehicleImage
        {
            get { return _vehicleImage; }
            set
            {
                _vehicleImage = value;
                OnPropertyChanged();
            }
        }

        public string SummaryInitials
        {
            get { return _summaryInitials; }
            set
            {
                _summaryInitials = value;
                OnPropertyChanged();
            }
        }

        public Uri StaticMapLink
        {
            get { return _staticMapLink; }
            set { _staticMapLink = value; OnPropertyChanged(); }
        }

        public Visibility StaticMapVisibility
        {
            get { return _staticMapVisibility; }
            set { _staticMapVisibility = value; OnPropertyChanged(); }
        }
    }
}
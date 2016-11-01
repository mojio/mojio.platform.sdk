using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class PointOfInterest
    {
        public PointOfInterest()
        {
            MoreInfo = "At a glance info info about this Point of interest";
            NormalizedAnchorPoint = new Point(0.5, 1);
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Geopoint Location { get; set; }
        public Uri ImageSourceUri { get; set; }
        public string MoreInfo { get; set; }
        public Point NormalizedAnchorPoint { get; set; }
    }
}
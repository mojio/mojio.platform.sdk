using Mojio.Platform.SDK.Contracts.Entities;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class Location : ILocation
    {
        public double Dilution { get; set; }
        public double Altitude { get; set; }
        public IAddress Address { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Status { get; set; }
        public string GeoHash { get; set; }
    }

    public class VirtualOdometer : Measurement, IVirtualodometer
    {
        public float RolloverValue { get; set; }
    }
}
using System;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Heading : Measurement, IHeading
    {
        public string Direction { get; set; }
        public bool LeftTurn { get; set; }
    }

    public class GpsRadio : IGpsRadio
    {
        public DateTimeOffset Timestamp { get; set; }
        public int NumberOfSattelitesForPositionFix { get; set; }
        public double HorizontalDilutionOfPrecision { get; set; }
        public double PDOP { get; set; }
        public double VDOP { get; set; }
        public ILocation Location { get; set; }
        public string Source { get; set; }
        public double HardwareAccuracyInMeters { get; set; }
        public double PercentLostGPS { get; set; }
        public double PercentLostGPSQ { get; set; }
        public string Status { get; set; }
        public IMeasurement LostLockTime { get; set; }
        public IMeasurement Speed { get; set; }
    }

    public class WifiRadio : IWifiRadio
    {
        public DateTimeOffset Timestamp { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
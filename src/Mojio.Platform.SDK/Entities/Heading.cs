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
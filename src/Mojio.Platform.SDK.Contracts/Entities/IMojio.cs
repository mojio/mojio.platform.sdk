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
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IMojioResponse
    {
        List<IMojio> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IMojio
    {
        string Name { get; set; }
        string IMEI { get; set; }
        DateTimeOffset LastContactTime { get; set; }
        DateTimeOffset GatewayTime { get; set; }
        Guid VehicleId { get; set; }
        ILocation Location { get; set; }
        IList<string> Tags { get; set; }
        IWifiRadio WifiRadio { get; set; }
        IGpsRadio GpsRadio { get; set; }
        IConnectedState ConnectedState { get; set; }
        Guid OwnerId { get; set; }
        Guid Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        bool Deleted { get; set; }
        IMetadata Metadata { get; set; }
        ILinks Links { get; set; }

    }

    public interface IWifiRadio
    {
        DateTimeOffset Timestamp { get; set; }
        string SSID { get; set; }
        string Password { get; set; }
        string Status { get; set; }
    }

    public interface IGpsRadio
    {
        DateTimeOffset Timestamp { get; set; }
        int NumberOfSattelitesForPositionFix { get; set; }
        double HorizontalDilutionOfPrecision { get; set; }
        double PDOP { get; set; }
        double VDOP { get; set; }
        ILocation Location { get; set; }   
        string Source { get; set; }
        double HardwareAccuracyInMeters { get; set; }
        double PercentLostGPS { get; set; }
        double PercentLostGPSQ { get; set; }
        string Status { get; set; }
        IMeasurement LostLockTime { get; set; }
        IMeasurement Speed { get; set; }
    }

    public interface IConnectedState
    {
        DateTimeOffset Timestamp { get; set; }
        bool Value { get; set; }
    }
}
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
    public interface ITripsResponse
    {
        List<ITrip> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface ITrip
    {
        string Name { get; set; }
        Guid VehicleId { get; set; }
        object[] Tags { get; set; }
        Guid MojioId { get; set; }
        bool Completed { get; set; }
        TimeSpan Duration { get; set; }
        DateTime StartTimestamp { get; set; }
        DateTime EndTimestamp { get; set; }
        IOdometer StartOdometer { get; set; }
        IOdometer EndOdometer { get; set; }
        ILocation StartLocation { get; set; }
        ILocation EndLocation { get; set; }
        IMeasurement MaxSpeed { get; set; }
        IMeasurement MaxRPM { get; set; }
        IMeasurement MaxAcceleration { get; set; }
        IMeasurement MaxDeceleration { get; set; }
        IMeasurement FuelEfficiency { get; set; }
        IMeasurement EndFuelLevel { get; set; }
        string Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime LastModified { get; set; }
        IDictionary<string, string> Links { get; set; }
        IMeasurement StartFuelLevel { get; set; }
    }
}
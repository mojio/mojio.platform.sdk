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

using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Entities
{
    public class Trip : ITrip
    {
        public Guid MojioId { get; set; }
        public string Name { get; set; }
        public Guid VehicleId { get; set; }
        public object[] Tags { get; set; }
        public bool Completed { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public IOdometer StartOdometer { get; set; }
        public IOdometer EndOdometer { get; set; }
        public ILocation StartLocation { get; set; }
        public ILocation EndLocation { get; set; }
        public IMeasurement MaxSpeed { get; set; }
        public IMeasurement MaxRPM { get; set; }
        public IMeasurement MaxAcceleration { get; set; }
        public IMeasurement MaxDeceleration { get; set; }
        public IMeasurement FuelEfficiency { get; set; }
        public IMeasurement EndFuelLevel { get; set; }
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
        public IMeasurement StartFuelLevel { get; set; }
    }
}
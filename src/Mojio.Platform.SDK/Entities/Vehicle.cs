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
    public class Vehicle : IVehicle
    {
        public VehicleState VehicleState { get; }
        public bool Selected { get; set; }
        public IImage Image { get; set; }
        public string Name { get; set; }
        public string VIN { get; set; }
        public Guid MojioId { get; set; }
        public DateTimeOffset LastContactTime { get; set; }
        public IList<IDiagnosticCode> DiagnosticCodes { get; set; }
        public IAccelerometer Accelerometer { get; set; }
        public IMeasurement Acceleration { get; set; }
        public IMeasurement Deceleration { get; set; }
        public IMeasurement Speed { get; set; }
        public IOdometer Odometer { get; set; }
        public IMeasurement RPM { get; set; }
        public IMeasurement FuelEfficiency { get; set; }
        public string FuelEfficiencyCalculationMethod { get; set; }
        public IRiskMeasurement FuelLevel { get; set; }
        public string FuelType { get; set; }
        public DateTimeOffset GatewayTime { get; set; }
        public IState HarshEventState { get; set; }
        public IState IdleState { get; set; }
        public IState IgnitionState { get; set; }
        public IBattery Battery { get; set; }
        public IHeading Heading { get; set; }
        public ILocation Location { get; set; }
        public IState AccidentState { get; set; }
        public IVinCommon VinDetails { get; set; }
        public IState TowState { get; set; }
        public IState ParkedState { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> OwnerGroups { get; set; }
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
        public string LicensePlate { get; set; }
        public bool MilStatus { get; set; }
        public string CurrentTrip { get; set; }
        public IState DisturbanceState { get; set; }
        public IVirtualodometer VirtualOdometer { get; set; }
        public DateTimeOffset Time { get; set; }
        public IMeasurement VirtualFuelConsumption { get; set; }
        public IMeasurement VirtualFuelEfficiency { get; set; }

        public IList<Guid> WithinGeofences { get; set; }
    }
}
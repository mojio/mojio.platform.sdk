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
        public string Duration { get; set; }
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
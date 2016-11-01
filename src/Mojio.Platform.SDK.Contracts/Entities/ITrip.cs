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
        string Duration { get; set; }
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
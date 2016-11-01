using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Contracts.Machine
{
    public interface IMachineStates
    {
        string Title { get; set; }
        int Duration { get; set; }
        IMinMax DurationLimit { get; set; }
        int NoOfVehicleStates { get; set; }
        IMinMax RPM { get; set; }
        IMinMax Speed { get; set; }
        IMinMax Fuel { get; set; }
        IMinMax FuelEfficiency { get; set; }
        IMinMax Battery { get; set; }
        IPoints Points { get; set; }
        bool CircularTrip { get; set; }
        IList<IVehicleState> VehicleStates { get; set; }
    }

    public interface IVehicleState
    {
        Guid MessageId { get; set; }
        IVehicle Vehicle { get; set; }
        IMachineTelematicDevice TelematicDevice { get; set; }
    }

    public interface IMinMax
    {
        int Min { get; set; }
        int Max { get; set; }
    }

    public interface IPoints
    {
        float[] Start { get; set; }
        float[] End { get; set; }
        float[] WayPoint { get; set; }
    }

    public interface IMachineTelematicDevice : IMojio
    {
    }
}
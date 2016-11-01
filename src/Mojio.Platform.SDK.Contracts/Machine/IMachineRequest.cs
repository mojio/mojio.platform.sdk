using Mojio.Platform.SDK.Contracts.Entities;
using System;

namespace Mojio.Platform.SDK.Contracts.Machine
{
    public interface IMachineRequest
    {
        string IMEI { get; set; }
        int EventCode { get; set; }
        DateTimeOffset DeviceTime { get; set; }
        IVehicle Vehicle { get; set; }
        IMojio TelematicDevice { get; set; }
        ITrip Trip { get; set; }
        Guid MessageId { get; set; }
    }
}
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Machine;
using System;

namespace Mojio.Platform.SDK.Entities.Machine
{
    public class MachineRequest : IMachineRequest
    {
        public string IMEI { get; set; }
        public int EventCode { get; set; }
        public DateTimeOffset DeviceTime { get; set; }
        public IVehicle Vehicle { get; set; }
        public IMojio TelematicDevice { get; set; }
        public ITrip Trip { get; set; }
        public Guid MessageId { get; set; }
    }
}
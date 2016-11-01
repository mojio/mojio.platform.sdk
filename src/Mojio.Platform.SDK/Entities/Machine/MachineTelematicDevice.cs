using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.Machine;

namespace Mojio.Platform.SDK.Entities.Machine
{
    public class MachineTelematicDevice : IMachineTelematicDevice
    {
        public string Name { get; set; }
        public string IMEI { get; set; }
        public DateTimeOffset LastContactTime { get; set; }
        public DateTimeOffset GatewayTime { get; set; }
        public Guid VehicleId { get; set; }
        public IList<string> Tags { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }

    public class ConnectedState
    {
        public bool Value { get; set; } = true;
    }

    public class OBDFirmware
    {
        public string FirmwareType { get; set; } = "Main";
        public string Version { get; set; } = "C# Simulator 2.0";
    }

    public class AwakeState
    {
        public string AwakeReason { get; set; } = "MotionStart";
        public bool Value { get; set; } = true;
    }
}
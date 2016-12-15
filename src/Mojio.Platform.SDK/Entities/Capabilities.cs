using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Entities
{
    public class Capabilities : ICapabilities
    {
        public IActuators Actuators { get; set; }
        public ISensors Sensors { get; set; }
    }

    public class Actuators : IActuators
    {
        public IWifiradio WifiRadio { get; set; }
    }

    public class Sensors : ISensors
    {
        public ITowstate TowState { get; set; }
    }

    public class Wifiradio : IWifiradio
    {
        public bool ConnectionState { get; set; }
        public bool SSID { get; set; }
        public bool Password { get; set; }
    }

    public class Towstate : ITowstate
    {
        public bool Value { get; set; }
        public IList<string> Type { get; set; }
    }

    public class UpdateWifiSettingsStatus : IUpdateWifiSettingsStatus
    {
        public Guid TransactionId { get; set; }
        public WifiStatus State { get; set; }
    }
}
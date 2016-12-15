using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public enum WifiStatus
    {
        Unknown,
        Failure,
        Success,
        Pending,
    }

    public enum WifiRadioStatus
    {
        Connected,
        Disconnected
    }

    public interface ICapabilities
    {
        IActuators Actuators { get; set; }
        ISensors Sensors { get; set; }
    }

    public interface IActuators
    {
        IWifiradio WifiRadio { get; set; }
    }

    public interface IWifiradio
    {
        bool ConnectionState { get; set; }
        bool SSID { get; set; }
        bool Password { get; set; }
    }

    public interface ISensors
    {
        ITowstate TowState { get; set; }
    }

    public interface ITowstate
    {
        bool Value { get; set; }
        IList<string> Type { get; set; }
    }

    public interface IUpdateWifiSettingsStatus
    {
        Guid TransactionId { get; set; }
        WifiStatus State { get; set; }
    }
}
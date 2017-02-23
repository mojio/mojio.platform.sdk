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
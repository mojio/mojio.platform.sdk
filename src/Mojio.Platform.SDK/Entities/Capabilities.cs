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
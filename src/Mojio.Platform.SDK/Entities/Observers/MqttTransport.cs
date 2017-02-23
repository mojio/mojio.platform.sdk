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

using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class MqttTransport : BaseTransport, IMqttTransport
    {
        public const int DefaultPort = 1883;

        public string HostName { get; set; }
        public int? Port { get; set; }

        public string ClientId { get; set; } = "mojio-api-v2";

        public string Topic { get; set; } 

        public string UserName { get; set; }

        public string Password { get; set; }

        public override TransportTypes TransportType => TransportTypes.Mqtt;
        public override string Type => TransportTypes.Mqtt.ToString().ToLower();
    }
}

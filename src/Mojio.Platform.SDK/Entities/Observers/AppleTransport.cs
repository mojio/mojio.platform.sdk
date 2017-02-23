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
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class AppleTransport : BaseTransport, IAppleTransport
    {
        public string DeviceToken { get; set; }
        public string AlertBody { get; set; }
        public string AlertSound { get; set; }
        public string AlertCategory { get; set; }
        public int Badge { get; set; }
        public Guid AppId { get; set; }

        public override TransportTypes TransportType => TransportTypes.Apple;
        public override string Type => TransportTypes.Apple.ToString().ToLower();
    }
}

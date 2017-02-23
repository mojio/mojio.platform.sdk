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

namespace Mojio.Platform.SDK.Entities
{
    public class Mojio : IMojio
    {
        public string Name { get; set; }
        public string IMEI { get; set; }
        public DateTimeOffset LastContactTime { get; set; }
        public DateTimeOffset GatewayTime { get; set; }
        public Guid VehicleId { get; set; }
        public ILocation Location { get; set; }
        public IList<string> Tags { get; set; }
        public IGpsRadio GpsRadio { get; set; }
        public IConnectedState ConnectedState { get; set; }
        public Guid OwnerId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool Deleted { get; set; }
        public IMetadata Metadata { get; set; }
        public ILinks Links { get; set; }
        public IWifiRadio WifiRadio { get; set; }
    }
}
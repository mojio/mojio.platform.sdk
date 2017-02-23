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
        public Guid MessageId { get; set; }
    }
}
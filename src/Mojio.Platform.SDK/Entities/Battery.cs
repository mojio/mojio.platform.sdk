﻿#region copyright
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

namespace Mojio.Platform.SDK.Entities
{
    public class Battery : RiskMeasurement, IBattery
    {
        public bool Connected { get; set; }
        public IMeasurement LowVoltageDuration { get; set; }
        public IMeasurement HighVoltageDuration { get; set; }
    }
}
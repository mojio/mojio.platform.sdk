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
    public class ServiceScheduleResponse : IServiceScheduleResponse
    {
        public DateTimeOffset TimeStamp { get; set; }
        public float Odometer { get; set; }
        public int AgeInMonths { get; set; }
        public string TimeUnits { get; set; }
        public float TimeValue { get; set; }
        public string DistanceUnits { get; set; }
        public float DistanceValue { get; set; }
        public IList<IService> Services { get; set; }
    }

    public class Service : IService
    {
        public double InitialValue { get; set; }
        public string IntervalType { get; set; }
        public string MaintenanceCategory { get; set; }
        public string MaintenanceName { get; set; }
        public string MaintenanceNotes { get; set; }
        public string OperatingParameter { get; set; }
        public string OperatingParameterNotes { get; set; }
        public string ScheduleDescription { get; set; }
        public string ScheduleName { get; set; }
        public string ServiceEvent { get; set; }
        public string TransNotes { get; set; }
        public string Units { get; set; }
        public double Value { get; set; }
    }
}
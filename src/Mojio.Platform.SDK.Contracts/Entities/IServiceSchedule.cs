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

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IServiceScheduleResponse
    {
        DateTimeOffset TimeStamp { get; set; }
        float Odometer { get; set; }
        int AgeInMonths { get; set; }
        string TimeUnits { get; set; }
        float TimeValue { get; set; }
        string DistanceUnits { get; set; }
        float DistanceValue { get; set; }
        IList<IService> Services { get; set; }
    }

    public interface IService
    {
        double InitialValue { get; set; }
        string IntervalType { get; set; }
        string MaintenanceCategory { get; set; }
        string MaintenanceName { get; set; }
        string MaintenanceNotes { get; set; }
        string OperatingParameter { get; set; }
        string OperatingParameterNotes { get; set; }
        string ScheduleDescription { get; set; }
        string ScheduleName { get; set; }
        string ServiceEvent { get; set; }
        string TransNotes { get; set; }
        string Units { get; set; }
        double Value { get; set; }
    }
}
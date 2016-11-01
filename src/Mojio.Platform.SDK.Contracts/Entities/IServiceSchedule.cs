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
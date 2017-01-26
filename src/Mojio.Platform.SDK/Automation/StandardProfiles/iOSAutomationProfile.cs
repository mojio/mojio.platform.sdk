using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Automation.StandardTasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardProfiles
{
    public class iOSAutomationProfile : AutomationProfile
    {
        static readonly Random Rnd = new Random();

        public iOSAutomationProfile(ILog log, ISerializer serializer) : base(log)
        {
            this.Tasks = new List<IAutomationTask>()
            {
                new GetApiVersionTask(log, serializer),
                new LoginOnceTask(log, serializer) {LoadTestProfile = true},
                new GetVehiclesTask(log, serializer),
                new GetMeTask(log, serializer),
                new GetMojiosTask(log, serializer),
                new GetTripsTask(log, serializer) {Skip = 0, Top = 100},
                new SleepTask() {Delay = 100},
                new GetTripsTask(log, serializer) {Skip = 100, Top = 100},
                new SleepTask() {Delay = 100},
                new GetTripsTask(log, serializer) {Skip = 200, Top = 100},
                new SleepTask() {Delay = 100},

            };

            this.DueTime = Rnd.Next(1000, 10000);
            this.Period = Rnd.Next(1000, 10000);
        }
    }
}
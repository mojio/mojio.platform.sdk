using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Automation.StandardTasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardProfiles
{
    public class AndroidMotionAutomationProfile : AutomationProfile
    {
        static readonly Random Rnd = new Random();

        public AndroidMotionAutomationProfile(ILog log, ISerializer serializer, IEventTimingFactory timingFactory) : base(log, timingFactory)
        {
            this.Tasks = new List<IAutomationTask>()
            {
                new GetApiVersionTask(log, serializer,timingFactory),
                new LoginOnceTask(log, serializer,timingFactory) {LoadTestProfile = true},
                new GetVehiclesTask(log, serializer,timingFactory),
                new GetMeTask(log, serializer,timingFactory),
                new GetMojiosTask(log, serializer,timingFactory),
                new GetTripsTask(log, serializer,timingFactory) {Skip = 0, Top = 100},
                new SleepTask() {Delay = 100},
                new GetTripsTask(log, serializer,timingFactory) {Skip = 100, Top = 100},
                new SleepTask() {Delay = 100},
                new GetTripsTask(log, serializer,timingFactory) {Skip = 200, Top = 100},
                new SleepTask() {Delay = 100},

            };

            this.DueTime = Rnd.Next(1000, 10000);
            this.Period = Rnd.Next(1000, 10000);
        }
    }
}
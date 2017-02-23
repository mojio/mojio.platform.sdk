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

using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class LoginOnceTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly IEventTimingFactory _timerFactory;

        public LoginOnceTask(ILog log, ISerializer serializer, IEventTimingFactory timerFactory)
        {
            _log = log;
            _serializer = serializer;
            _timerFactory = timerFactory;
            Key = "LoginOnce";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {

            using (_timerFactory.EventTimer(timingLogger, Key, "Execute"))
            {

                if (!string.IsNullOrEmpty(client?.Authorization?.MojioApiToken)) return;

                if (properties != null && properties.ContainsKey("LoadTestProfile"))
                {
                    LoadTestProfile = false;
                }

                if (!LoadTestProfile)
                {
                    if (properties != null && properties.ContainsKey("username") && properties.ContainsKey("password"))
                    {
                        var username = properties["username"];
                        var password = properties["password"];

                        var results = await client.Login(username, password);

                    }
                }
                else
                {
                    var username = $"loadtest{Rnd.Next(0, 20000)}";
                    var password = "Password1";
                    var results = await client.Login(username, password);
                }
            }
        }
    }
}
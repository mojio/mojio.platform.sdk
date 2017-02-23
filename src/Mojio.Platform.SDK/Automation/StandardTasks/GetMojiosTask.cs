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
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Automation.StandardTasks
{
    public class GetMojiosTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly IEventTimingFactory _timerFactory;

        public GetMojiosTask(ILog log, ISerializer serializer, IEventTimingFactory timerFactory)
        {
            _log = log;
            _serializer = serializer;
            _timerFactory = timerFactory;
            Key = "GetMojios";
        }

        public int Skip { get; set; } = 0;
        public int Top { get; set; } = 100;
        public string Filter { get; set; }
        public string Select { get; set; }
        public string OrderBy { get; set; }
        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {
            using (_timerFactory.EventTimer(timingLogger, Key, "Execute"))
            {

                var results = await client.Mojios(Skip, Top, Filter, Select, OrderBy);


                if (results?.Response?.Data != null)
                {

                    if (results.Response.Data.Any())
                    {
                        var list = "";
                        foreach (var m in results.Response.Data)
                        {
                            list = list + ";" + m.Id;
                        }

                        properties.Add("Mojio_List", list);
                    }

                }
            }
        }
    }
}
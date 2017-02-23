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
    public class GetCapabilitiesTask : BaseAutomationTask
    {
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly IEventTimingFactory _timerFactory;

        public GetCapabilitiesTask(ILog log, ISerializer serializer, IEventTimingFactory timerFactory)
        {
            _log = log;
            _serializer = serializer;
            _timerFactory = timerFactory;
            Key = "GetCapabilities";
        }

        public bool LoadTestProfile { get; set; } = true;

        public override async Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties)
        {
            using (_timerFactory.EventTimer(timingLogger, Key, "Execute"))
            {

                if (properties != null && properties.ContainsKey("Mojio_List"))
                {
                    var listString = properties["Mojio_List"];
                    if (!string.IsNullOrEmpty(listString))
                    {
                        var list = from l in listString.Split(';') where !string.IsNullOrEmpty(l) select l;
                        foreach (var mojioId in list)
                        {
                            Guid mojioIdGuid;
                            if (Guid.TryParse(mojioId, out mojioIdGuid))
                            {
                                var results = await client.Capabilities(mojioIdGuid);
                            }
                        }
                    }
                }
            }
        }
    }
}
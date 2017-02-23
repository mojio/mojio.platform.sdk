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
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;

namespace Mojio.Platform.SDK.Contracts.Automation
{
    public interface IAutomationProfile
    {
        IDictionary<string, string> Properties { get; set; }
        IList<IAutomationTask> Tasks { get; set; }
        bool RunOnce { get; set; }
        double DueTime { get; set; }
        double Period { get; set; }
        Task Execute(ILog timingLogger, IClient client, IDictionary<string, string> properties);
    }
}
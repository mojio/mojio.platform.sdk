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
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class PushObserverRequest : IPushObserver
    {
        public PushObserverRequest()
        {
            Key = Guid.NewGuid().ToString();
            Transports = new List<ITransport>();
        }
        public string Key { get; set; }
        public IList<ITransport> Transports { get; set; }
        public IList<string> Fields { get; set; }
        public string Conditions { get; set; }
        public int? Debounce { get; set; }
        public Timings? Timing { get; set; }
        public TimeSpan? Throttle { get; set; }
        public TimeSpan? TimeToLive { get; set; }
    }
}

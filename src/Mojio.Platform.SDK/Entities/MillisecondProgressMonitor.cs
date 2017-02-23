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

using Mojio.Platform.SDK.Contracts;
using System;
using System.Diagnostics;

namespace Mojio.Platform.SDK.Entities
{
    public class MillisecondProgressMonitor : IProgressMonitor
    {
        private readonly IDIContainer _container;
        private readonly Stopwatch stopWatch = new Stopwatch();

        public MillisecondProgressMonitor(IDIContainer container)
        {
            _container = container;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public IProgress<ISDKProgress> Progress { get; set; }

        public void Report(string message, double progress)
        {
            if (Progress != null)
            {
                var p = _container.Resolve<ISDKProgress>();
                p.Message = message;
                p.CorrelationId = Id;
                p.Progress = progress;
                p.Timing = stopWatch.ElapsedMilliseconds;
                Progress.Report(p);
            }
        }

        public void Start()
        {
            stopWatch.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
        }
    }
}
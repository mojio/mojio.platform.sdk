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
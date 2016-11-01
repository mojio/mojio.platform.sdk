using System;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IProgressMonitor
    {
        Guid Id { get; set; }
        IProgress<ISDKProgress> Progress { get; set; }

        void Report(string message, double progress);

        void Start();

        void Stop();
    }
}
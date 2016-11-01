using System;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IProgressConsumer<T>
    {
        Progress<T> Progress { get; set; }

        void Start();

        void Stop();
    }
}
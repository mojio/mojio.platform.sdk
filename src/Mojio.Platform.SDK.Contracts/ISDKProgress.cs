using System;

namespace Mojio.Platform.SDK.Contracts
{
    public interface ISDKProgress
    {
        Guid CorrelationId { get; set; }
        long Timing { get; set; }
        double Progress { get; set; }
        string Message { get; set; }
    }
}
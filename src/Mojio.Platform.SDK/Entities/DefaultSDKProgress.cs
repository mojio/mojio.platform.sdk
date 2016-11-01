using Mojio.Platform.SDK.Contracts;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class DefaultSDKProgress : ISDKProgress
    {
        public Guid CorrelationId { get; set; }
        public long Timing { get; set; }
        public double Progress { get; set; }
        public string Message { get; set; }
    }
}
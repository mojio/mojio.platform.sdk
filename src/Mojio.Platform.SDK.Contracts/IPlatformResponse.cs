using System;
using System.Net;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IPlatformResponse<T>
    {
        double RequestDurationMS { get; set; }
        string Url { get; set; }
        DateTimeOffset Timestamp { get; set; }
        T Response { get; set; }
        bool Success { get; set; }
        string ErrorCode { get; set; }
        string ErrorMessage { get; set; }
        bool WasCancelled { get; set; }
        HttpStatusCode HttpStatusCode { get; set; }
        bool CacheHit { get; set; }
        string ARRAffinityInstance { get; set; }
    }
}
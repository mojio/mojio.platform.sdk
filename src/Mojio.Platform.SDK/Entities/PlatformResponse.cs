using Mojio.Platform.SDK.Contracts;
using System;
using System.Net;

namespace Mojio.Platform.SDK.Entities
{
    public class PlatformResponse<T> : IPlatformResponse<T>
    {
        public PlatformResponse()
        {
            WasCancelled = false;
            Success = false;
            RequestDurationMS = 0;
            Timestamp = DateTimeOffset.Now;
            CacheHit = false;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public bool CacheHit { get; set; }
        public string ARRAffinityInstance { get; set; }
        public double RequestDurationMS { get; set; }
        public string Url { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public T Response { get; set; }
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool WasCancelled { get; set; }
    }
}
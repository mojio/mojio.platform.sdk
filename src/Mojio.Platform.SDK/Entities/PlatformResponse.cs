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
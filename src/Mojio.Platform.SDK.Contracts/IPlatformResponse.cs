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
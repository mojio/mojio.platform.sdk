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

using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IHttpClientBuilder
    {
        IAuthorization Authorization { get; set; }
        HttpClient Client { get; }

        Task<IPlatformResponse<T>> Request<T>(ApiEndpoint endpoint, string relativePath, CancellationToken cancellationToken, IProgress<ISDKProgress> progress = null, HttpMethod method = null, string body = null, byte[] rawData = null, string contentType = "application/json", IDictionary<string, string> headers = null);
    }
}
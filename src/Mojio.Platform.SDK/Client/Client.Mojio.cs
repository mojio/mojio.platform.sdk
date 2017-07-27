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
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public async Task<IPlatformResponse<IMojioResponse>> Mojios(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var path = "v2/mojios?";
                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                if (!string.IsNullOrEmpty(filter)) path = path + $"&filter={WebUtility.UrlEncode(filter)}";
                if (!string.IsNullOrEmpty(select)) path = path + $"&select={WebUtility.UrlEncode(select)}";
                if (!string.IsNullOrEmpty(orderby)) path = path + $"&orderby={WebUtility.UrlEncode(orderby)}";

                return await _clientBuilder.Request<IMojioResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMojioResponse>>(null);
        }

        public async Task<IPlatformResponse<IMojio>> Mojio(Guid mojioId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var path = string.Concat("v2/mojios/", mojioId.ToString());

                return await _clientBuilder.Request<IMojio>(ApiEndpoint.Api, path, tokenP.CancellationToken);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMojio>>(null);
        }

        public async Task<IPlatformResponse<IMojio>> ClaimMojio(string imei, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IMojio>(ApiEndpoint.Api, "v2/mojios", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, "{'IMEI' : '" + imei + "'}");
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMojio>>(null);
        }

        public async Task<IPlatformResponse<IMojio>> RenameMojio(Guid id, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IMojio>(ApiEndpoint.Api, string.Format("v2/mojios/{0}", id), tokenP.CancellationToken, tokenP.Progress, HttpMethod.Put, "{'Name' : '" + name + "'}");
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMojio>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteMojio(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, string.Format("v2/mojios/{0}", id), tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }
    }
}
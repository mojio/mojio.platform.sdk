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
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public async Task<IPlatformResponse<IGroupResponse>> Groups(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IGroupResponse>(ApiEndpoint.Api, "v2/groups",
                    tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IGroupResponse>>(null);
        }

        public async Task<IPlatformResponse<IGroup>> Group(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IGroup>(ApiEndpoint.Api, $"v2/groups/{id}", tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IGroup>>(null);
        }

        public async Task<IPlatformResponse<IList<string>>> GroupUsers(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IList<string>>(ApiEndpoint.Api, $"v2/groups/{id}/users",
                    tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IList<string>>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteGroup(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/groups/{id}", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> UpdateGroup(Guid id, IGroup @group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var json = _serializer.SerializeToString(@group);
                return await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/groups/{id}", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Put, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }

        public async Task<IPlatformResponse<IGroup>> CreateGroup(IGroup @group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var json = _serializer.SerializeToString(@group);
                return await _clientBuilder.Request<IGroup>(ApiEndpoint.Api, $"v2/groups", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IGroup>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> RemoveUserFromGroup(Guid id, Guid userId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var json = "{ 'removeUser' : '" + userId + "'}";
                return await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/groups/{id}/users", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }

        public async Task<IPlatformResponse<IList<string>>> AddUserToGroup(Guid id, IList<Guid> users, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var json = _serializer.SerializeToString(users);
                return await _clientBuilder.Request<IList<string>>(ApiEndpoint.Api, $"v2/groups/{id}/users", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IList<string>>>(null);
        }
    }
}
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
   
    public interface IClientGroups
    {
        Task<IPlatformResponse<IGroupResponse>> Groups(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IGroup>> Group(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IList<string>>> GroupUsers(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);


        Task<IPlatformResponse<IMessageResponse>> DeleteGroup(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IMessageResponse>> UpdateGroup(Guid id, IGroup group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IGroup>> CreateGroup(IGroup group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);

        Task<IPlatformResponse<IMessageResponse>> RemoveUserFromGroup(Guid id, Guid userId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IList<string>>> AddUserToGroup(Guid id, IList<Guid> users, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);



    }
}
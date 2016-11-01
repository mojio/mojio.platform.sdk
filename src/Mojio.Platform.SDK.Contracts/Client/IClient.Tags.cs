using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public enum TagEntities
    {
        Users,
        Apps,
        Vehicles,
        Trips,
        Mojios,
        Groups
    }
    public interface IClientTags
    {
        Task<IPlatformResponse<IList<string>>> SaveTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IMessageResponse>> DeleteTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
    }
}
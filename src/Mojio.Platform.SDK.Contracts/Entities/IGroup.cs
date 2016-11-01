using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    [Flags]
    public enum Action
    {
        None = 0,
        Read = 1 << 0,
        Write = 1 << 1,
        Share = 1 << 2,
        Create = 1 << 3,
        Delete = 1 << 4,
        Restricted = 1 << 5,

        Legacy = 1 << 6,

        Immutable = 1 << 11,

        RW = Read | Write,
        Full = RW | Share | Create | Delete,
        Admin = Full | Restricted,

        // Owner and ALL are the same
        All = ~None,
        Owner = All
    }

    public interface IGroupResponse
    {
        IList<IGroup> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IGroup
    {
        string Name { get; set; }
        string Description { get; set; }
        IList<string> Tags { get; set; }
        Guid Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        IDictionary<string, IList<string>> Metadata { get; set; }

        IList<Action> UserPermissions { get; }
        IList<Action> RequestPermissions { get; }

        IDictionary<string, string> Links { get; set; }
    }
}

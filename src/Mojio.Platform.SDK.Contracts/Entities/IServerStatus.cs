using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IServerStatus
    {
        string Message { get; set; }
        DateTimeOffset Time { get; set; }
        string Environment { get; set; }
        string Jurisdiction { get; set; }
        string Version { get; set; }
        string Status { get; set; }
        ILinks Links { get; set; }
    }
}




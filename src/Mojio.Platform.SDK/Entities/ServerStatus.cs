using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class ServerStatus : IServerStatus
    {
        public string Message { get; set; }
        public DateTimeOffset Time { get; set; }
        public string Environment { get; set; }
        public string Jurisdiction { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public ILinks Links { get; set; }
    }
}

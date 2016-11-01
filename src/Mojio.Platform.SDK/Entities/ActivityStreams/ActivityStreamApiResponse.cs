using Mojio.Platform.SDK.Contracts.ActivityStreams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Entities.ActivityStreams
{
    public class ActivityStreamApiResponse : IActivityStreamApiResponse
    {
        public IList<IActivity> Data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.ActivityStreams
{
    public interface IActivityStreamApiResponse
    {
        IList<IActivity> Data { get; set; }
    }
}
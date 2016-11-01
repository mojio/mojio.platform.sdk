using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Push
{
    public interface IGetPushObserverResponse
    {

        int CurrentResults { get; set; }
        string Next { get; set; }
        string Previous { get; set; }

        int Offset { get; set; }
        int Limit { get; set; }
        string Query { get; set; }

        IList<IPushObserverResponse> Data { get; set; }

        IDictionary<string, string> Links { get; set; }

    }
}
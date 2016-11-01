using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Push
{
    public interface IPushObserverResponse : IPushObserver
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        DateTimeOffset ExpiryDate { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Subject { get; set; }

        IDictionary<string, string> Links { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class PushObserverResponse : PushObserverRequest, IPushObserverResponse
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }
}

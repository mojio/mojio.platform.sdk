using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IAppResponse
    {
        List<IApp> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IApp
    {
        string Name { get; set; }
        string Description { get; set; }
        IList<string> RedirectUris { get; set; }
        IList<string> Tags { get; set; }
        Guid Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        IDictionary<string, string> Links { get; set; }
    }
}
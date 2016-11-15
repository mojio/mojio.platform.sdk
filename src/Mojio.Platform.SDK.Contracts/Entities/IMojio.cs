using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IMojioResponse
    {
        List<IMojio> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IMojio
    {
        string Name { get; set; }
        string IMEI { get; set; }
        DateTimeOffset LastContactTime { get; set; }
        DateTimeOffset GatewayTime { get; set; }
        Guid VehicleId { get; set; }
        IList<string> Tags { get; set; }
        string ICCID { get; set; }
        Guid OwnerId { get; set; }
        Guid Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        IDictionary<string, string> Links { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Entities
{

    public interface IGeofenceResponse
    {
        IGeofenceRegion Region { get; set; }
        string Description { get; set; }
        bool Deleted { get; set; }

        List<string> Tags { get; set; }
        string OwnerId { get; set; }
        string Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime LastModified { get; set; }
        IMetadata Metadata { get; set; }
        ILinks Links { get; set; }
    }

    public interface IAddressGeofenceRegion : IGeofenceRegion
    {
        IAddress Address { get; set; }

    }

    public interface ICircleGeofenceRegion : IGeofenceRegion
    {
        float Lat { get; set; }
        float Lng { get; set; }
        IDistance Radius { get; set; }
    }

    public enum GeofenceRegionType
    {
        Circle,
        Address
    }

    public interface IGeofenceRegion
    {
        GeofenceRegionType Type { get; set; }
    }

    public interface IDistance
    {
        string BaseUnit { get; set; }
        DateTime Timestamp { get; set; }
        int BaseValue { get; set; }
        string Unit { get; set; }
        int Value { get; set; }
    }

    public interface IMetadata
    {
        IList<string> UserPermissions { get; set; }
        IList<string> RequestPermissions { get; set; }
    }

}
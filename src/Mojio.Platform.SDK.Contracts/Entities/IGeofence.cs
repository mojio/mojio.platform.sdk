using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{

    public interface IGeofenceResponse
    {
        IGeofenceRegion Region { get; set; }

        string Description { get; set; }

        bool Deleted { get; set; }

        IList<string> Tags { get; set; }

        Guid OwnerId { get; set; }

        Guid Id { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset LastModified { get; set; }

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
        DateTimeOffset Timestamp { get; set; }
        int BaseValue { get; set; }
        string Unit { get; set; }
        int Value { get; set; }
    }

    public interface IMetadata
    {
        IList<string> UserPermissions { get; set; }
        IList<string> RequestPermissions { get; set; }
    }

    public interface IGeofenceRegionFactory
    {
        IGeofenceRegion CreateGeofenceRegion(GeofenceRegionType type);
        GeofenceRegionType GetTypeFromRegion(IGeofenceRegion region);
    }
}
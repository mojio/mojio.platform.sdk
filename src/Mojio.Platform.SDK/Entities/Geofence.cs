using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class GeofenceResponse : IGeofenceResponse
    {
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public IList<string> Tags { get; set; }
        public Guid OwnerId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IMetadata Metadata { get; set; }
        public ILinks Links { get; set; }
        public IGeofenceRegion Region { get; set; }
    }
    public class GeofenceRegion : IGeofenceRegion
    {
        public GeofenceRegionType Type { get; set; }
    }

    public class AddressGeofenceRegion : IAddressGeofenceRegion
    {
        public GeofenceRegionType Type { get; set; }
        public IAddress Address { get; set; }
    }

    public class CircleGeofenceRegion : ICircleGeofenceRegion
    {
        public GeofenceRegionType Type { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public IDistance Radius { get; set; }
    }
    public class Distance : IDistance
    {
        public string BaseUnit { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int BaseValue { get; set; }
        public string Unit { get; set; }
        public int Value { get; set; }
    }

    public class Metadata : IMetadata
    {
        public IList<string> UserPermissions { get; set; }
        public IList<string> RequestPermissions { get; set; }
    }

    public class GeofenceRegionFactory : IGeofenceRegionFactory
    {
        public IGeofenceRegion CreateGeofenceRegion(GeofenceRegionType type)
        {
            if(type == GeofenceRegionType.Address) return new AddressGeofenceRegion();
            return new CircleGeofenceRegion();
        }

        public GeofenceRegionType GetTypeFromRegion(IGeofenceRegion region)
        {
            if(region == null) throw new NullReferenceException(nameof(region));
            if(region.GetType().GetTypeInfo().ImplementedInterfaces.Contains(typeof(IAddressGeofenceRegion))) return GeofenceRegionType.Address;
            return GeofenceRegionType.Circle;
        }
    }
}

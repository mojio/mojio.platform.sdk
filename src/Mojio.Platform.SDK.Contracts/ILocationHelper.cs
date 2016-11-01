using Mojio.Platform.SDK.Contracts.Entities;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts
{
    public enum DistanceUnits
    {
        Miles,
        Kilometers,
        NauticalMiles
    }

    public interface ILocationHelper
    {
        ILocation FindCenter(IList<ILocation> locations);

        double Distance(ILocation left, ILocation right, DistanceUnits units = DistanceUnits.Kilometers);

        double ZoomToAspect(int zoomLevel);

        double ZoomToLocationBounds(ILocation left, ILocation right);
    }
}
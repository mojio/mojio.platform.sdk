using Mojio.Platform.SDK.Contracts.Entities;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Entities
{
    public class VehiclesResponse : IVehiclesResponse
    {
        public IList<IVehicle> Data { get; set; }
        public int Results { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }
}
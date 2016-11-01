using Mojio.Platform.SDK.Bot.Contracts;
using Newtonsoft.Json;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class Location : ILocation
    {
        [JsonProperty(PropertyName = "altitude")]
        public double? Altitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
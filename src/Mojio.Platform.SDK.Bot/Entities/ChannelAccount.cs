using Mojio.Platform.SDK.Bot.Contracts;
using Newtonsoft.Json;
using System;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class ChannelAccount : IChannelAccount
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "isBot")]
        public bool? IsBot { get; set; } = false;
    }
}
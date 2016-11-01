using Mojio.Platform.SDK.Bot.Contracts;
using Newtonsoft.Json;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class Mention : IMention
    {
        [JsonProperty(PropertyName = "mentioned")]
        public IChannelAccount Mentioned { get; set; } = new ChannelAccount();

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
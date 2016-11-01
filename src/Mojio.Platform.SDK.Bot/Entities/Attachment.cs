using Mojio.Platform.SDK.Bot.Contracts;
using Newtonsoft.Json;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class Attachment : IAttachment
    {
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        [JsonProperty(PropertyName = "contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty(PropertyName = "content")]
        public object Content { get; set; }

        [JsonProperty(PropertyName = "fallbackText")]
        public string FallbackText { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "titleLink")]
        public string TitleLink { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}
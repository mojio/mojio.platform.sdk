using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Image : IImage
    {
        public string Src { get; set; }
        public string Normal { get; set; }
        public string Thumbnail { get; set; }
    }
}
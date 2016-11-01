namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IAttachment
    {
        string ContentType { get; set; }
        string ContentUrl { get; set; }
        object Content { get; set; }
        string FallbackText { get; set; }
        string Title { get; set; }
        string TitleLink { get; set; }
        string Text { get; set; }
        string ThumbnailUrl { get; set; }
    }
}
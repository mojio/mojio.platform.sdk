namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IChannelAccount
    {
        string Name { get; set; }
        string ChannelId { get; set; }
        string Address { get; set; }
        string Id { get; set; }
        bool? IsBot { get; set; }
    }
}
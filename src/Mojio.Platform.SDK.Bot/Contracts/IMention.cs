namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IMention
    {
        IChannelAccount Mentioned { get; set; }
        string Text { get; set; }
    }
}
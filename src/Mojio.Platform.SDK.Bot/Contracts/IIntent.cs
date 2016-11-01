namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IIntent
    {
        string Name { get; set; }
        double? Score { get; set; }
    }
}
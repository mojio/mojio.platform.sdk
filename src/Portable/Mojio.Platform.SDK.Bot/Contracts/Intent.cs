namespace Mojio.Platform.SDK.Bot.Contracts
{
    public class Intent : IIntent
    {
        public string Name { get; set; }
        public double? Score { get; set; }
    }
}
namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface ILocation
    {
        double? Altitude { get; set; }
        double? Latitude { get; set; }
        double? Longitude { get; set; }
        string Name { get; set; }
    }
}
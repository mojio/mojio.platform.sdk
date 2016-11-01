namespace Mojio.Platform.SDK.Contracts
{

    public interface IConfiguration
    {
        IEnvironment Environment { get; set; }

        string ClientId { get; set; } //aka App Id from the Developer center
        string RedirectUri { get; set; }
        string ClientSecret { get; set; }

    }
}

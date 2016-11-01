using System;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IAuthorization
    {
        bool IsLoggedIn { get; set; }
        string MojioApiToken { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string AccessToken { get; set; }
        string TokenType { get; set; }
        DateTimeOffset Expires { get; }
        string RefreshToken { get; set; }
        int ExpiresIn { get; set; }
        string Scope { get; set; }
        bool HasExpired { get; }
        bool Refreshed { get; set; }
        bool Success { get; set; }
        string Signature { get; }
    }
}
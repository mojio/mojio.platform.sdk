using System;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public class CoreAuthorization : IAuthorization
    {
        public CoreAuthorization()
        {
            TimeStamp = DateTimeOffset.Now;
            IsLoggedIn = false;
            Scope = "full";
            Refreshed = false;
        }

        public DateTimeOffset TimeStamp { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string Scope { get; set; }

        public bool HasExpired
        {
            get
            {
                if (Expires <= DateTimeOffset.Now) return true;
                return false;
            }
        }

        public bool Refreshed { get; set; }

        public string Signature
        {
            get { return string.Format("{0}_{1}_{2}_{3}_{4}", UserName, Password, MojioApiToken, AccessToken, RefreshToken); }
        }

        public bool IsLoggedIn { get; set; }

        public string MojioApiToken
        {
            get { return AccessToken; }
            set { AccessToken = value; }
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string AccessToken
        {
            get { return access_token; }
            set { access_token = value; }
        }

        public string TokenType
        {
            get { return token_type; }
            set { token_type = value; }
        }

        public DateTimeOffset Expires
        {
            get { return TimeStamp.AddSeconds(expires_in); }
        }

        public string RefreshToken
        {
            get { return refresh_token; }
            set { refresh_token = value; }
        }

        public int ExpiresIn
        {
            get { return expires_in; }
            set { expires_in = value; }
        }

        public bool Success { get; set; } = false;
    }
}
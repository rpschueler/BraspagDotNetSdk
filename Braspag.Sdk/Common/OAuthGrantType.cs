using System.ComponentModel;

namespace Braspag.Sdk.Common
{
    public enum OAuthGrantType : byte
    {
        [Description("client_credentials")]
        ClientCredentials = 0,

        [Description("password")]
        Password = 1,

        [Description("authorization_code")]
        AuthorizationCode = 2,

        [Description("refresh_token")]
        RefreshToken = 4
    }
}
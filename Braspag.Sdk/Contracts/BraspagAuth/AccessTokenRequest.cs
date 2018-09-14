using Braspag.Sdk.Common;

namespace Braspag.Sdk.Contracts.BraspagAuth
{
    public class AccessTokenRequest
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public OAuthGrantType GrantType { get; set; }

        public string Scope { get; set; }
    }
}
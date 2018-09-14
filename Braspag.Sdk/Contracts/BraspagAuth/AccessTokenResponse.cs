using Braspag.Sdk.Common;
using RestSharp.Deserializers;
using System;
using System.Net;

namespace Braspag.Sdk.Contracts.BraspagAuth
{
    public class AccessTokenResponse
    {
        public HttpStatusCode HttpStatus { get; set; }

        [DeserializeAs(Name = "access_token")]
        public string Token { get; set; }

        [DeserializeAs(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        public string ErrorMessage { get; set; }
    }
}
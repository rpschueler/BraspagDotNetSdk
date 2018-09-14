using Braspag.Sdk.BraspagAuth;
using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.BraspagAuth;
using Braspag.Sdk.Tests.AutoFixture;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Braspag.Sdk.Tests
{
    public class BraspagAuthClientTests
    {
        [Theory, AutoNSubstituteData]
        public async Task CreateAccessTokenAsync_ForValidCreditCard_ReturnsAccessToken(BraspagAuthClient sut)
        {
            var request = new AccessTokenRequest
            {
                GrantType = OAuthGrantType.ClientCredentials,
                ClientId = "D3E50953-5D6B-4BA0-A854-7DBA4F26026F",
                ClientSecret = "43VtT15I5l7BocriFWPAlhTjd55VupXq5jVVbubJWLA="
            };

            var response = await sut.CreateAccessTokenAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.HttpStatus);
            Assert.NotNull(response.Token);
        }
    }
}
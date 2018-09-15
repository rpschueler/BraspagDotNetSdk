using Braspag.Sdk.BraspagAuth;
using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.BraspagAuth;
using Braspag.Sdk.Contracts.Velocity;
using Braspag.Sdk.Tests.AutoFixture;
using Braspag.Sdk.Velocity;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Braspag.Sdk.Tests
{
    public class VelocityClientTests
    {
        [Theory, AutoNSubstituteData]
        public async Task PerformAnalysisAsync_ForValidCreditCard_ReturnsAuthorized(VelocityClient sut, BraspagAuthClient authClient)
        {
            var authRequest = new AccessTokenRequest
            {
                GrantType = OAuthGrantType.ClientCredentials,
                ClientId = "5d85902e-592a-44a9-80bb-bdda74d51bce",
                ClientSecret = "mddRzd6FqXujNLygC/KxOfhOiVhlUr2kjKPsOoYHwhQ=",
                Scope = "VelocityApp"
            };

            var authResponse = await authClient.CreateAccessTokenAsync(authRequest);

            Assert.Equal(HttpStatusCode.OK, authResponse.HttpStatus);

            var request = new AnalysisRequest();

            var response = await sut.PerformAnalysisAsync(request, new MerchantCredentials { AccessToken = authResponse.Token, MerchantId = "94E5EA52-79B0-7DBA-1867-BE7B081EDD97" } );

            Assert.Equal(HttpStatusCode.Created, response.HttpStatus);
        }

        //[Theory, AutoNSubstituteData]
        //public async Task CreateSaleAsync_ForValidCreditCardWithAutomaticCapture_ReturnsPaymentConfirmed(PagadorClient sut, SaleRequest request)
        //{
        //    request.Payment.Capture = true;
        //    var response = await sut.CreateSaleAsync(request);

        //    Assert.Equal(HttpStatusCode.Created, response.HttpStatus);
        //    Assert.Equal(TransactionStatus.PaymentConfirmed, response.Payment.Status);
        //}
    }
}

using Braspag.Sdk.Tests.AutoFixture;
using System.Net;
using System.Threading.Tasks;
using Braspag.Sdk.CartaoProtegido;
using Braspag.Sdk.Contracts.CartaoProtegido;
using Xunit;

namespace Braspag.Sdk.Tests
{
    public class CartaoProtegidoClientTests
    {
        [Theory, AutoNSubstituteData]
        public async Task CGetCreditCardAsync_ReturnsData(CartaoProtegidoClient sut)
        {
            var request = new GetCreditCardRequest
            {
                JustClickKey = "1ff03ed9-5f56-4ac6-bfb8-23b7a1aa55a7",
                MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b"
            };

            var response = await sut.GetCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });
        }
    }
}

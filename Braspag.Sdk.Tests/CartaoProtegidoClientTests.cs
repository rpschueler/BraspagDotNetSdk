using System;
using Braspag.Sdk.CartaoProtegido;
using Braspag.Sdk.Contracts.CartaoProtegido;
using Braspag.Sdk.Tests.AutoFixture;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Braspag.Sdk.Tests
{
    public class CartaoProtegidoClientTests
    {
        #region GetCreditCardAsync

        [Theory, AutoNSubstituteData]
        public async Task GetCreditCardAsync_ForValidToken_ReturnsCardData(CartaoProtegidoClient sut)
        {
            var request = new GetCreditCardRequest
            {
                JustClickKey = "1ff03ed9-5f56-4ac6-bfb8-23b7a1aa55a7",
                RequestId = Guid.NewGuid()
            };

            var response = await sut.GetCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.OK, response.HttpStatus);
            Assert.Equal("4539321573193671", response.CardNumber);
            Assert.Equal("453932******3671", response.MaskedCardNumber);
            Assert.Equal("06/2020", response.CardExpiration);
            Assert.Equal("TESTE TESTETESTE", response.CardHolder);
            Assert.Equal(request.RequestId.Value, response.CorrelationId.Value);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetCreditCardAsync_ForInvalidToken_ReturnsErrorMessage(CartaoProtegidoClient sut)
        {
            var request = new GetCreditCardRequest
            {
                JustClickKey = "1ff03ed9-0000-0000-0000-23b700000000"
            };

            var response = await sut.GetCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.OK, response.HttpStatus);
            Assert.NotEmpty(response.ErrorDataCollection);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetCreditCardAsync_ForNullToken_ReturnsInternalServerError(CartaoProtegidoClient sut)
        {
            var request = new GetCreditCardRequest
            {
                JustClickKey = null
            };

            var response = await sut.GetCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.InternalServerError, response.HttpStatus);
        }

        #endregion

        #region GetMaskedCreditCardAsync

        [Theory, AutoNSubstituteData]
        public async Task GetMaskedCreditCardAsync_ForValidToken_ReturnsMaskedCardData(CartaoProtegidoClient sut)
        {
            var request = new GetMaskedCreditCardRequest
            {
                JustClickKey = "1ff03ed9-5f56-4ac6-bfb8-23b7a1aa55a7"
            };

            var response = await sut.GetMaskedCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.OK, response.HttpStatus);
            Assert.Equal("453932******3671", response.MaskedCardNumber);
            Assert.Equal("06/2020", response.CardExpiration);
            Assert.Equal("TESTE TESTETESTE", response.CardHolder);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetMaskedCreditCardAsync_ForInvalidToken_ReturnsErrorMessage(CartaoProtegidoClient sut)
        {
            var request = new GetMaskedCreditCardRequest
            {
                JustClickKey = "1ff03ed9-0000-0000-0000-23b700000000"
            };

            var response = await sut.GetMaskedCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.OK, response.HttpStatus);
            Assert.NotEmpty(response.ErrorDataCollection);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetMaskedCreditCardAsync_ForNullToken_ReturnsInternalServerError(CartaoProtegidoClient sut)
        {
            var request = new GetMaskedCreditCardRequest
            {
                JustClickKey = null
            };

            var response = await sut.GetMaskedCreditCardAsync(request, new MerchantCredentials { MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b" });

            Assert.Equal(HttpStatusCode.InternalServerError, response.HttpStatus);
        }

        #endregion
    }
}

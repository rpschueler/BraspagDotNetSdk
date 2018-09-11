using Braspag.Sdk.Contracts.Pagador;
using Braspag.Sdk.Pagador;
using Braspag.Sdk.Tests.AutoFixture;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Braspag.Sdk.Tests
{
    public class PagadorClientTests
    {
        [Theory, AutoNSubstituteData]
        public async Task CreateSaleAsync_ForValidCreditCard_ReturnsAuthorized(PagadorClient sut, SaleRequest request)
        {
            var response = await sut.CreateSaleAsync(request);

            Assert.Equal(HttpStatusCode.Created, response.HttpStatus);
            Assert.Equal(TransactionStatus.Authorized, response.Payment.Status);
        }

        [Theory, AutoNSubstituteData]
        public async Task CreateSaleAsync_ForValidCreditCardWithAutomaticCapture_ReturnsPaymentConfirmed(PagadorClient sut, SaleRequest request)
        {
            request.Payment.Capture = true;
            var response = await sut.CreateSaleAsync(request);

            Assert.Equal(HttpStatusCode.Created, response.HttpStatus);
            Assert.Equal(TransactionStatus.PaymentConfirmed, response.Payment.Status);
        }
    }
}

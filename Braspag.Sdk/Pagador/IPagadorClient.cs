using Braspag.Sdk.Contracts.Pagador;
using System;
using System.Threading.Tasks;

namespace Braspag.Sdk.Pagador
{
    public interface IPagadorClient
    {
        Task<SaleResponse> CreateSaleAsync(SaleRequest request, MerchantCredentials credentials = null);

        Task<CaptureResponse> CaptureAsync(CaptureRequest request, MerchantCredentials credentials = null);

        Task<VoidResponse> VoidAsync(VoidRequest request, MerchantCredentials credentials = null);

        Task<SaleResponse> GetAsync(string paymentId, MerchantCredentials credentials = null);
    }
}
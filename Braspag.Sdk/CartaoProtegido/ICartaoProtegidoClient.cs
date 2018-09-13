using System.Threading.Tasks;
using Braspag.Sdk.Contracts.CartaoProtegido;

namespace Braspag.Sdk.CartaoProtegido
{
    public interface ICartaoProtegidoClient
    {
        Task<GetCreditCardResponse> GetCreditCardAsync(GetCreditCardRequest request, MerchantCredentials credentials = null);

        Task<GetMaskedCreditCardResponse> GetMaskedCreditCardAsync(GetMaskedCreditCardRequest request, MerchantCredentials credentials = null);

        Task<GetJustClickKeyResponse> GetJustClickKeyAsync(GetJustClickKeyRequest request, MerchantCredentials credentials = null);

        Task<SaveCreditCardResponse> SaveCreditCardAsync(SaveCreditCardRequest request, MerchantCredentials credentials = null);

        Task<InvalidateCreditCardResponse> InvalidateCreditCardAsync(InvalidateCreditCardRequest request, MerchantCredentials credentials = null);
    }
}
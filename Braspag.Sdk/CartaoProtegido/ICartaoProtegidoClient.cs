using System.Threading.Tasks;
using Braspag.Sdk.Contracts.CartaoProtegido;

namespace Braspag.Sdk.CartaoProtegido
{
    public interface ICartaoProtegidoClient
    {
        Task<GetCreditCardResponse> GetCreditCardAsync(GetCreditCardRequest request, MerchantCredentials credentials = null);
    }
}
using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.CartaoProtegido;

namespace Braspag.Sdk.CartaoProtegido
{
    public class CartaoProtegidoClientOptions : ClientOptions
    {
        public MerchantCredentials Credentials { get; set; }
    }
}
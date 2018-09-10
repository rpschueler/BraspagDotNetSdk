using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.Pagador;

namespace Braspag.Sdk.Pagador
{
    public class PagadorClientOptions : ClientOptions
    {
        public MerchantCredentials Credentials { get; set; }
    }
}
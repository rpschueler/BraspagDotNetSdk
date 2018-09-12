namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetCreditCardRequest
    {
        public string MerchantKey { get; set; }

        public string JustClickKey { get; set; }

        public string JustClickAlias { get; set; }
    }
}
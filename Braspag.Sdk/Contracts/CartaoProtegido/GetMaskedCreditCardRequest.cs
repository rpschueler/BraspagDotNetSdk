namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetMaskedCreditCardRequest : BaseRequest
    {
        public string JustClickKey { get; set; }

        public string JustClickAlias { get; set; }
    }
}
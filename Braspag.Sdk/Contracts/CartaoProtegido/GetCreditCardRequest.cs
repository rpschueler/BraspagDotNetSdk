namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetCreditCardRequest : BaseRequest
    {
        public string JustClickKey { get; set; }

        public string JustClickAlias { get; set; }
    }
}
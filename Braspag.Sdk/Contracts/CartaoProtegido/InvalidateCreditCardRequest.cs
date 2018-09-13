namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class InvalidateCreditCardRequest : BaseRequest
    {
        public string JustClickKey { get; set; }

        public string JustClickAlias { get; set; }
    }
}
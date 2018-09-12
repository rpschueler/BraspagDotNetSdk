namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetCreditCardResponse : BaseResponse
    {
        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public string CardExpiration { get; set; }

        public string MaskedCardNumber { get; set; }
    }
}
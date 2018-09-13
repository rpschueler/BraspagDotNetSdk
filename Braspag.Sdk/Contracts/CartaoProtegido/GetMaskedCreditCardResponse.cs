namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetMaskedCreditCardResponse : BaseResponse
    {
        public string CardHolder { get; set; }

        public string CardExpiration { get; set; }

        public string MaskedCardNumber { get; set; }
    }
}
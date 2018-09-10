namespace Braspag.Sdk.Contracts.Pagador
{
    public class CreditCardData
    {
        public string CardToken { get; set; }

        public string CardNumber { get; set; }

        public string Holder { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public string Brand { get; set; }

        public bool? SaveCard { get; set; }

        public string Alias { get; set; }
    }
}
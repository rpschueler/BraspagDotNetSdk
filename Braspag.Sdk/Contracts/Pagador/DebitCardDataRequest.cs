namespace Braspag.Sdk.Contracts.Pagador
{
    public class DebitCardDataRequest
    {
        public string CardNumber { get; set; }

        public string Holder { get; set; }

        public string ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public string Brand { get; set; }
    }
}
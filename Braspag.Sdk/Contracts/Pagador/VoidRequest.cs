namespace Braspag.Sdk.Contracts.Pagador
{
    public class VoidRequest
    {
        public long Amount { get; set; }

        public string PaymentId { get; set; }
    }
}
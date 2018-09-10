namespace Braspag.Sdk.Contracts.Pagador
{
    public class CaptureRequest
    {
        public long Amount { get; set; }

        public long? ServiceTaxAmount { get; set; }

        public string PaymentId { get; set; }
    }
}
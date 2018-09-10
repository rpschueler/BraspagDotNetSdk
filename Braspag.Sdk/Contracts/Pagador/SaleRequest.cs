namespace Braspag.Sdk.Contracts.Pagador
{
    public class SaleRequest
    {
        public string MerchantOrderId { get; set; }

        public CustomerData Customer { get; set; }

        public PaymentDataRequest Payment { get; set; }
    }
}
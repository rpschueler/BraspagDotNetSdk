namespace Braspag.Sdk.Contracts.Pagador
{
    public class FraudAnalysisShippingDataRequest
    {
        public string Addressee { get; set; }

        public string Phone { get; set; }

        public string Method { get; set; }
    }
}
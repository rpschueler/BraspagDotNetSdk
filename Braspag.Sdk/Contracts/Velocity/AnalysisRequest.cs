namespace Braspag.Sdk.Contracts.Velocity
{
    public class AnalysisRequest
    {
        public TransactionData Transaction { get; set; }

        public CardData Card { get; set; }

        public CustomerData Customer { get; set; }
    }
}
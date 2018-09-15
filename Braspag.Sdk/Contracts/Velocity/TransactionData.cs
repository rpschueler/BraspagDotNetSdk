namespace Braspag.Sdk.Contracts.Velocity
{
    public class TransactionData
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public string Date { get; set; }

        public long Amount { get; set; }
    }
}
namespace Braspag.Sdk.Contracts.Pagador
{
    public class WalletDataRequest
    {
        public string Type { get; set; }

        public string Walletkey { get; set; }

        public WalletAdditionalDataRequest AdditionalData { get; set; }
    }
}
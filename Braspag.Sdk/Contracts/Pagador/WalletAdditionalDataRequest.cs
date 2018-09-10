namespace Braspag.Sdk.Contracts.Pagador
{
    public class WalletAdditionalDataRequest
    {
        public string EphemeralPublicKey { get; set; }

        public string CaptureCode { get; set; }
    }
}
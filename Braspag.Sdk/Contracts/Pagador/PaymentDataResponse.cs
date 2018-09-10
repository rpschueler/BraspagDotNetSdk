using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class PaymentDataResponse
    {
        public string AcquirerTransactionId { get; set; }

        public long Amount { get; set; }

        public string Assignor { get; set; }

        public bool? Authenticate { get; set; }

        public string AuthorizationCode { get; set; }

        public AvsDataRequest Avs { get; set; }

        public string BoletoNumber { get; set; }

        public bool Capture { get; set; }

        public long? CapturedAmount { get; set; }

        public string CapturedDate { get; set; }

        public string Country { get; set; }

        public CredentialsDataRequest Credentials { get; set; }

        public CreditCardData CreditCard { get; set; }

        public string Currency { get; set; }

        public byte? DaysToFine { get; set; }

        public byte? DaysToInterest { get; set; }

        public DebitCardData DebitCard { get; set; }

        public string Demonstrative { get; set; }

        public string Eci { get; set; }

        public string ExpirationDate { get; set; }

        public ExternalAuthenticationDataRequest ExternalAuthentication { get; set; }

        public List<ExtraData> ExtraDataCollection { get; set; }

        public long? FineAmount { get; set; }

        public decimal? FineRate { get; set; }

        public FraudAnalysisRequestData FraudAnalysis { get; set; }

        public string Identification { get; set; }

        public int Installments { get; set; }

        public string Instructions { get; set; }

        public string Interest { get; set; }

        public long? InterestAmount { get; set; }

        public decimal? InterestRate { get; set; }

        public List<LinkData> Links { get; set; }

        public string PaymentId { get; set; }

        public string ProofOfSale { get; set; }

        public string Provider { get; set; }

        public string ProviderReturnCode { get; set; }

        public string ProviderReturnMessage { get; set; }

        public string ReasonCode { get; set; }

        public string ReasonMessage { get; set; }

        public string ReceivedDate { get; set; }

        public bool? Recurrent { get; set; }

        public RecurrentPaymentDataRequest RecurrentPayment { get; set; }

        public string ReturnUrl { get; set; }

        public long ServiceTaxAmount { get; set; }

        public string SoftDescriptor { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public WalletDataRequest Wallet { get; set; }

        public string GetStatusDescription()
        {
            switch (Status)
            {
                case "0":
                    return "NotFinished";
                case "1":
                    return "Authorized";
                case "2":
                    return "PaymentConfirmed";
                case "3":
                    return "Denied";
                case "10":
                    return "Voided";
                case "11":
                    return "Refunded";
                case "12":
                    return "Pending";
                case "13":
                    return "Aborted";
                case "20":
                    return "Scheduled";
                default:
                    return string.Empty;
            }
        }
    }
}
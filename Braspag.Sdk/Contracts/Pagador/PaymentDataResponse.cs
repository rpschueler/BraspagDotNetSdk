using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class PaymentDataResponse
    {
        public string Provider { get; set; }

        public string Type { get; set; }

        public long Amount { get; set; }

        public long ServiceTaxAmount { get; set; }

        public bool Capture { get; set; }

        public int Installments { get; set; }

        public string ProofOfSale { get; set; }

        public string AcquirerTransactionId { get; set; }

        public string AuthorizationCode { get; set; }

        public string PaymentId { get; set; }

        public string ReceivedDate { get; set; }

        public string ReasonCode { get; set; }

        public string ReasonMessage { get; set; }

        public string Status { get; set; }

        public string ProviderReturnCode { get; set; }

        public string ProviderReturnMessage { get; set; }

        public string Interest { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public bool? Authenticate { get; set; }

        public bool? Recurrent { get; set; }

        public string SoftDescriptor { get; set; }

        public string ReturnUrl { get; set; }

        public string BoletoNumber { get; set; }

        public string Assignor { get; set; }

        public string Demonstrative { get; set; }

        public string ExpirationDate { get; set; }

        public string Identification { get; set; }

        public string Instructions { get; set; }

        public byte? DaysToFine { get; set; }

        public decimal? FineRate { get; set; }

        public long? FineAmount { get; set; }

        public byte? DaysToInterest { get; set; }

        public decimal? InterestRate { get; set; }

        public long? InterestAmount { get; set; }

        public CreditCardDataResponse CreditCard { get; set; }

        public DebitCardDataRequest DebitCard { get; set; }

        public WalletDataRequest Wallet { get; set; }

        public CredentialsDataRequest Credentials { get; set; }

        public ExternalAuthenticationDataRequest ExternalAuthentication { get; set; }

        public AvsDataRequest Avs { get; set; }

        public FraudAnalysisRequestData FraudAnalysis { get; set; }

        public RecurrentPaymentDataRequest RecurrentPayment { get; set; }

        public List<ExtraDataRequest> ExtraDataCollection { get; set; }

        public List<LinkDataResponse> Links { get; set; }
    }
}
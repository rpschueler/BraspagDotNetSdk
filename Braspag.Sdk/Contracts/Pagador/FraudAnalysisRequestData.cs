using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class FraudAnalysisRequestData
    {
        public string Sequence { get; set; }

        public string SequenceCriteria { get; set; }

        public string FingerPrintId { get; set; }

        public string Provider { get; set; }

        public bool? CaptureOnLowRisk { get; set; }

        public bool? VoidOnHighRisk { get; set; }

        public long TotalOrderAmount { get; set; }

        public FraudAnalysisBrowserDataRequest Browser { get; set; }

        public FraudAnalysisCartDataRequest Cart { get; set; }

        public List<FraudAnalysisMerchantDefinedFieldsDataRequest> MerchantDefinedFields { get; set; }

        public FraudAnalysisShippingDataRequest Shipping { get; set; }

        public FraudAnalysisTravelDataRequest Travel { get; set; }
    }
}
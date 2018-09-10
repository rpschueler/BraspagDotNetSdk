using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class FraudAnalysisCartDataRequest
    {
        public bool? IsGift { get; set; }

        public bool? ReturnsAccepted { get; set; }

        public List<FraudAnalysisItemDataRequest> Items { get; set; }
    }
}
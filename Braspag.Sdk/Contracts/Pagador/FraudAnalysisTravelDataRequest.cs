using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class FraudAnalysisTravelDataRequest
    {
        public string JourneyType { get; set; }

        public string DepartureDateTime { get; set; }

        public List<FraudAnalysisPassengerDataRequest> Passengers { get; set; }
    }
}
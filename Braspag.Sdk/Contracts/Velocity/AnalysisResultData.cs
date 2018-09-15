using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Velocity
{
    public class AnalysisResultData
    {
        public int Score { get; set; }

        public string Status { get; set; }

        public List<RejectReasonData> RejectReasons { get; set; }

        public bool AcceptByWhiteList { get; set; }

        public bool RejectByBlackList { get; set; }
    }
}
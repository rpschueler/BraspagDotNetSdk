using System.Net;

namespace Braspag.Sdk.Contracts.Velocity
{
    public class AnalysisResponse
    {
        public HttpStatusCode HttpStatus { get; set; }

        public AnalysisResultData AnalysisResult { get; set; }

        public TransactionData Transaction { get; set; }
    }
}
using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatus { get; set; }

        public string CorrelationId { get; set; }

        /// <summary>
        /// ErrorReportCollection
        /// </summary>
        public List<ErrorData> ErrorDataCollection { get; set; }
    }
}

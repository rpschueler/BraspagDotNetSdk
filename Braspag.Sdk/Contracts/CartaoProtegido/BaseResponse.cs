using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class BaseResponse
    {
        public Guid? CorrelationId { get; set; }

        public HttpStatusCode HttpStatus { get; set; }

        [DeserializeAs(Name = "ErrorReportCollection")]
        public List<ErrorData> ErrorDataCollection { get; set; }
    }
}

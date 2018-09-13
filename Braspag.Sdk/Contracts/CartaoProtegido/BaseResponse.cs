using RestSharp.Deserializers;
using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatus { get; set; }

        [DeserializeAs(Name = "ErrorReportCollection")]
        public List<ErrorData> ErrorDataCollection { get; set; }
    }
}

using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class SaleResponse
    {
        public HttpStatusCode HttpStatus { get; set; }

        public List<Error> ErrorDataCollection { get; set; }
    }
}
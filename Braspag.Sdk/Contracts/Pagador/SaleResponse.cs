using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class SaleResponse
    {
        public string MerchantOrderId { get; set; }

        public CustomerDataResponse Customer { get; set; }

        public HttpStatusCode HttpStatus { get; set; }

        public List<Error> ErrorDataCollection { get; set; }
    }
}
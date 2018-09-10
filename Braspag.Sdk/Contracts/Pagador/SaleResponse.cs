using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class SaleResponse
    {
        public CustomerData Customer { get; set; }

        public List<ErrorData> ErrorDataCollection { get; set; }

        public HttpStatusCode HttpStatus { get; set; }

        public string MerchantOrderId { get; set; }

        public PaymentDataResponse Payment { get; set; }
    }
}
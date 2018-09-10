using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class SaleResponse
    {
        public CustomerData Customer { get; set; }

        public List<ErrorData> ErrorDataCollection { get; set; }

        /// <summary>
        /// Código do status HTTP da requisição
        /// </summary>
        public HttpStatusCode HttpStatus { get; set; }

        /// <summary>
        /// Número de identificação do Pedido na loja
        /// </summary>
        public string MerchantOrderId { get; set; }

        public PaymentDataResponse Payment { get; set; }
    }
}
using System.Collections.Generic;
using System.Net;

namespace Braspag.Sdk.Contracts.Pagador
{
    public class VoidResponse
    {
        public List<ErrorData> ErrorDataCollection { get; set; }

        /// <summary>
        /// Código do status HTTP da requisição
        /// </summary>
        public HttpStatusCode HttpStatus { get; set; }

        /// <summary>
        /// Código retornado pelo provedor do meio de pagamento (adquirente e bancos)
        /// </summary>
        public string ProviderReturnCode { get; set; }

        /// <summary>
        /// Mensagem retornada pelo provedor do meio de pagamento (adquirente e bancos)
        /// </summary>
        public string ProviderReturnMessage { get; set; }

        /// <summary>
        /// Código de retorno da Operação
        /// </summary>
        public string ReasonCode { get; set; }

        /// <summary>
        /// Mensagem de retorno da Operação
        /// </summary>
        public string ReasonMessage { get; set; }

        /// <summary>
        /// Status da Transação
        /// </summary>
        public TransactionStatus Status { get; set; }
    }
}
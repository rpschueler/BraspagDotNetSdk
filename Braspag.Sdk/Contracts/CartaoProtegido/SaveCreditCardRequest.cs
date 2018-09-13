using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class SaveCreditCardRequest : BaseRequest
    {
        public string CustomerIdentification { get; set; }

        public string CustomerName { get; set; }

        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public string CardExpiration { get; set; }

        public string JustClickAlias { get; set; }

        public List<ExtraData> DataCollection { get; set; }
    }
}
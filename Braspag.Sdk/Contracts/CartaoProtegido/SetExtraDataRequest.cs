using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class SetExtraDataRequest : BaseRequest
    {
        public string JustClickKey { get; set; }

        public string JustClickAlias { get; set; }

        public List<ExtraData> DataCollection { get; set; }
    }
}
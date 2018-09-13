using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class GetExtraDataResponse : BaseResponse
    {
        public List<ExtraData> ExtraDataCollection { get; set; }
    }
}
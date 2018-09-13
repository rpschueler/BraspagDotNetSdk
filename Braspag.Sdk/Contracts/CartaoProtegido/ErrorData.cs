using RestSharp.Deserializers;

namespace Braspag.Sdk.Contracts.CartaoProtegido
{
    public class ErrorData
    {
        [DeserializeAs(Name = "ErrorCode")]
        public int Code { get; set; }

        [DeserializeAs(Name = "ErrorMessage")]
        public string Message { get; set; }
    }
}
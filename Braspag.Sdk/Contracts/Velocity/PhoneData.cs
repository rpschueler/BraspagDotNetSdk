using RestSharp.Serializers;

namespace Braspag.Sdk.Contracts.Velocity
{
    public class PhoneData
    {
        /// <summary>
        /// Valores possíveis: Phone, Workphone, Cellphone
        /// </summary>
        public string Type { get; set; }

        [SerializeAs(Name = "DDI")]
        public string Ddi { get; set; }

        [SerializeAs(Name = "DDD")]
        public string Ddd { get; set; }

        public string Number { get; set; }

        public string Extension { get; set; }
    }
}
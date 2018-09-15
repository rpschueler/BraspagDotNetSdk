using System.Collections.Generic;

namespace Braspag.Sdk.Contracts.Velocity
{
    public class CustomerData
    {
        public string Name { get; set; }

        public string Identity { get; set; }

        public string IpAddress { get; set; }

        public string BirthDate { get; set; }

        public string Email { get; set; }

        public List<PhoneData> Phones { get; set; }

        public AddressData Billing { get; set; }

        public AddressData Shipping { get; set; }
    }
}
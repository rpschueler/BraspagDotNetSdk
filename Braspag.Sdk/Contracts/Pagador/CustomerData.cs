namespace Braspag.Sdk.Contracts.Pagador
{
    public class CustomerData
    {
        public string Name { get; set; }

        public string Identity { get; set; }

        public string IdentityType { get; set; }

        public string Email { get; set; }

        public string Birthdate { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public AddressData Address { get; set; }

        public AddressData DeliveryAddress { get; set; }
    }
}
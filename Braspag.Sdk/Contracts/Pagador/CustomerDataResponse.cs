namespace Braspag.Sdk.Contracts.Pagador
{
    public class CustomerDataResponse
    {
        public string Name { get; set; }

        public string Identity { get; set; }

        public string IdentityType { get; set; }

        public string Email { get; set; }

        public string Birthdate { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public AddressDataResponse Address { get; set; }

        public AddressDataResponse DeliveryAddress { get; set; }
    }
}
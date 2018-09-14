using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.Velocity;

namespace Braspag.Sdk.Velocity
{
    public class VelocityClientOptions : ClientOptions
    {
        public MerchantCredentials Credentials { get; set; }
    }
}
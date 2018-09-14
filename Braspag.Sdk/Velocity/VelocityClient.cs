using System;
using System.Threading.Tasks;
using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.Velocity;
using RestSharp;
using RestSharp.Deserializers;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.Velocity
{
    public class VelocityClient : IVelocityClient
    {
        private readonly MerchantCredentials _credentials;

        private VelocityClientOptions _options;

        public IRestClient RestClient { get; }

        public IDeserializer JsonDeserializer { get; }

        public VelocityClient(VelocityClientOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _credentials = options.Credentials;
            RestClient = _options.Environment == Environment.Production ? new RestClient { BaseUrl = new Uri(Endpoints.VelocityApiProduction) } : new RestClient { BaseUrl = new Uri(Endpoints.VelocityApiSandbox) };
            JsonDeserializer = new JsonDeserializer();
        }

        public Task<AnalysisResponse> PerformAnalysisAsync(AnalysisRequest request, MerchantCredentials credentials = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
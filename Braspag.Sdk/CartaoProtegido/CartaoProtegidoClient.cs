using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.CartaoProtegido;
using RestSharp;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.CartaoProtegido
{
    public class CartaoProtegidoClient : ICartaoProtegidoClient
    {
        private readonly MerchantCredentials _credentials;

        private CartaoProtegidoClientOptions _options;

        public IRestClient RestClient { get; }

        public CartaoProtegidoClient(CartaoProtegidoClientOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _credentials = options.Credentials;
            RestClient = _options.Environment == Environment.Production ? new RestClient { BaseUrl = new Uri(Endpoints.CartaoProtegidoProduction) } : new RestClient { BaseUrl = new Uri(Endpoints.CartaoProtegidoSandbox) };
            //JsonDeserializer = new JsonDeserializer();
        }

        public async Task<GetCreditCardResponse> GetCreditCardAsync(GetCreditCardRequest request, MerchantCredentials credentials = null)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (_credentials == null && credentials == null)
                throw new InvalidOperationException("Credentials are null");

            var currentCredentials = credentials ?? _credentials;

            if (string.IsNullOrWhiteSpace(currentCredentials.MerchantKey))
                throw new InvalidOperationException("Invalid credentials: MerchantKey is null");

            var httpRequest = new RestRequest(@"v2/cartaoprotegido.asmx", Method.POST)
            {
                RequestFormat = DataFormat.Xml,
                XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer()
            };

            httpRequest.AddHeader("Content-Type", "text/xml");
            httpRequest.AddBody(request);


            //httpRequest.AddHeader("MerchantKey", currentCredentials.MerchantKey);

            //var sb = new StringBuilder();
            //sb.AppendFormat("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            //sb.AppendFormat("<soap:Body>");


            var cancellationTokenSource = new CancellationTokenSource();

            var httpResponse = await RestClient.ExecuteTaskAsync(httpRequest, cancellationTokenSource.Token);

            throw new System.NotImplementedException();
        }
    }
}
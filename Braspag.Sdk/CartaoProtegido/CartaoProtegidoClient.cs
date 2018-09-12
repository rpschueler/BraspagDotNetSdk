using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.CartaoProtegido;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Braspag.Sdk.Contracts.Pagador;
using RestSharp.Deserializers;
using Environment = Braspag.Sdk.Common.Environment;
using MerchantCredentials = Braspag.Sdk.Contracts.CartaoProtegido.MerchantCredentials;

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
                XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer(),
                XmlNamespace = "http://www.cartaoprotegido.com.br/WebService/"
            };

            //httpRequest.AddHeader("Content-Type", "text/xml");

            var sb = new StringBuilder();
            sb.AppendLine("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            sb.AppendLine("<soap:Body>");
            sb.AppendLine("<GetCreditCard xmlns=\"http://www.cartaoprotegido.com.br/WebService/\">");
            sb.AppendLine("<getCreditCardRequestWS>");
            sb.AppendLine($"<MerchantKey>{currentCredentials.MerchantKey}</MerchantKey>");
            sb.AppendLine($"<JustClickKey>{request.JustClickKey}</JustClickKey>");
            sb.AppendLine($"<JustClickAlias>{request.JustClickAlias}</JustClickAlias>");
            sb.AppendLine("</getCreditCardRequestWS>");
            sb.AppendLine("</GetCreditCard>");
            sb.AppendLine("</soap:Body>");
            sb.AppendLine("</soap:Envelope>");

            httpRequest.AddParameter("text/xml", sb.ToString(), ParameterType.RequestBody);

            var cancellationTokenSource = new CancellationTokenSource();

            var httpResponse = await RestClient.ExecuteTaskAsync(httpRequest, cancellationTokenSource.Token);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new System.NotImplementedException();
            }

            IDeserializer teste = new XmlDeserializer();

            var jsonResponse = teste.Deserialize<GetCreditCardResponse>(httpResponse);
            //jsonResponse.HttpStatus = httpResponse.StatusCode;
            return jsonResponse;
        }
    }
}
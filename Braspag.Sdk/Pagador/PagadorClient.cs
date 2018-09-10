using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.Pagador;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.Pagador
{
    public class PagadorClient : IPagadorClient
    {
        private readonly MerchantCredentials _credentials = null;

        private PagadorClientOptions _options = null;

        public IRestClient RestClient { get; }

        public IDeserializer JsonDeserializer { get; }

        public PagadorClient(PagadorClientOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _credentials = options.Credentials;
            RestClient = _options.Environment == Environment.Production ? new RestClient { BaseUrl = new Uri(Endpoints.PagadorApiProduction) } : new RestClient { BaseUrl = new Uri(Endpoints.PagadorApiSandbox) };
            JsonDeserializer = new JsonDeserializer();
        }

        public async Task<SaleResponse> CreateSaleAsync(SaleRequest request, MerchantCredentials credentials = null)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (_credentials == null && credentials == null)
                throw new InvalidOperationException("Credentials are null");

            var currentCredentials = credentials ?? _credentials;

            if (string.IsNullOrWhiteSpace(currentCredentials.MerchantId))
                throw new InvalidOperationException("Invalid credentials: MerchantId is null");

            if (string.IsNullOrWhiteSpace(currentCredentials.MerchantKey))
                throw new InvalidOperationException("Invalid credentials: MerchantKey is null");

            var httpRequest = new RestRequest(@"v2/sales/", Method.POST) { RequestFormat = DataFormat.Json };
            httpRequest.AddHeader("Content-Type", "application/json");
            httpRequest.AddHeader("MerchantId", currentCredentials.MerchantId);
            httpRequest.AddHeader("MerchantKey", currentCredentials.MerchantKey);
            httpRequest.AddHeader("RequestId", Guid.NewGuid().ToString());
            httpRequest.AddBody(new { request.MerchantOrderId, request.Customer, request.Payment });

            var cancellationTokenSource = new CancellationTokenSource();

            var httpResponse = await RestClient.ExecuteTaskAsync(httpRequest, cancellationTokenSource.Token);

            if (httpResponse.StatusCode == HttpStatusCode.Created)
            {
                return JsonDeserializer.Deserialize<SaleResponse>(httpResponse);
            }

            return new SaleResponse
            {
                HttpStatus = httpResponse.StatusCode,
                ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(httpResponse)
            };
        }

        public Task<CaptureResponse> CaptureAsync(CaptureRequest request, MerchantCredentials credentials = null)
        {
            throw new NotImplementedException();
        }

        public Task<VoidResponse> VoidAsync(VoidRequest request, MerchantCredentials credentials = null)
        {
            throw new NotImplementedException();
        }

        public Task<SaleResponse> GetAsync(Guid paymentId, MerchantCredentials credentials = null)
        {
            throw new NotImplementedException();
        }
    }
}
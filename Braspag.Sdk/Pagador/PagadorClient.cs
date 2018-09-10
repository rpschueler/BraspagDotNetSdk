﻿using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.Pagador;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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

            if (httpResponse.StatusCode != HttpStatusCode.Created)
            {
                return new SaleResponse
                {
                    HttpStatus = httpResponse.StatusCode,
                    ErrorDataCollection = JsonDeserializer.Deserialize<List<ErrorData>>(httpResponse)
                };
            }

            var jsonResponse = JsonDeserializer.Deserialize<SaleResponse>(httpResponse);
            jsonResponse.HttpStatus = httpResponse.StatusCode;
            return jsonResponse;
        }

        public async Task<CaptureResponse> CaptureAsync(CaptureRequest request, MerchantCredentials credentials = null)
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

            var httpRequest = new RestRequest(@"v2/sales/{paymentId}/capture", Method.PUT) { RequestFormat = DataFormat.Json };
            httpRequest.AddHeader("Content-Type", "application/json");
            httpRequest.AddHeader("MerchantId", currentCredentials.MerchantId);
            httpRequest.AddHeader("MerchantKey", currentCredentials.MerchantKey);
            httpRequest.AddHeader("RequestId", Guid.NewGuid().ToString());
            httpRequest.AddUrlSegment("paymentId", request.PaymentId);
            httpRequest.AddQueryParameter("amount", request.Amount.ToString(CultureInfo.InvariantCulture));

            if (request.ServiceTaxAmount.HasValue)
            {
                httpRequest.AddQueryParameter("serviceTaxAmount", request.ServiceTaxAmount.Value.ToString(CultureInfo.InvariantCulture));
            }

            var cancellationTokenSource = new CancellationTokenSource();

            var httpResponse = await RestClient.ExecuteTaskAsync(httpRequest, cancellationTokenSource.Token);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                return new CaptureResponse
                {
                    HttpStatus = httpResponse.StatusCode,
                    ErrorDataCollection = JsonDeserializer.Deserialize<List<ErrorData>>(httpResponse)
                };
            }

            var jsonResponse = JsonDeserializer.Deserialize<CaptureResponse>(httpResponse);
            jsonResponse.HttpStatus = httpResponse.StatusCode;
            return jsonResponse;
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
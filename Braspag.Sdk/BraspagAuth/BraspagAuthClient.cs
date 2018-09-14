using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Braspag.Sdk.Common;
using Braspag.Sdk.Contracts.BraspagAuth;
using Braspag.Sdk.Contracts.Pagador;
using RestSharp;
using RestSharp.Deserializers;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.BraspagAuth
{
    public class BraspagAuthClient : IBraspagAuthClient
    {
        private BraspagAuthClientOptions _options;

        public IRestClient RestClient { get; }

        public IDeserializer JsonDeserializer { get; }

        public BraspagAuthClient(BraspagAuthClientOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            RestClient = _options.Environment == Environment.Production ? new RestClient { BaseUrl = new Uri(Endpoints.BraspagAuthProduction) } : new RestClient { BaseUrl = new Uri(Endpoints.BraspagAuthSandbox) };
            JsonDeserializer = new JsonDeserializer();
        }

        public async Task<AccessTokenResponse> CreateAccessTokenAsync(AccessTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.ClientId))
                throw new InvalidOperationException("Invalid credentials: ClientId is null or empty");

            if (string.IsNullOrWhiteSpace(request.ClientSecret))
                throw new InvalidOperationException("Invalid credentials: ClientSecret is null or empty");

            var credentials = Base64Encode($"{request.ClientId}:{request.ClientSecret}");

            var httpRequest = new RestRequest(@"oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };
            httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            httpRequest.AddHeader("Authorization", $"Basic {credentials}");

            httpRequest.AddParameter("application/x-www-form-urlencoded", $"grant_type={request.GrantType.GetAttributeOfType<DescriptionAttribute>().Description}", ParameterType.RequestBody);

            var cancellationTokenSource = new CancellationTokenSource();

            var httpResponse = await RestClient.ExecuteTaskAsync(httpRequest, cancellationTokenSource.Token);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                return new AccessTokenResponse
                {
                    HttpStatus = httpResponse.StatusCode,
                    //ErrorDataCollection = JsonDeserializer.Deserialize<List<ErrorData>>(httpResponse)
                };
            }

            var jsonResponse = JsonDeserializer.Deserialize<AccessTokenResponse>(httpResponse);
            jsonResponse.HttpStatus = httpResponse.StatusCode;
            return jsonResponse;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
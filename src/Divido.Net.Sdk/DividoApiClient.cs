using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models;

namespace Divido.Net.Sdk
{
    public class DividoApiClient : IDividoApi
    {
        private readonly IApiClient _apiClient;
        private readonly string _apiKey;

        public DividoApiClient(
            IApiClient apiClient,
            string apiKey)
        {
            _apiClient = apiClient;
            _apiKey = apiKey;
        }

        public async Task<FinancesResponse> GetFinancePlans(CancellationToken token)
        {
            var endpoint = $"v1/finances?merchant={_apiKey}";

            return await _apiClient.GetAsync<FinancesResponse>(
                endpoint,
                token);
        }

        public async Task<CreditRequestResponse> CreditRequest(CreditRequest creditRequest, CancellationToken token)
        {
            var endpoint = $"v1/creditrequest";

            var request = new[]
            {
                new KeyValuePair<string, string>("merchant", _apiKey),
                new KeyValuePair<string, string>("deposit", creditRequest.Deposit.ToString("F")),
                new KeyValuePair<string, string>("finance", creditRequest.FinanceId),
                new KeyValuePair<string, string>("directSign", creditRequest.DirectSign.ToString()),
                new KeyValuePair<string, string>("country", creditRequest.Country),
                new KeyValuePair<string, string>("language", creditRequest.Language),
                new KeyValuePair<string, string>("currency", creditRequest.Currency),
                new KeyValuePair<string, string>("amount", creditRequest.Amount.ToString("F")),
                new KeyValuePair<string, string>("reference", creditRequest.Reference),
            };

            return await _apiClient.PostAsync<CreditRequestResponse>(
                endpoint, 
                request, 
                token);
        }
    }
}
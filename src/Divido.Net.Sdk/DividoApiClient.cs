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

        public async Task<FinancesResponse> GetFinancePlans(CancellationToken cancel)
        {
            var endpoint = $"v1/finances?merchant={_apiKey}";

            return await _apiClient.GetAsync<FinancesResponse>(
                endpoint,
                cancel);
        }
    }
}
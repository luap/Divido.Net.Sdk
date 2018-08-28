using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models;
using Newtonsoft.Json;

namespace Divido.Net.Sdk
{
    public class DividoApiHttpClient : IDividoApi
    {
        private readonly HttpClient _httpClient;

        public DividoApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FinancesResponse> GetFinances()
        {
            var endpoint = "finances";

            try
            {
                using (var response = await _httpClient.GetAsync(endpoint, CancellationToken.None))
                {
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    var financeResponse = JsonConvert.DeserializeObject<FinancesResponse>(content);

                    return financeResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }
    }
}
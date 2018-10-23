using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models.CreditRequest;
using Divido.Net.Sdk.Models.DealCalculator;
using Divido.Net.Sdk.Models.Finances;
using Divido.Net.Sdk.Models.WebHooks;

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

        public async Task<DealsResponse> GetDeals(DealsRequest dealsRequest, CancellationToken token)
        {
            var endpoint = $"v1/dealcalculator?merchant={_apiKey}&amount={dealsRequest.Amount}&deposit={dealsRequest.Deposit}&country={dealsRequest.Country}&finance={dealsRequest.FinanceId}";

            return await _apiClient.GetAsync<DealsResponse>(
                endpoint,
                token);
        }

        public async Task<CreditRequestResponse> CreditRequest(CreditRequest creditRequest, CancellationToken token)
        {
            var endpoint = $"v1/creditrequest";

            var request = BuildRequestParameters(creditRequest);

            return await _apiClient.PostAsync<CreditRequestResponse>(
                endpoint,
                request,
                token);
        }

        public WebHookEvent Deserialize(string json)
        {
            return _apiClient.Deserialize<WebHookEvent>(json);
        }

        public List<KeyValuePair<string, string>> BuildRequestParameters(CreditRequest creditRequest)
        {
            var request = new[]
            {
                new KeyValuePair<string, string>("merchant", _apiKey),
                new KeyValuePair<string, string>("deposit", creditRequest.Deposit.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("finance", creditRequest.FinanceId),
                new KeyValuePair<string, string>("directSign", creditRequest.DirectSign.ToString()),
                new KeyValuePair<string, string>("country", creditRequest.Country),
                new KeyValuePair<string, string>("language", creditRequest.Language),
                new KeyValuePair<string, string>("currency", creditRequest.CurrencyCode),
                new KeyValuePair<string, string>("amount", creditRequest.Amount.ToString(CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("reference", creditRequest.Reference),
                new KeyValuePair<string, string>("responseUrl", creditRequest.ResponseUri?.AbsoluteUri),
                new KeyValuePair<string, string>("checkoutUrl", creditRequest.CheckoutUri?.AbsoluteUri),
                new KeyValuePair<string, string>("redirectUrl", creditRequest.RedirectUri?.AbsoluteUri),
            }.ToList();

            AddCustomer(ref request, creditRequest);
            AddProducts(ref request, creditRequest.Products);

            return request;
        }

        private void AddProducts(ref List<KeyValuePair<string, string>> request, List<Product> products)
        {
            for (var i = 0; i < products.Count; i++)
            {
                var index = i + 1;
                request.Add(new KeyValuePair<string, string>($"products[{index}][name]", products[i].Name));
                request.Add(new KeyValuePair<string, string>($"products[{index}][sku]", products[i].Sku));
                request.Add(new KeyValuePair<string, string>($"products[{index}][price]", products[i].Price.ToString(CultureInfo.InvariantCulture)));
                request.Add(new KeyValuePair<string, string>($"products[{index}][quantity]", products[i].Quantity.ToString()));
                request.Add(new KeyValuePair<string, string>($"products[{index}][vat]", products[i].Vat.ToString(CultureInfo.InvariantCulture)));
            }
        }

        private void AddCustomer(ref List<KeyValuePair<string, string>> request, CreditRequest creditRequest)
        {
            request.Add(new KeyValuePair<string, string>("customer[firstName]", creditRequest.Customer?.FirstName));
            request.Add(new KeyValuePair<string, string>("customer[lastName]", creditRequest.Customer?.LastName));
            request.Add(new KeyValuePair<string, string>("customer[email]", creditRequest.Customer?.Email));
            request.Add(new KeyValuePair<string, string>("customer[phoneNumber]", creditRequest.Customer?.PhoneNumber));
            request.Add(new KeyValuePair<string, string>("customer[gender]", creditRequest.Customer?.Gender != null ? creditRequest.Customer.Gender.Value == Gender.Male ? "male" : "female" : ""));
            request.Add(new KeyValuePair<string, string>("customer[address][postcode]", creditRequest.Customer?.Address?.PostCode));
            request.Add(new KeyValuePair<string, string>("customer[address][street]", creditRequest.Customer?.Address?.Street));
            request.Add(new KeyValuePair<string, string>("customer[address][flat]", creditRequest.Customer?.Address?.Flat));
            request.Add(new KeyValuePair<string, string>("customer[address][buildingNumber]", creditRequest.Customer?.Address?.BuildingNumber));
            request.Add(new KeyValuePair<string, string>("customer[address][buildingName]", creditRequest.Customer?.Address?.BuildingNumber));
            request.Add(new KeyValuePair<string, string>("customer[address][town]", creditRequest.Customer?.Address?.Town));
            request.Add(new KeyValuePair<string, string>("customer[address][monthsAtAddress]", creditRequest.Customer?.Address?.MonthsAtAddress != null ? creditRequest.Customer.Address.MonthsAtAddress.ToString() : ""));
        }
    }
}
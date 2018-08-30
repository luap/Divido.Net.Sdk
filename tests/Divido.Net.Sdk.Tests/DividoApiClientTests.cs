using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models;
using Moq;
using NUnit.Framework;

namespace Divido.Net.Sdk.Tests
{
    public class DividoApiClientTests
    {
        [Test]
        public async Task GivenAnApiClientAndKey_WhenGetFinancePlansIsCalled_ThenGetAsyncIsCalledWithEndpoint()
        {
            var apiKey = "abc";
            var expectedEndpoint = $"v1/finances?merchant={apiKey}";

            var apiClient = new Mock<IApiClient>();

            apiClient.Setup(x =>
                x.GetAsync<FinancesResponse>(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(new FinancesResponse());

            var dividoApiHttpClient = new DividoApiClient(apiClient.Object, apiKey);

            await dividoApiHttpClient.GetFinancePlans(CancellationToken.None);

            apiClient.Verify(x => 
                x.GetAsync<FinancesResponse>(
                    expectedEndpoint, 
                    CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task GivenADealsRequest_WhenGetDealsIsCalled_ThenGetAsyncIsCalledWithEndpoint()
        {
            var apiKey = "abc";

            var dealsRequest = new DealsRequest
            {
                FinanceId = "someid",
                Amount = 123m,
                Deposit = 10m
            };

            var expectedEndpoint = $"v1/dealcalculator?merchant={apiKey}&amount={dealsRequest.Amount}&deposit={dealsRequest.Deposit}&country=GB&finance={dealsRequest.FinanceId}";

            var apiClient = new Mock<IApiClient>();

            apiClient.Setup(x =>
                x.GetAsync<DealsResponse>(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(new DealsResponse());

            var dividoApiHttpClient = new DividoApiClient(apiClient.Object, apiKey);

            await dividoApiHttpClient.GetDeals(dealsRequest, CancellationToken.None);

            apiClient.Verify(x =>
                x.GetAsync<DealsResponse>(
                    expectedEndpoint,
                    CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task GivenACreditRequest_WhenCreditRequestIsCalled_ThenPostAsyncIsCalledWithEndpoint()
        {
            var apiKey = "abc";
            var expectedEndpoint = $"v1/creditrequest";

            var apiClient = new Mock<IApiClient>();

            apiClient.Setup(x =>
                x.PostAsync<CreditRequestResponse>(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(new CreditRequestResponse());

            var dividoApiHttpClient = new DividoApiClient(apiClient.Object, apiKey);

            await dividoApiHttpClient.CreditRequest(new CreditRequest(), CancellationToken.None);

            apiClient.Verify(x => 
                x.PostAsync<CreditRequestResponse>(
                    expectedEndpoint,
                    It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                    CancellationToken.None), Times.Once);
        }
    }
}

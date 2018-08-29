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

            apiClient.Verify(x => x.GetAsync<FinancesResponse>(expectedEndpoint, CancellationToken.None), Times.Once);
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Divido.Net.Sdk.Tests
{
    public class DividoApiHttpClientTests
    {
        [Test]
        public async Task GivenAHttpClient_WhenGetFinancesIsCalled_ThenShitHappens()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://secure.sandbox.divido.com")
            };

            var dividoApiHttpClient = new DividoApiHttpClient(httpClient);

            var result = await dividoApiHttpClient.GetFinances();

            result.Status.Should().Be("ok");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Tests.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Divido.Net.Sdk.Tests
{
    class HttpClientApiTests
    {
        [Test]
        public async Task GivenAnEndpoint_WhenCallingGetAsync_ThenAGetMethodIsMade()
        {
            var handler = new TestHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<SomeTestResponse>(new SomeTestResponse(), new JsonMediaTypeFormatter())
            });

            var client = CreateClient(handler);

            await client.GetAsync<SomeTestResponse>("endpoint", CancellationToken.None);

            handler.ReceivedRequests
                .First()
                .Method
                .Should()
                .Be(HttpMethod.Get);
        }

        [Test]
        public async Task GivenAnEndpoint_WhenCallingGetAsync_ThenTheGivenEndpointIsCalled()
        {
            var handler = new TestHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<SomeTestResponse>(new SomeTestResponse(), new JsonMediaTypeFormatter())
            });

            var client = CreateClient(handler);

            var endpoint = "/endpoint";

            await client.GetAsync<SomeTestResponse>(endpoint, CancellationToken.None);

            handler.ReceivedRequests
                .First()
                .RequestUri
                .AbsolutePath
                .Should()
                .Be(endpoint);
        }

        [Test]
        public async Task GivenAnEndpointAndPostObject_WhenCallingPostAsync_ThenTheGivenEndpointIsCalled()
        {
            var handler = new TestHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<SomeTestResponse>(new SomeTestResponse(), new JsonMediaTypeFormatter())
            });

            var client = CreateClient(handler);

            var endpoint = "/endpoint";

            await client.PostAsync<SomeTestResponse>(endpoint, new Dictionary<string, string>(), CancellationToken.None);

            handler.ReceivedRequests
                .First()
                .RequestUri
                .AbsolutePath
                .Should()
                .Be(endpoint);
        }

        [Test]
        public async Task GivenAnEndpointAndPostObject_WhenCallingPostAsync_ThenAPostMethodIsMade()
        {
            var handler = new TestHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<SomeTestResponse>(new SomeTestResponse(), new JsonMediaTypeFormatter())
            });

            var client = CreateClient(handler);

            await client.PostAsync<SomeTestResponse>("endpoint", new Dictionary<string, string>(), CancellationToken.None);

            handler.ReceivedRequests
                .First()
                .Method
                .Should()
                .Be(HttpMethod.Post);
        }

        private static HttpApiClient CreateClient(HttpMessageHandler handler)
        {
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://website.any")
            };

            return new HttpApiClient(httpClient);
        }
    }

    internal class SomeTestResponse
    {
        public string Foo { get; set; }
    }
}

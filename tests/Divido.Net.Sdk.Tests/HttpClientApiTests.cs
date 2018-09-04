using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models.WebHooks;
using Divido.Net.Sdk.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
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

        [Test]
        public void GivenAWebHookJsonString_WhenCallingDeserialize_ThenAWebHookObjectIsReturned()
        {
            var webHookEvent =
                "{\r\n    \"event\": \"application-status-update\",\r\n    \"status\": \"READY\",\r\n    \"name\": \"Fred Chapstick\",\r\n    \"firstName\": \"Fred\",\r\n    \"lastName\": \"Chapstick\",\r\n    \"email\": \"test@gtest.com\",\r\n    \"phoneNumber\": \"283479283478237\",\r\n    \"proposal\": \"4a561141-e061-4506-a1a9-10c2d276927c\",\r\n    \"application\": \"4a561141-e061-4506-a1a9-10c2d276927c\",\r\n    \"reference\": \"8a1b6aa8-db21-49f1-a734-563cb768db4e\",\r\n    \"metadata\": [{ \"Invoice Number\": \"844001\" }]\r\n}";

            var handler = new TestHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<SomeTestResponse>(new SomeTestResponse(), new JsonMediaTypeFormatter())
            });

            var client = CreateClient(handler);

            var result = client.Deserialize<WebHookEvent>(webHookEvent);

            using (new AssertionScope())
            {
                result.Event.Should().Be("application-status-update");
                result.Status.Should().Be("READY");
                result.Name.Should().Be("Fred Chapstick");
                result.Email.Should().Be("test@gtest.com");
                result.Application.Should().Be("4a561141-e061-4506-a1a9-10c2d276927c");
                result.FirstName.Should().Be("Fred");
                result.LastName.Should().Be("Chapstick");
                result.PhoneNumber.Should().Be("283479283478237");
                result.Proposal.Should().Be("4a561141-e061-4506-a1a9-10c2d276927c");
                result.Reference.Should().Be("8a1b6aa8-db21-49f1-a734-563cb768db4e");
            }
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

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Divido.Net.Sdk.Tests.Helpers
{
    public class TestHandler : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handleFunction;
        public List<HttpRequestMessage> ReceivedRequests = new List<HttpRequestMessage>();

        public TestHandler(Func<HttpRequestMessage, HttpResponseMessage> handleFunction)
        {
            _handleFunction = handleFunction;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ReceivedRequests.Add(request);
            return Task.FromResult(_handleFunction(request));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Divido.Net.Sdk
{
    public class HttpApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public HttpApiClient(HttpClient client)
        {
            _client = client;
        }

        public Task<TOk> PostAsync<TOk>(
            string endpoint,
            IEnumerable<KeyValuePair<string, string>> content,
            CancellationToken cancel)
        {
            return BuildAndSend(Deserialize<TOk>, HttpMethod.Post, endpoint, content, cancel);
        }

        public Task<TOk> GetAsync<TOk>(
            string endpoint,
            CancellationToken cancel)
        {
            return BuildAndSend(Deserialize<TOk>, HttpMethod.Get, endpoint, cancel);
        }

        private async Task<TOk> BuildAndSend<TOk>(
            Func<string, TOk> deserialize,
            HttpMethod method,
            string endpoint,
            CancellationToken cancel)
        {
            using (var request = new HttpRequestMessage(method, endpoint))
            {
                return await SendAsync(deserialize, request, cancel);
            }
        }

        private async Task<TOk> BuildAndSend<TOk>(
            Func<string, TOk> deserialize,
            HttpMethod method,
            string endpoint,
            IEnumerable<KeyValuePair<string, string>> content,
            CancellationToken cancel)
        {
            using (var request = new HttpRequestMessage(method, endpoint))
            {
                request.Content = new FormUrlEncodedContent(content);

                return await SendAsync(deserialize, request, cancel);
            }
        }

        private async Task<TOk> SendAsync<TOk>(
            Func<string, TOk> deserialize,
            HttpRequestMessage request,
            CancellationToken cancel)
        {
            using (var response = await _client.SendAsync(request, cancel))
            {
                var json = await response.Content.ReadAsStringAsync();

                return deserialize(json);
            }
        }

        private TOk Deserialize<TOk>(string json)
        {
            var deserialized = JsonConvert.DeserializeObject<TOk>(json);

            if (deserialized != null)
            {
                return deserialized;
            }

            throw new Exception("Failed to DeserializeObject");
        }
    }
}
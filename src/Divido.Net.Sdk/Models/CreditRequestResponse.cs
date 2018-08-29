using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models
{
    public class CreditRequestResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Divido.Net.Sdk.Models.WebHooks
{
    public class WebHookEvent
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("proposal")]
        public Guid Proposal { get; set; }

        [JsonProperty("application")]
        public Guid Application { get; set; }

        [JsonProperty("reference")]
        public Guid Reference { get; set; }

        [JsonProperty("metadata")]
        public object[] Metadata { get; set; }
    }
}

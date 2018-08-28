using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models
{
    public class Finance
    {
        [JsonProperty("agreement_duration")]
        public long AgreementDuration { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("deferral_period")]
        public long DeferralPeriod { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("instalment_fee")]
        public long InstalmentFee { get; set; }

        [JsonProperty("interest_rate")]
        public long InterestRate { get; set; }

        [JsonProperty("max_deposit")]
        public long MaxDeposit { get; set; }

        [JsonProperty("min_amount")]
        public long MinAmount { get; set; }

        [JsonProperty("min_deposit")]
        public long MinDeposit { get; set; }

        [JsonProperty("setup_fee")]
        public long SetupFee { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}

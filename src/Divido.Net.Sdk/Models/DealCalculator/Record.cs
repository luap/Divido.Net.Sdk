using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class Record
    {
        [JsonProperty("interest_rate_percentage")]
        public long InterestRatePercentage { get; set; }

        [JsonProperty("nominal_interest_rate_percentage")]
        public long NominalInterestRatePercentage { get; set; }

        [JsonProperty("compounded_interest_rate_percentage")]
        public long CompoundedInterestRatePercentage { get; set; }

        [JsonProperty("effective_interest_rate_percentage")]
        public long EffectiveInterestRatePercentage { get; set; }

        [JsonProperty("agreement_duration_months")]
        public long AgreementDurationMonths { get; set; }

        [JsonProperty("deferral_period_months")]
        public long DeferralPeriodMonths { get; set; }

        [JsonProperty("amounts")]
        public Amounts Amounts { get; set; }

        [JsonProperty("fees")]
        public Fees Fees { get; set; }

        [JsonProperty("instalments")]
        public Instalment[] Instalments { get; set; }
    }
}
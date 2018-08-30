using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class Fees
    {
        [JsonProperty("instalment_fee_amount")]
        public long InstalmentFeeAmount { get; set; }

        [JsonProperty("setup_fee_amount")]
        public long SetupFeeAmount { get; set; }
    }
}
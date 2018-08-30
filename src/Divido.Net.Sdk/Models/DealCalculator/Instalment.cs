using System;
using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class Instalment
    {
        [JsonProperty("month")]
        public long Month { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("starting_balance")]
        public long StartingBalance { get; set; }

        [JsonProperty("present_value")]
        public long PresentValue { get; set; }

        [JsonProperty("interest_accrued")]
        public long InterestAccrued { get; set; }

        [JsonProperty("setup_fee")]
        public long SetupFee { get; set; }

        [JsonProperty("instalment_fee")]
        public long InstalmentFee { get; set; }

        [JsonProperty("instalment")]
        public long InstalmentInstalment { get; set; }

        [JsonProperty("total_payable")]
        public long TotalPayable { get; set; }

        [JsonProperty("end_balance")]
        public long EndBalance { get; set; }
    }
}
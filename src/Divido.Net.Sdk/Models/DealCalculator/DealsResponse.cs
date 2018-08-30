using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class DealsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("record")]
        public Record Record { get; set; }

        [JsonProperty("purchase_price")]
        public long PurchasePrice { get; set; }

        [JsonProperty("deposit_amount")]
        public long DepositAmount { get; set; }

        [JsonProperty("credit_amount")]
        public long CreditAmount { get; set; }

        [JsonProperty("monthly_payment_amount")]
        public double MonthlyPaymentAmount { get; set; }

        [JsonProperty("total_repayable_amount")]
        public long TotalRepayableAmount { get; set; }

        [JsonProperty("agreement_duration")]
        public long AgreementDuration { get; set; }

        [JsonProperty("deferral_period")]
        public long DeferralPeriod { get; set; }

        [JsonProperty("interest_rate")]
        public long InterestRate { get; set; }
    }
}

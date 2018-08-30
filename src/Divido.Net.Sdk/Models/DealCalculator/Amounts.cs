using Newtonsoft.Json;

namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class Amounts
    {
        [JsonProperty("purchase_amount")]
        public long PurchaseAmount { get; set; }

        [JsonProperty("deposit_amount")]
        public long DepositAmount { get; set; }

        [JsonProperty("credit_amount")]
        public long CreditAmount { get; set; }

        [JsonProperty("monthly_payment_amount")]
        public long MonthlyPaymentAmount { get; set; }

        [JsonProperty("credit_cost_amount")]
        public long CreditCostAmount { get; set; }

        [JsonProperty("total_repayable_amount")]
        public long TotalRepayableAmount { get; set; }
    }
}
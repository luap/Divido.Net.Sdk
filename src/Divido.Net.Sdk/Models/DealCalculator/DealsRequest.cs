namespace Divido.Net.Sdk.Models.DealCalculator
{
    public class DealsRequest
    {
        public decimal Amount { get; set; }
        public decimal Deposit { get; set; }
        public string FinanceId { get; set; }
        public string Country { get; set; }
    }
}

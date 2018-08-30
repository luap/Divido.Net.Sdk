namespace Divido.Net.Sdk.Models.CreditRequest
{
    public class CreditRequest
    {
        public decimal Deposit { get; set; }

        public string FinanceId { get; set; }

        public bool DirectSign { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string Reference { get; set; }
    }
}

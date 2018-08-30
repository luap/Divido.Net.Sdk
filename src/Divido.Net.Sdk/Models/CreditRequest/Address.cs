namespace Divido.Net.Sdk.Models.CreditRequest
{
    public class Address
    {
        public string Flat { get; set; }

        public string BuildingNumber { get; set; }

        public string BuildingName { get; set; }

        public string PostCode { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public int? MonthsAtAddress { get; set; }
    }
}
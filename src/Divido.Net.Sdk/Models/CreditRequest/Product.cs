namespace Divido.Net.Sdk.Models.CreditRequest
{
    public class Product
    {
        public string Name { get; set; }

        public string Sku { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Vat { get; set; }
    }
}
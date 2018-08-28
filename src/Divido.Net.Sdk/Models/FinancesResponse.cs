using System.Collections.Generic;

namespace Divido.Net.Sdk.Models
{
    public class FinancesResponse
    {
        public IEnumerable<Finance> Finances { get; set; }

        public string Status { get; set; }
    }
}

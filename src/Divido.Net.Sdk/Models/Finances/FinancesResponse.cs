using System.Collections.Generic;

namespace Divido.Net.Sdk.Models.Finances
{
    public class FinancesResponse
    {
        public IEnumerable<Finance> Finances { get; set; }

        public string Status { get; set; }
    }
}

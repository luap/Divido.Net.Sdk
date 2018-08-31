using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models.CreditRequest;
using Divido.Net.Sdk.Models.DealCalculator;
using Divido.Net.Sdk.Models.Finances;

namespace Divido.Net.Sdk
{
    public interface IDividoApi
    {
        Task<FinancesResponse> GetFinancePlans(CancellationToken token);

        Task<DealsResponse> GetDeals(DealsRequest creditRequest, CancellationToken token);

        Task<CreditRequestResponse> CreditRequest(CreditRequest creditRequest, CancellationToken token);
    }
}

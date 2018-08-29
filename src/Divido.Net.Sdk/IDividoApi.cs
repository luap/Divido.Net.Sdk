using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models;

namespace Divido.Net.Sdk
{
    interface IDividoApi
    {
        Task<FinancesResponse> GetFinancePlans(CancellationToken token);

        Task<CreditRequestResponse> CreditRequest(CreditRequest creditRequest, CancellationToken token);
    }
}

using System.Threading;
using System.Threading.Tasks;
using Divido.Net.Sdk.Models;

namespace Divido.Net.Sdk
{
    interface IDividoApi
    {
        Task<FinancesResponse> GetFinancePlans(CancellationToken cancel);
    }
}

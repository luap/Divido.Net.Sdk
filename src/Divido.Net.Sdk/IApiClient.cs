using System.Threading;
using System.Threading.Tasks;

namespace Divido.Net.Sdk
{
    public interface IApiClient
    {
        Task<TOk> PostAsync<TOk>(string endpoint, object content, CancellationToken cancel);

        Task<TOk> GetAsync<TOk>(string endpoint, CancellationToken cancel);
    }
}

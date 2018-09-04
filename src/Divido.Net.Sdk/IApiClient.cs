using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Divido.Net.Sdk
{
    public interface IApiClient
    {
        Task<TOk> PostAsync<TOk>(string endpoint, IEnumerable<KeyValuePair<string, string>> content, CancellationToken cancel);

        Task<TOk> GetAsync<TOk>(string endpoint, CancellationToken cancel);

        TOk Deserialize<TOk>(string json);
    }
}

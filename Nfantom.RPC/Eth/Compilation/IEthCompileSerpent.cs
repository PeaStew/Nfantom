using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nfantom.RPC.Eth.Compilation
{
    public interface IEthCompileSerpent
    {
        RpcRequest BuildRequest(string serpentCode, object id = null);
        Task<JObject> SendRequestAsync(string serpentCode, object id = null);
    }
}
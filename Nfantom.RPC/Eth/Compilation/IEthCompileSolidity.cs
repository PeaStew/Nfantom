using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nfantom.RPC.Eth.Compilation
{
    public interface IEthCompileSolidity
    {
        RpcRequest BuildRequest(string contractCode, object id = null);
        Task<JToken> SendRequestAsync(string contractCode, object id = null);
    }
}
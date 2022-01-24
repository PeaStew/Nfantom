using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nfantom.RPC.Eth.Compilation
{
    public interface IEthCompileLLL
    {
        RpcRequest BuildRequest(string lllcode, object id = null);
        Task<JObject> SendRequestAsync(string lllcode, object id = null);
    }
}
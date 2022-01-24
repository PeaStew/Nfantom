using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Mining
{
    public interface IEthSubmitHashrate
    {
        RpcRequest BuildRequest(string hashRate, string clientId, object id = null);
        Task<bool> SendRequestAsync(string hashRate, string clientId, object id = null);
    }
}
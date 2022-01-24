using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Mining
{
    public interface IEthSubmitWork
    {
        RpcRequest BuildRequest(string nonce, string header, string mix, object id = null);
        Task<bool> SendRequestAsync(string nonce, string header, string mix, object id = null);
    }
}
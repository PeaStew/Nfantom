using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth
{
    public interface IEthSign
    {
        RpcRequest BuildRequest(string address, string data, object id = null);
        Task<string> SendRequestAsync(string address, string data, object id = null);
    }
}
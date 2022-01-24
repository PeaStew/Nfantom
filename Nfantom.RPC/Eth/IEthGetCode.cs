using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth
{
    public interface IEthGetCode
    {
        BlockParameter DefaultBlock { get; set; }

        RpcRequest BuildRequest(string address, BlockParameter block, object id = null);
        Task<string> SendRequestAsync(string address, object id = null);
        Task<string> SendRequestAsync(string address, BlockParameter block, object id = null);
    }
}
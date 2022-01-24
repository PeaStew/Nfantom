using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthCall
    {
        BlockParameter DefaultBlock { get; set; }

        RpcRequest BuildRequest(CallInput callInput, BlockParameter block, object id = null);
        Task<string> SendRequestAsync(CallInput callInput, object id = null);
        Task<string> SendRequestAsync(CallInput callInput, BlockParameter block, object id = null);
    }
}
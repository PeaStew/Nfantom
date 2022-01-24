using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Blocks
{
    public interface IEthGetBlockWithTransactionsByHash
    {
        RpcRequest BuildRequest(string blockHash, object id = null);
        Task<BlockWithTransactions> SendRequestAsync(string blockHash, object id = null);
    }
}
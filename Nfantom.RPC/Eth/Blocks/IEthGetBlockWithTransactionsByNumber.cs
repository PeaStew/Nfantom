using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Blocks
{
    public interface IEthGetBlockWithTransactionsByNumber
    {
        RpcRequest BuildRequest(BlockParameter blockParameter, object id = null);
        RpcRequest BuildRequest(HexBigInteger number, object id = null);
        Task<BlockWithTransactions> SendRequestAsync(BlockParameter blockParameter, object id = null);
        Task<BlockWithTransactions> SendRequestAsync(HexBigInteger number, object id = null);
    }
}
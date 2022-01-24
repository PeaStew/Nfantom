using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Blocks
{
    public interface IEthGetBlockWithTransactionsHashesByNumber
    {
        RpcRequest BuildRequest(BlockParameter blockParameter, object id = null);
        RpcRequest BuildRequest(HexBigInteger number, object id = null);
        Task<BlockWithTransactionHashes> SendRequestAsync(BlockParameter blockParameter, object id = null);
        Task<BlockWithTransactionHashes> SendRequestAsync(HexBigInteger number, object id = null);
    }
}
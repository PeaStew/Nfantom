using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Uncles
{
    public interface IEthGetUncleByBlockNumberAndIndex
    {
        RpcRequest BuildRequest(BlockParameter blockParameter, HexBigInteger uncleIndex, object id = null);
        Task<BlockWithTransactionHashes> SendRequestAsync(BlockParameter blockParameter, HexBigInteger uncleIndex, object id = null);
    }
}
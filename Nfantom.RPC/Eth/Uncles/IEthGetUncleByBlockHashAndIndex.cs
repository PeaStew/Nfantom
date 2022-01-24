using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Uncles
{
    public interface IEthGetUncleByBlockHashAndIndex
    {
        RpcRequest BuildRequest(string blockHash, HexBigInteger uncleIndex, object id = null);
        Task<BlockWithTransactionHashes> SendRequestAsync(string blockHash, HexBigInteger uncleIndex, object id = null);
    }
}
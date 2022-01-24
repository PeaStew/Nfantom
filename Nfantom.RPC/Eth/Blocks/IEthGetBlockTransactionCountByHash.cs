using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Blocks
{
    public interface IEthGetBlockTransactionCountByHash
    {
        RpcRequest BuildRequest(string hash, object id = null);
        Task<HexBigInteger> SendRequestAsync(string hash, object id = null);
    }
}
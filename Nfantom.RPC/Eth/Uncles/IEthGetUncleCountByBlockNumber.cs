using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Uncles
{
    public interface IEthGetUncleCountByBlockNumber
    {
        RpcRequest BuildRequest(HexBigInteger blockNumber, object id = null);
        Task<HexBigInteger> SendRequestAsync(HexBigInteger blockNumber, object id = null);
    }
}
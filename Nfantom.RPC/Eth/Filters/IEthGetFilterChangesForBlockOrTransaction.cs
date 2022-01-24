using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthGetFilterChangesForBlockOrTransaction
    {
        RpcRequest BuildRequest(HexBigInteger filterId, object id = null);
        Task<string[]> SendRequestAsync(HexBigInteger filterId, object id = null);
    }
}
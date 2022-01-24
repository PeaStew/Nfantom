using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthGetFilterChangesForEthNewFilter
    {
        RpcRequest BuildRequest(HexBigInteger filterId, object id = null);
        Task<FilterLog[]> SendRequestAsync(HexBigInteger filterId, object id = null);
    }
}
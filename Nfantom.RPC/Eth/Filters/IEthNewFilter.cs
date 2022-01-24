using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthNewFilter
    {
        RpcRequest BuildRequest(NewFilterInput newFilterInput, object id = null);
        Task<HexBigInteger> SendRequestAsync(NewFilterInput newFilterInput, object id = null);
    }
}
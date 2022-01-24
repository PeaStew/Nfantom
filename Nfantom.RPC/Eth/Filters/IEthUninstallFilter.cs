using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthUninstallFilter
    {
        RpcRequest BuildRequest(HexBigInteger filterId, object id = null);
        Task<bool> SendRequestAsync(HexBigInteger filterId, object id = null);
    }
}
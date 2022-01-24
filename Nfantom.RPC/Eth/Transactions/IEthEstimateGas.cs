using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthEstimateGas
    {
        RpcRequest BuildRequest(CallInput callInput, object id = null);
        Task<HexBigInteger> SendRequestAsync(CallInput callInput, object id = null);
    }
}
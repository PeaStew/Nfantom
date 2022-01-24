using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthGetLogs
    {
        RpcRequest BuildRequest(NewFilterInput newFilter, object id = null);
        Task<FilterLog[]> SendRequestAsync(NewFilterInput newFilter, object id = null);
    }
}
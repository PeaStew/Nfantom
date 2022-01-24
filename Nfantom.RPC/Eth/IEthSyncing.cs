using System.Threading.Tasks;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Infrastructure;

namespace Nfantom.RPC.Eth
{
    public interface IEthSyncing: IGenericRpcRequestResponseHandlerNoParam<object>
    {
#if !DOTNET35
        Task<SyncingOutput> SendRequestAsync(object id = null);
#endif
    }
}
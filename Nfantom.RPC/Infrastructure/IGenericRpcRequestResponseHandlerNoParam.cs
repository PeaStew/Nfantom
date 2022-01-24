using System.Threading.Tasks;

namespace Nfantom.RPC.Infrastructure
{
    public interface IGenericRpcRequestResponseHandlerNoParam<TResponse>
    {
        Task<TResponse> SendRequestAsync(object id = null);
    }
}
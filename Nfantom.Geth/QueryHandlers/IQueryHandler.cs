using System.Threading.Tasks;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Geth.QueryHandlers
{
    public interface IQueryHandler<TFunctionMessage, TOutput>
        where TFunctionMessage : FunctionMessage, new()
    {
        Task<TOutput> QueryAsync(
             string contractAddress,
             TFunctionMessage functionMessage = null,
             BlockParameter block = null);
    }
}
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthSendTransaction
    {
        RpcRequest BuildRequest(TransactionInput input, object id = null);
        Task<string> SendRequestAsync(TransactionInput input, object id = null);
    }
}
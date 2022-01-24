using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthGetTransactionReceipt
    {
        RpcRequest BuildRequest(string transactionHash, object id = null);
        Task<TransactionReceipt> SendRequestAsync(string transactionHash, object id = null);
    }
}
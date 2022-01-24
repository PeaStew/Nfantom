using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthGetTransactionByHash
    {
        RpcRequest BuildRequest(string hashTransaction, object id = null);
        Task<Transaction> SendRequestAsync(string hashTransaction, object id = null);
    }
}
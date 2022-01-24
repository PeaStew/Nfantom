using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Personal
{
    public interface IPersonalSignAndSendTransaction
    {
        RpcRequest BuildRequest(TransactionInput txn, string password, object id = null);
        Task<string> SendRequestAsync(TransactionInput txn, string password, object id = null);
    }
}
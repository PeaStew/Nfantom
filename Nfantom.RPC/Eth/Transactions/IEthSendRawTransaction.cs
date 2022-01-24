using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthSendRawTransaction
    {
        RpcRequest BuildRequest(string signedTransactionData, object id = null);
        Task<string> SendRequestAsync(string signedTransactionData, object id = null);
    }
}
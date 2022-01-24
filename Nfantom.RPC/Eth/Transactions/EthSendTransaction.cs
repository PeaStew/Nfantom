using System;
using System.Threading.Tasks;
 
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public class EthSendTransaction : RpcRequestResponseHandler<string>, IEthSendTransaction
    {
        public EthSendTransaction(IClient client) : base(client, ApiMethods.ftm_sendTransaction.ToString())
        {
        }

        public Task<string> SendRequestAsync(TransactionInput input, object id = null)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return base.SendRequestAsync(id, input);
        }

        public RpcRequest BuildRequest(TransactionInput input, object id = null)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return base.BuildRequest(id, input);
        }
    }
}
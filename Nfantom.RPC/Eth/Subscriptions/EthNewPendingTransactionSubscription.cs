using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthNewPendingTransactionSubscription : RpcStreamingSubscriptionEventResponseHandler<string>
    {
        private EthNewPendingTransactionSubscriptionRequestBuilder _builder;

        public EthNewPendingTransactionSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
        {
            _builder = new EthNewPendingTransactionSubscriptionRequestBuilder();
        }

        public Task SubscribeAsync(object id = null)
        {
            return base.SubscribeAsync(BuildRequest(id));
        }

        public RpcRequest BuildRequest(object id)
        {
            return _builder.BuildRequest(id);
        }
    }
}

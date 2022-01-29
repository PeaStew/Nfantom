using Nfantom.RPC.Eth.Subscriptions;
using System;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.JsonRpc.WebSocketStreamingClient
{

    public class EthNewPendingTransactionObservableSubscription : RpcStreamingSubscriptionObservableHandler<string>
    {
        private EthNewPendingTransactionSubscriptionRequestBuilder _builder;

        public EthNewPendingTransactionObservableSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
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

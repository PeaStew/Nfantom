using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.JsonRpc.Client.Streaming;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Subscriptions;

namespace Nfantom.JsonRpc.WebSocketStreamingClient
{
    public class EthLogsObservableSubscription : RpcStreamingSubscriptionObservableHandler<FilterLog>
    {
        private EthLogsSubscriptionRequestBuilder _ethLogsSubscriptionRequestBuilder;

        public EthLogsObservableSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
        {
            _ethLogsSubscriptionRequestBuilder = new EthLogsSubscriptionRequestBuilder();
        }

        public Task SubscribeAsync(NewFilterInput filterInput, object id = null)
        {
            return base.SubscribeAsync(BuildRequest(filterInput, id));
        }

        public Task SubscribeAsync(object id = null)
        {
            return base.SubscribeAsync(BuildRequest(new NewFilterInput(), id));
        }

        public RpcRequest BuildRequest(NewFilterInput filterInput, object id = null)
        {
            return _ethLogsSubscriptionRequestBuilder.BuildRequest(filterInput, id);
        }
    }
}
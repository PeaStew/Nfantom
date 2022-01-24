using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthLogsSubscription : RpcStreamingSubscriptionEventResponseHandler<FilterLog>
    {
        private EthLogsSubscriptionRequestBuilder _ethLogsSubscriptionRequestBuilder;

        public EthLogsSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
        {
            _ethLogsSubscriptionRequestBuilder = new EthLogsSubscriptionRequestBuilder();
        }

        public Task SubscribeAsync(NewFilterInput filterInput, object id = null)
        {
            return base.SubscribeAsync(BuildRequest(filterInput, id));
        }

        public RpcRequest BuildRequest(NewFilterInput filterInput, object id = null)
        {
            return _ethLogsSubscriptionRequestBuilder.BuildRequest(filterInput, id);
        }
    }
}

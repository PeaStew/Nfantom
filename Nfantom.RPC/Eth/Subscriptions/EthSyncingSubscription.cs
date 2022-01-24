using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.JsonRpc.Client.Streaming;
using Newtonsoft.Json.Linq;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthSyncingSubscription : RpcStreamingSubscriptionEventResponseHandler<JObject>
    {
        private EthSyncingSubscriptionRequestBuilder _builder;

        public EthSyncingSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
        {
            _builder = new EthSyncingSubscriptionRequestBuilder();
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
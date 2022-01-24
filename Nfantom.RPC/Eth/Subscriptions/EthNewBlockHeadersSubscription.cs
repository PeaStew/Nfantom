using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthNewBlockHeadersSubscription : RpcStreamingSubscriptionEventResponseHandler<Block>
    {
        private EthNewBlockHeadersSubscriptionRequestBuilder _ethNewBlockHeadersSubscriptionRequestBuilder;

        public EthNewBlockHeadersSubscription(IStreamingClient client) : base(client, new EthUnsubscribeRequestBuilder())
        {
            _ethNewBlockHeadersSubscriptionRequestBuilder = new EthNewBlockHeadersSubscriptionRequestBuilder();
        }

        public Task SubscribeAsync(object id = null)
        {
            return base.SubscribeAsync(BuildRequest(id));
        }

        public RpcRequest BuildRequest(object id)
        {
            return _ethNewBlockHeadersSubscriptionRequestBuilder.BuildRequest(id);
        }
    }
}

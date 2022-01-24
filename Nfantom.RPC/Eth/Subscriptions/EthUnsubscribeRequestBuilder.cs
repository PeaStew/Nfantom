using System;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.JsonRpc.Client;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthUnsubscribeRequestBuilder : RpcRequestBuilder, IUnsubscribeSubscriptionRpcRequestBuilder
    {
        public EthUnsubscribeRequestBuilder() : base(ApiMethods.ftm_unsubscribe.ToString())
        {
        }

        public RpcRequest BuildRequest(string subscriptionHash, object id = null)
        {
            if (id == null) id = Guid.NewGuid().ToString();
            return base.BuildRequest(id, subscriptionHash.EnsureHexPrefix());
        }
    }
}
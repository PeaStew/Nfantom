using Nfantom.JsonRpc.Client;
using System;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthSyncingSubscriptionRequestBuilder : RpcRequestBuilder
    {
        public EthSyncingSubscriptionRequestBuilder() : base(ApiMethods.ftm_subscribe.ToString())
        {
        }

        public override RpcRequest BuildRequest(object id = null)
        {
            if (id == null) id = Guid.NewGuid().ToString();
            return base.BuildRequest(id, "syncing");
        }
    }
}

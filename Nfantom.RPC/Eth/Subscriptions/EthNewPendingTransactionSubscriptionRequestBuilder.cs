using System;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthNewPendingTransactionSubscriptionRequestBuilder : RpcRequestBuilder
    {
        public EthNewPendingTransactionSubscriptionRequestBuilder() : base(ApiMethods.ftm_subscribe.ToString())
        {
        }

        public override RpcRequest BuildRequest(object id = null)
        {
            if (id == null) id = Guid.NewGuid().ToString();
            return base.BuildRequest(id, "newPendingTransactions");
        }
    }
}
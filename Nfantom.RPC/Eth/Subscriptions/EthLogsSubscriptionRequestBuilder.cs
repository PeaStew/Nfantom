using System;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Subscriptions
{
    public class EthLogsSubscriptionRequestBuilder:RpcRequestBuilder
    {
        public EthLogsSubscriptionRequestBuilder() : base(ApiMethods.ftm_subscribe.ToString())
        {
        }

        public RpcRequest BuildRequest(NewFilterInput filterInput, object id)
        {
            if (id == null) id = Guid.NewGuid().ToString();
            return base.BuildRequest(id, "logs", filterInput);
        }
    }
}
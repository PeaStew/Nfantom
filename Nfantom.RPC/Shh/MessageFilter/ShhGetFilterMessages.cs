using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using Nfantom.RPC.Shh.DTOs;

namespace Nfantom.RPC.Shh.MessageFilter
{
    public class ShhGetFilterMessages : GenericRpcRequestResponseHandlerParamString<ShhMessage[]>, IShhGetFilterMessages
    {
        public ShhGetFilterMessages(IClient client) : base(client, ApiMethods.shh_getFilterMessages.ToString())
        {
        }
    }
}
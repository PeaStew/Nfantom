using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;

namespace Nfantom.RPC.Shh.MessageFilter
{
    public class ShhDeleteMessageFilter : GenericRpcRequestResponseHandlerParamString<bool>, IShhDeleteMessageFilter
    {
        public ShhDeleteMessageFilter(IClient client) : base(client, ApiMethods.shh_deleteMessageFilter.ToString())
        {
        }
    }
}

using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using Nfantom.RPC.Shh.DTOs;

namespace Nfantom.RPC.Shh.MessageFilter
{
    public interface IShhGetFilterMessages : IGenericRpcRequestResponseHandlerParamString<ShhMessage[]>
    {

    }
}
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;

namespace Nfantom.RPC.Net
{
    /// <Summary>
    ///     net_version
    ///     Returns the current network protocol version.
    ///     Parameters
    ///     none
    ///     Returns
    ///     String - The current network protocol version
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"net_version","params":[],"id":67}'
    ///     Result
    ///     {
    ///     "id":67,
    ///     "jsonrpc": "2.0",
    ///     "result": "59"
    ///     }
    /// </Summary>
    public class NetVersion : GenericRpcRequestResponseHandlerNoParam<string>, INetVersion
    {
        public NetVersion(IClient client) : base(client, ApiMethods.net_version.ToString())
        {
        }
    }
}
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;

namespace Nfantom.RPC.Eth.Filters
{
    /// <Summary>
    ///     eth_newPendingTransactionFilter
    ///     Creates a filter in the node, to notify when new pending transactions arrive. To check if the state has changed,
    ///     call eth_getFilterChanges.
    ///     Parameters
    ///     None
    ///     Returns
    ///     QUANTITY - A filter id.
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"eth_newPendingTransactionFilter","params":[],"id":73}'
    ///     Result
    ///     {
    ///     "id":1,
    ///     "jsonrpc":  "2.0",
    ///     "result": "0x1" // 1
    ///     }
    /// </Summary>
    public class EthNewPendingTransactionFilter : GenericRpcRequestResponseHandlerNoParam<HexBigInteger>, IEthNewPendingTransactionFilter
    {
        public EthNewPendingTransactionFilter(IClient client)
            : base(client, ApiMethods.ftm_newPendingTransactionFilter.ToString())
        {
        }
    }
}
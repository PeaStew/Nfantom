using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Infrastructure;

namespace Nfantom.RPC.Eth.Filters
{
    public interface IEthNewBlockFilter: IGenericRpcRequestResponseHandlerNoParam<HexBigInteger>
    {

    }
}
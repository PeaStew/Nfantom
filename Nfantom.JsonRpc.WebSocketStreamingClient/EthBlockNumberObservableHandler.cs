using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client.Streaming;
using Nfantom.RPC.Eth.Blocks;

namespace Nfantom.JsonRpc.WebSocketStreamingClient
{
    public class EthBlockNumberObservableHandler : RpcStreamingResponseNoParamsObservableHandler<HexBigInteger, EthBlockNumber>
    {
        public EthBlockNumberObservableHandler(IStreamingClient streamingClient) : base(streamingClient, new EthBlockNumber(null))
        {

        }
    }
}

using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth;
using Nfantom.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.JsonRpc.WebSocketStreamingClient
{
    public class EthGetBalanceObservableHandler : RpcStreamingResponseParamsObservableHandler<HexBigInteger, EthGetBalance>
    {
        public EthGetBalanceObservableHandler(IStreamingClient streamingClient) : base(streamingClient, new EthGetBalance(null))
        {

        }

        public Task SendRequestAsync(string address, BlockParameter block, object id = null)
        {
            if (id == null) id = Guid.NewGuid().ToString();
            var request = RpcRequestResponseHandler.BuildRequest(address, block, id);
            return SendRequestAsync(request);
        }
    }
}

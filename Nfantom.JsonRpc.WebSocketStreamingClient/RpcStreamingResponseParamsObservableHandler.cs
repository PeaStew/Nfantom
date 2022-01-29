using Nfantom.JsonRpc.Client;
using Nfantom.JsonRpc.Client.Streaming;

namespace Nfantom.JsonRpc.WebSocketStreamingClient
{
    public abstract class RpcStreamingResponseParamsObservableHandler<TResponse, TRpcRequestResponseHandler> : RpcStreamingResponseObservableHandler<TResponse>
        where TRpcRequestResponseHandler : RpcRequestResponseHandler<TResponse>
    {
        protected TRpcRequestResponseHandler RpcRequestResponseHandler { get; }

        protected RpcStreamingResponseParamsObservableHandler(IStreamingClient streamingClient, TRpcRequestResponseHandler rpcRequestResponseHandler) : base(streamingClient)
        {
            RpcRequestResponseHandler = rpcRequestResponseHandler;
        }
    }
}

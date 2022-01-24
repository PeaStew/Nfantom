using System;
using Nfantom.JsonRpc.Client.RpcMessages;

namespace Nfantom.JsonRpc.Client.Streaming
{
    public interface IRpcStreamingResponseHandler
    {
        void HandleResponse(RpcStreamingResponseMessage rpcStreamingResponse);
        void HandleClientError(Exception ex);
        void HandleClientDisconnection();
    }
}
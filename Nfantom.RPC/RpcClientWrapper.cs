using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC
{
    public class RpcClientWrapper
    {
        public RpcClientWrapper(IClient client)
        {
            Client = client;
        }

        public IClient Client { get; protected set; }
    }
}
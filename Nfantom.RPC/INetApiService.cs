using Nfantom.RPC.Net;

namespace Nfantom.RPC
{
    public interface INetApiService
    {
        INetListening Listening { get; }
        INetPeerCount PeerCount { get; }
        INetVersion Version { get; }
    }
}
using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth;

namespace Nfantom.RPC.Personal
{
    public interface IPersonalUnlockAccount
    {
        RpcRequest BuildRequest(string address, string passPhrase, int? durationInSeconds, object id = null);
#if !DOTNET35
        Task<bool> SendRequestAsync(EthCoinBase coinbaseRequest, string passPhrase, object id = null);
#endif
        Task<bool> SendRequestAsync(string address, string passPhrase, HexBigInteger durationInSeconds, object id = null);
        Task<bool> SendRequestAsync(string address, string passPhrase, ulong? durationInSeconds, object id = null);
    }
}
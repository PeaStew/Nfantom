using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Personal
{
    public interface IPersonalNewAccount
    {
        RpcRequest BuildRequest(string passPhrase, object id = null);
        Task<string> SendRequestAsync(string passPhrase, object id = null);
    }
}
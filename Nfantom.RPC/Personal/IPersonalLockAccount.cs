using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;

namespace Nfantom.RPC.Personal
{
    public interface IPersonalLockAccount
    {
        RpcRequest BuildRequest(string account, object id = null);
        Task<bool> SendRequestAsync(string account, object id = null);
    }
}
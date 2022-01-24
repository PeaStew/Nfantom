using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.KeyPair
{
    public interface IShhAddPrivateKey
    {
        Task<string> SendRequestAsync(string privateKey, object id = null);
        RpcRequest BuildRequest(string privateKey, object id = null);
    }
}
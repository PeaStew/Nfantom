using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Shh.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh
{
    public interface IShhPost
    {
        RpcRequest BuildRequest(MessageInput input, object id = null);
        Task<string> SendRequestAsync(MessageInput input, object id = null);
    }
}

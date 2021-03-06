using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.KeyPair
{
    public class ShhGetPrivateKey : GenericRpcRequestResponseHandlerParamString<string>, IShhGetPrivateKey
    {
        public ShhGetPrivateKey(IClient client) : base(client, ApiMethods.shh_getPrivateKey.ToString())
        {
        } 
    }
}

using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.KeyPair
{
    public class ShhDeleteKeyPair : GenericRpcRequestResponseHandlerParamString<bool>, IShhDeleteKeyPair
    {
        public ShhDeleteKeyPair(IClient client) : base(client, ApiMethods.shh_deleteKeyPair.ToString())
        {
        } 
    }
}

using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nfantom.RPC.Shh.SymKey
{
    public class ShhGetSymKey : GenericRpcRequestResponseHandlerParamString<string>, IShhGetSymKey
    {
        public ShhGetSymKey(IClient client) : base(client, ApiMethods.shh_getSymKey.ToString())
        {
        }
    }
}

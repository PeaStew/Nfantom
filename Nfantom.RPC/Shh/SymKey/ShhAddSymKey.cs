using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.SymKey
{
    public class ShhAddSymKey : GenericRpcRequestResponseHandlerParamString<string>, IShhAddSymKey
    {
        public ShhAddSymKey(IClient client) : base(client, ApiMethods.shh_addSymKey.ToString())
        {
        }
    }
}
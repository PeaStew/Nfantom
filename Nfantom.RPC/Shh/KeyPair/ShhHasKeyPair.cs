using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using Nfantom.RPC.Shh.KeyPair;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.KeyPair
{
    public class ShhHasKeyPair : GenericRpcRequestResponseHandlerParamString<bool>, IShhHasKeyPair
    {
        public ShhHasKeyPair(IClient client) : base(client, ApiMethods.shh_hasKeyPair.ToString())
        {
        } 
    }
}
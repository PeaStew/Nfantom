﻿using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh.SymKey
{
    public interface IShhAddSymKey : IGenericRpcRequestResponseHandlerParamString<string>
    {
    }
}

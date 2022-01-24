using Nfantom.RPC.Shh.SymKey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nfantom.RPC.Shh
{
    public interface IShhSymKey
    {
        IShhAddSymKey AddSymKey { get; }
        IShhDeleteSymKey DeleteSymKey { get; }
        IShhGenerateSymKeyFromPassword GenerateSymKeyFromPassword { get; }
        IShhGetSymKey GetSymKey { get; } 
        IShhHasSymKey HasSymKey { get; }
        IShhNewSymKey NewSymKey { get; }
    }
}

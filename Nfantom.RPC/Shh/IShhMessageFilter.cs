using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Infrastructure;
using Nfantom.RPC.Shh.DTOs;
using Nfantom.RPC.Shh.MessageFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nfantom.RPC.Shh
{
    public interface IShhMessageFilter
    {
        IShhNewMessageFilter NewMessageFilter { get; }
        IShhDeleteMessageFilter DeleteMessageFilter { get; }
        IShhGetFilterMessages GetFilterMessages { get; }
    }
}

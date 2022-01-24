﻿using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Blocks
{
    public interface IEthGetBlockTransactionCountByNumber
    {
        RpcRequest BuildRequest(BlockParameter block, object id = null);
        Task<HexBigInteger> SendRequestAsync(object id = null);
        Task<HexBigInteger> SendRequestAsync(BlockParameter block, object id = null);
    }
}
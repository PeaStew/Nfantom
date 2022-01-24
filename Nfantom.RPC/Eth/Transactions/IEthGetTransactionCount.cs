using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthGetTransactionCount
    {
        BlockParameter DefaultBlock { get; set; }

        RpcRequest BuildRequest(string address, BlockParameter block, object id = null);
        Task<HexBigInteger> SendRequestAsync(string address, object id = null);
        Task<HexBigInteger> SendRequestAsync(string address, BlockParameter block, object id = null);
    }
}
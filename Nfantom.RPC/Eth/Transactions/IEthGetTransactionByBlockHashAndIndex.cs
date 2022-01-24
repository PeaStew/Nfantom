using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthGetTransactionByBlockHashAndIndex
    {
        RpcRequest BuildRequest(string blockHash, HexBigInteger transactionIndex, object id = null);
        Task<Transaction> SendRequestAsync(string blockHash, HexBigInteger transactionIndex, object id = null);
    }
}
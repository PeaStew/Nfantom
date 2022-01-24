using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Transactions
{
    public interface IEthGetTransactionByBlockNumberAndIndex
    {
        RpcRequest BuildRequest(HexBigInteger blockNumber, HexBigInteger transactionIndex, object id = null);
        Task<Transaction> SendRequestAsync(HexBigInteger blockNumber, HexBigInteger transactionIndex, object id = null);
    }
}
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Transactions;

namespace Nfantom.RPC.Eth.Services
{
    public interface IEthApiTransactionsService
    {
        IEthCall Call { get; }
        IEthEstimateGas EstimateGas { get; }
        IEthGetTransactionByBlockHashAndIndex GetTransactionByBlockHashAndIndex { get; }
        IEthGetTransactionByBlockNumberAndIndex GetTransactionByBlockNumberAndIndex { get; }
        IEthGetTransactionByHash GetTransactionByHash { get; }
        IEthGetTransactionCount GetTransactionCount { get; }
        IEthGetTransactionReceipt GetTransactionReceipt { get; }
        IEthSendRawTransaction SendRawTransaction { get; }
        IEthSendTransaction SendTransaction { get; }

        void SetDefaultBlock(BlockParameter blockParameter);
    }
}
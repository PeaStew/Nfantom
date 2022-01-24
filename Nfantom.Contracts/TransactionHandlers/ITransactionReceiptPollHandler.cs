using System.Threading;
using System.Threading.Tasks;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Contracts.TransactionHandlers
{
    public interface ITransactionReceiptPollHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<TransactionReceipt> SendTransactionAsync(string contractAddress, TFunctionMessage functionMessage = null, CancellationTokenSource cancellationTokenSource = null);
    }
}
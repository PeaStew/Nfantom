using System.Threading;
using System.Threading.Tasks;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.Opera;

namespace Nfantom.Opera.TransactionHandlers
{
    public interface ITransactionReceiptPollHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<TransactionReceipt> SendTransactionAsync(string contractAddress, TFunctionMessage functionMessage = null, CancellationTokenSource cancellationTokenSource = null);
    }
}
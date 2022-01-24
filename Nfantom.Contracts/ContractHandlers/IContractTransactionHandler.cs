using System.Threading;
using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Contracts.ContractHandlers
{
    public interface IContractTransactionHandler<TContractMessage> where TContractMessage : FunctionMessage, new()
    {
        Task<TransactionInput> CreateTransactionInputEstimatingGasAsync(string contractAddress, TContractMessage functionMessage = null);
        Task<HexBigInteger> EstimateGasAsync(string contractAddress, TContractMessage functionMessage = null);
        Task<TransactionReceipt> SendRequestAndWaitForReceiptAsync(string contractAddress, TContractMessage functionMessage = null, CancellationTokenSource tokenSource = null);
        Task<string> SendRequestAsync(string contractAddress, TContractMessage functionMessage = null);
        Task<string> SignTransactionAsync(string contractAddress, TContractMessage functionMessage = null);
    }
}
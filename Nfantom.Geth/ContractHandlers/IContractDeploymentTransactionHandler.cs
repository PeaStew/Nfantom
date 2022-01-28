using System.Threading;
using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.Opera;

namespace Nfantom.Opera.ContractHandlers
{
    public interface IContractDeploymentTransactionHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<TransactionInput> CreateTransactionInputEstimatingGasAsync(TContractDeploymentMessage deploymentMessage = null);
        Task<HexBigInteger> EstimateGasAsync(TContractDeploymentMessage contractDeploymentMessage);
        Task<TransactionReceipt> SendRequestAndWaitForReceiptAsync(TContractDeploymentMessage contractDeploymentMessage = null, CancellationTokenSource tokenSource = null);
        Task<string> SendRequestAsync(TContractDeploymentMessage contractDeploymentMessage = null);
        Task<string> SignTransactionAsync(TContractDeploymentMessage contractDeploymentMessage);
    }
}
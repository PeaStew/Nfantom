using System.Threading;
using System.Threading.Tasks;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.Opera;

namespace Nfantom.Opera.DeploymentHandlers
{
    public interface IDeploymentTransactionReceiptPollHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<TransactionReceipt> SendTransactionAsync(TContractDeploymentMessage deploymentMessage = null, CancellationTokenSource cancellationTokenSource = null);
    }
}
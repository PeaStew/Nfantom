using Nfantom.Geth;
using System.Threading.Tasks;

namespace Nfantom.Geth.DeploymentHandlers
{
    public interface IDeploymentSigner<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<string> SignTransactionAsync(TContractDeploymentMessage deploymentMessage);
    }
}
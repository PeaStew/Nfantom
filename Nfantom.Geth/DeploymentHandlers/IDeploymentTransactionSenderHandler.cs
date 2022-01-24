using System.Threading.Tasks;

namespace Nfantom.Geth.DeploymentHandlers
{
    public interface IDeploymentTransactionSenderHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<string> SendTransactionAsync(TContractDeploymentMessage deploymentMessage = null);
    }
}
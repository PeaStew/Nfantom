using Nfantom.Opera;
using System.Threading.Tasks;

namespace Nfantom.Opera.DeploymentHandlers
{
    public interface IDeploymentTransactionSenderHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<string> SendTransactionAsync(TContractDeploymentMessage deploymentMessage = null);
    }
}
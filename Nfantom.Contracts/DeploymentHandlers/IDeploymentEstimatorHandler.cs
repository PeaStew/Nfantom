using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;

namespace Nfantom.Contracts.DeploymentHandlers
{
    public interface IDeploymentEstimatorHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<HexBigInteger> EstimateGasAsync(TContractDeploymentMessage deploymentMessage);
    }
}
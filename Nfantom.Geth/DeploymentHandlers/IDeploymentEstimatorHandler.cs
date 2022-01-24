using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.Geth;

namespace Nfantom.Geth.DeploymentHandlers
{
    public interface IDeploymentEstimatorHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<HexBigInteger> EstimateGasAsync(TContractDeploymentMessage deploymentMessage);
    }
}
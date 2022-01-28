using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.Opera;

namespace Nfantom.Opera.DeploymentHandlers
{
    public interface IDeploymentEstimatorHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        Task<HexBigInteger> EstimateGasAsync(TContractDeploymentMessage deploymentMessage);
    }
}
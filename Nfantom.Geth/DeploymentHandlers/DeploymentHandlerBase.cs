using Nfantom.RPC.TransactionManagers;
using Nfantom.Geth;
using Nfantom.Geth.ContractHandlers;
using Nfantom.Geth.MessageEncodingServices;

namespace Nfantom.Geth.DeploymentHandlers
{
#if !DOTNET35
    public abstract class DeploymentHandlerBase<TContractDeploymentMessage> : ContractTransactionHandlerBase
        where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        protected DeploymentMessageEncodingService<TContractDeploymentMessage> DeploymentMessageEncodingService { get; set; }

        private void InitialiseEncodingService()
        {
            DeploymentMessageEncodingService = new DeploymentMessageEncodingService<TContractDeploymentMessage>();
            DeploymentMessageEncodingService.DefaultAddressFrom = GetAccountAddressFrom();
        }

        protected DeploymentHandlerBase(ITransactionManager transactionManager) : base(transactionManager)
        {
            InitialiseEncodingService();
        }
    }
#endif
}
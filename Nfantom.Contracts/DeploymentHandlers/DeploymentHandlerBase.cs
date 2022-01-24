using Nfantom.RPC.TransactionManagers;
using Nfantom.Contracts;
using Nfantom.Contracts.ContractHandlers;
using Nfantom.Contracts.MessageEncodingServices;

namespace Nfantom.Contracts.DeploymentHandlers
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
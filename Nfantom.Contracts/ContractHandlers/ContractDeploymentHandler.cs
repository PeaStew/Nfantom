using System.Threading;
using System.Threading.Tasks;
using Nfantom.Contracts;
using Nfantom.Contracts.Extensions;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Accounts;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.TransactionManagers;
using Nfantom.Contracts.DeploymentHandlers;

namespace Nfantom.Contracts.ContractHandlers
{
#if !DOTNET35
    public class ContractDeploymentTransactionHandler<TContractDeploymentMessage> : ContractTransactionHandlerBase, IContractDeploymentTransactionHandler<TContractDeploymentMessage> where TContractDeploymentMessage : ContractDeploymentMessage, new()
    {
        private readonly IDeploymentEstimatorHandler<TContractDeploymentMessage> _estimatorHandler;
        private readonly IDeploymentTransactionReceiptPollHandler<TContractDeploymentMessage> _receiptPollHandler;
        private readonly IDeploymentTransactionSenderHandler<TContractDeploymentMessage> _transactionSenderHandler;
        private readonly IDeploymentSigner<TContractDeploymentMessage> _transactionSigner;

        public ContractDeploymentTransactionHandler(ITransactionManager transactionManager) : base(transactionManager)
        {
            _estimatorHandler = new DeploymentEstimatorHandler<TContractDeploymentMessage>(transactionManager);
            _receiptPollHandler = new DeploymentTransactionReceiptPollHandler<TContractDeploymentMessage>(transactionManager);
            _transactionSenderHandler = new DeploymentTransactionSenderHandler<TContractDeploymentMessage>(transactionManager);
            _transactionSigner = new DeploymentSigner<TContractDeploymentMessage>(transactionManager);
        }

        public Task<string> SignTransactionAsync(TContractDeploymentMessage contractDeploymentMessage)
        {
            return _transactionSigner.SignTransactionAsync(contractDeploymentMessage);
        }

        public Task<TransactionReceipt> SendRequestAndWaitForReceiptAsync(
            TContractDeploymentMessage contractDeploymentMessage = null, CancellationTokenSource tokenSource = null)
        {
            return _receiptPollHandler.SendTransactionAsync(contractDeploymentMessage, tokenSource);
        }

        public Task<string> SendRequestAsync(TContractDeploymentMessage contractDeploymentMessage = null)
        {
            return _transactionSenderHandler.SendTransactionAsync(contractDeploymentMessage);
        }

        public Task<HexBigInteger> EstimateGasAsync(TContractDeploymentMessage contractDeploymentMessage)
        {
            return _estimatorHandler.EstimateGasAsync(contractDeploymentMessage);
        }

        public async Task<TransactionInput> CreateTransactionInputEstimatingGasAsync(TContractDeploymentMessage deploymentMessage = null)
        {
            if (deploymentMessage == null) deploymentMessage = new TContractDeploymentMessage();
            var gasEstimate = await EstimateGasAsync(deploymentMessage).ConfigureAwait(false);
            deploymentMessage.Gas = gasEstimate;
            return deploymentMessage.CreateTransactionInput();
        }
    }
#endif

}
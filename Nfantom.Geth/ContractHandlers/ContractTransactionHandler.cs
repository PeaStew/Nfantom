﻿using Nfantom.Contracts;
using Nfantom.Geth.TransactionHandlers;
using Nfantom.Hex.HexTypes;
using Nfantom.Opera.Extensions;
using Nfantom.Opera.TransactionHandlers;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.TransactionManagers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nfantom.Opera.ContractHandlers
{
#if !DOTNET35
    public class ContractTransactionHandler<TContractMessage> : ContractTransactionHandlerBase, IContractTransactionHandler<TContractMessage> where TContractMessage : FunctionMessage, new()
    {
        private readonly ITransactionEstimatorHandler<TContractMessage> _estimatorHandler;
        private readonly ITransactionReceiptPollHandler<TContractMessage> _receiptPollHandler;
        private readonly ITransactionSenderHandler<TContractMessage> _transactionSenderHandler;
        private readonly ITransactionSigner<TContractMessage> _transactionSigner;


        public ContractTransactionHandler(ITransactionManager transactionManager) : base(transactionManager)
        {
            _estimatorHandler = new TransactionEstimatorHandler<TContractMessage>(transactionManager);
            _receiptPollHandler = new TransactionReceiptPollHandler<TContractMessage>(transactionManager);
            _transactionSenderHandler = new TransactionSenderHandler<TContractMessage>(transactionManager);
            _transactionSigner = new TransactionSignerHandler<TContractMessage>(transactionManager);
        }

        public Task<string> SignTransactionAsync(
            string contractAddress, TContractMessage functionMessage = null)
        {
            return _transactionSigner.SignTransactionAsync(contractAddress, functionMessage);
        }

        public Task<TransactionReceipt> SendTransactionAndWaitForReceiptAsync(
            string contractAddress, TContractMessage functionMessage = null, CancellationTokenSource tokenSource = null)
        {
            return _receiptPollHandler.SendTransactionAsync(contractAddress, functionMessage, tokenSource);
        }

        [Obsolete("Use " + nameof(SendTransactionAndWaitForReceiptAsync) + " instead")]
        public Task<TransactionReceipt> SendRequestAndWaitForReceiptAsync(
            string contractAddress, TContractMessage functionMessage = null, CancellationTokenSource tokenSource = null)
        {
            return SendTransactionAndWaitForReceiptAsync(contractAddress, functionMessage, tokenSource);
        }

        public Task<string> SendTransactionAsync(string contractAddress, TContractMessage functionMessage = null)
        {
            return _transactionSenderHandler.SendTransactionAsync(contractAddress, functionMessage);
        }

        [Obsolete("Use " + nameof(SendTransactionAsync) + " instead")]
        public Task<string> SendRequestAsync(string contractAddress, TContractMessage functionMessage = null)
        {
            return SendTransactionAsync(contractAddress, functionMessage);
        }

        public async Task<TransactionInput> CreateTransactionInputEstimatingGasAsync(
            string contractAddress, TContractMessage functionMessage = null)
        {
            var gasEstimate = await EstimateGasAsync(contractAddress, functionMessage).ConfigureAwait(false);
            functionMessage.Gas = gasEstimate;
            return functionMessage.CreateTransactionInput(contractAddress);
        }

        public Task<HexBigInteger> EstimateGasAsync(string contractAddress, TContractMessage functionMessage = null)
        {
            return _estimatorHandler.EstimateGasAsync(contractAddress, functionMessage);
        }
    }
#endif

}
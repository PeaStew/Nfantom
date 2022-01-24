using Nfantom.RPC.Eth.DTOs;
using Nfantom.Contracts.Extensions;
using Nfantom.Contracts.MessageEncodingServices;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.Contracts.Extensions
{
    public static class FunctionMessageExtensions
    {
        public static FunctionMessageEncodingService<TContractMessage> GetEncodingService<TContractMessage>(this TContractMessage contractMessage, string contractAddress = null, string defaultAddressFrom = null) where TContractMessage : FunctionMessage
        {
            return new FunctionMessageEncodingService<TContractMessage>(contractAddress, defaultAddressFrom);
        }

        public static CallInput CreateCallInput<TContractMessage>(this TContractMessage contractMessage,
            string contractAddress) where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService(contractAddress).CreateCallInput(contractMessage);
        }

        public static TransactionInput CreateTransactionInput<TContractMessage>(this TContractMessage contractMessage,
            string contractAddress) where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService(contractAddress).CreateTransactionInput(contractMessage);
        }

        public static TContractMessage DecodeInput<TContractMessage>(this TContractMessage contractMessage,
            string data) where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService().DecodeInput(contractMessage, data);
        }

        public static bool IsTransactionForFunctionMessage<TContractMessage>(this
            Transaction transaction) where TContractMessage : FunctionMessage, new()
        {
            var contractMessage = new TContractMessage();
            return contractMessage.GetEncodingService().IsTransactionForFunction(transaction);
        }

        public static TContractMessage DecodeTransactionToFunctionMessage<TContractMessage>(this
            Transaction transaction) where TContractMessage : FunctionMessage, new()
        {
            var contractMessage = new TContractMessage();
            return contractMessage.GetEncodingService().DecodeTransactionInput(contractMessage, transaction);
        }

        public static TContractMessage DecodeTransaction<TContractMessage>(this TContractMessage contractMessage,
            Transaction transaction) where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService().DecodeTransactionInput(contractMessage, transaction);
        }

        public static byte[] GetCallData<TContractMessage>(this TContractMessage contractMessage
            ) where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService().GetCallData(contractMessage);
        }

        public static byte[] GetCallDataHash<TContractMessage>(this TContractMessage contractMessage)
            where TContractMessage : FunctionMessage
        {
            return contractMessage.GetEncodingService().GetCallDataHash(contractMessage);
        }

        public static TFunctionMessage Decode<TFunctionMessage>(this TransactionReceiptVO transactionWithReceipt) where TFunctionMessage : FunctionMessage, new()
        {
            return transactionWithReceipt.Transaction?.DecodeTransactionToFunctionMessage<TFunctionMessage>();
        }

        public static bool IsTransactionForFunctionMessage<TFunctionMessage>(this TransactionReceiptVO transactionWithReceipt) where TFunctionMessage : FunctionMessage, new()
        {
            return transactionWithReceipt.Transaction?.IsTransactionForFunctionMessage<TFunctionMessage>() ?? false;
        }

        public static bool IsTransactionForFunctionMessage<TFunctionMessage>(this TransactionVO transactionVo) where TFunctionMessage : FunctionMessage, new()
        {
            return transactionVo.Transaction?.IsTransactionForFunctionMessage<TFunctionMessage>() ?? false;
        }
    }
}
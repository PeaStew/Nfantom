using Nfantom.ABI.FunctionEncoding;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.Geth;
using Nfantom.Geth.MessageEncodingServices;

namespace Nfantom.Geth.Extensions
{
    /// <summary>
    /// Please use Nethereum.Contracts.DeploymentMessageExtensions instead (keeping this class as a small workaround to move extensions to contracts namespaces)
    /// </summary>
    public static class DeploymentMessageExtensions
    {
    }
}

namespace Nfantom.Contracts
{

    public static class DeploymentMessageExtensions
    {
        public static DeploymentMessageEncodingService<TContractMessage> GetEncodingService<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractDeploymentMessage
        {
            return new DeploymentMessageEncodingService<TContractMessage>();
        }

        public static CallInput CreateCallInput<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractDeploymentMessage
        {
            return contractMessage.GetEncodingService().CreateCallInput(contractMessage);
        }

        public static TransactionInput CreateTransactionInput<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractDeploymentMessage
        {
            return contractMessage.GetEncodingService().CreateTransactionInput(contractMessage);
        }

        public static TContractMessage DecodeTransaction<TContractMessage>(this TContractMessage contractMessage, Transaction transaction) where TContractMessage : ContractDeploymentMessage
        {
            return contractMessage.GetEncodingService().DecodeTransaction(contractMessage, transaction);
        }

        public static TContractMessage DecodeTransactionToDeploymentMessage<TContractMessage>(this Transaction transaction) where TContractMessage : ContractDeploymentMessage, new()
        {
            var contractMessage = new TContractMessage();
            return contractMessage.GetEncodingService().DecodeTransaction(contractMessage, transaction);
        }

        public static string GetSwarmAddressFromByteCode<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractDeploymentMessage
        {
            return contractMessage.GetEncodingService().GetSwarmAddressFromByteCode(contractMessage);
        }

        public static bool HasASwarmAddressTheByteCode<TContractMessage>(this TContractMessage contractMessage) where TContractMessage : ContractDeploymentMessage
        {
            return contractMessage.GetEncodingService().HasASwarmAddressTheByteCode(contractMessage);
        }

        public static void LinkLibraries<TContractMessage>(this TContractMessage contractMessage, params ByteCodeLibrary[] byteCodeLibraries) where TContractMessage : ContractDeploymentMessage, new()
        {
            var libraryLinker = new ByteCodeLibraryLinker();
            contractMessage.ByteCode = libraryLinker.LinkByteCode(contractMessage.ByteCode, byteCodeLibraries);
        }

        public static byte[] GetDeploymentData<TContractMessage>(this TContractMessage contractMessage
        ) where TContractMessage : ContractDeploymentMessage, new()
        {
            return contractMessage.GetEncodingService().GetDeploymentData(contractMessage).HexToByteArray();
        }

        public static byte[] GetDeploymentDataHash<TContractMessage>(this TContractMessage contractMessage)
            where TContractMessage : ContractDeploymentMessage, new()
        {
            return contractMessage.GetEncodingService().GetDeploymentDataHash(contractMessage);
        }
    }
}
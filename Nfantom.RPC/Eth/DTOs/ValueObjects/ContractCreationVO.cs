using Nfantom.Hex.HexTypes;

namespace Nfantom.RPC.Eth.DTOs.ValueObjects
{
    public class ContractCreationVO : TransactionReceiptVO
    {
        public ContractCreationVO()
        {

        }

        public ContractCreationVO(TransactionReceiptVO transactionReceiptVO, string code, bool failedCreatingContract)
        {
            Transaction = transactionReceiptVO.Transaction;
            TransactionReceipt = transactionReceiptVO.TransactionReceipt;
            Block = transactionReceiptVO.Block;
            Code = code;
            FailedCreatingContract = failedCreatingContract;
            ContractAddress = TransactionReceipt.ContractAddress;

        }

        public ContractCreationVO(
            string contractAddress,
            string code,
            Transaction transaction,
            TransactionReceipt transactionReceipt,
            bool failedCreatingContract,
            Block block
          )
        {
            ContractAddress = contractAddress;
            Code = code;
            Transaction = transaction;
            TransactionReceipt = transactionReceipt;
            FailedCreatingContract = failedCreatingContract;
            Block = block;
        }

        public string ContractAddress { get; private set; }
        public string Code { get; private set; }
        public bool FailedCreatingContract { get; private set; }

        //public virtual TDeploymentMessage DecodeToDeploymentMessage<TDeploymentMessage>()
        //    where TDeploymentMessage : ContractDeploymentMessage, new()
        //{
        //    return Transaction?.DecodeTransactionToDeploymentMessage<TDeploymentMessage>();
        //}
    }
}

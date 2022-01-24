using System;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.RPC.Eth.Exceptions
{
    public class ContractDeploymentException : Exception
    {
        public ContractDeploymentException(string message, TransactionReceipt transactionReceipt) : base(message)
        {
            TransactionReceipt = transactionReceipt;
        }

        public TransactionReceipt TransactionReceipt { get; set; }
    }
}
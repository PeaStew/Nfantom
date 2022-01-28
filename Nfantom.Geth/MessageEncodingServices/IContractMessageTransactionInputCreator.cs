using Nfantom.RPC.Eth.DTOs;
using Nfantom.Opera.CQS;

namespace Nfantom.Opera.MessageEncodingServices
{
    public interface IContractMessageTransactionInputCreator<TContractMessage> : IDefaultAddressService
        where TContractMessage : ContractMessageBase
    {
        TransactionInput CreateTransactionInput(TContractMessage contractMessage);
        CallInput CreateCallInput(TContractMessage contractMessage);
    }


    public interface IDefaultAddressService
    {
        string DefaultAddressFrom { get; set; }
    }
}
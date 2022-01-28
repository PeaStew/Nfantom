using Nfantom.RPC.TransactionManagers;
using Nfantom.Opera.ContractHandlers;
using Nfantom.Opera;
using Nfantom.Opera.MessageEncodingServices;

namespace Nfantom.Opera.TransactionHandlers
{
#if !DOTNET35
    public abstract class TransactionHandlerBase<TFunctionMessage> : ContractTransactionHandlerBase
       where TFunctionMessage : FunctionMessage, new()
    {
        protected FunctionMessageEncodingService<TFunctionMessage> FunctionMessageEncodingService { get; set; }

        private void InitialiseEncodingService()
        {
            FunctionMessageEncodingService = new FunctionMessageEncodingService<TFunctionMessage>();
            FunctionMessageEncodingService.DefaultAddressFrom = GetAccountAddressFrom();
        }

        protected TransactionHandlerBase(ITransactionManager transactionManager) : base(transactionManager)
        {
            InitialiseEncodingService();
        }

        protected void SetEncoderContractAddress(string contractAddress)
        {
            FunctionMessageEncodingService.SetContractAddress(contractAddress);
        }

    }
#endif
}
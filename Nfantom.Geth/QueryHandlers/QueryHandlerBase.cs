using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Transactions;
using Nfantom.Geth;
using Nfantom.Geth.MessageEncodingServices;
using System.Threading.Tasks;

namespace Nfantom.Geth.QueryHandlers
{
    public abstract class QueryHandlerBase<TFunctionMessage>
        where TFunctionMessage : FunctionMessage, new()
    {
        protected IEthCall EthCall { get; set; }
        private ContractCall _contractCall;
        public string DefaultAddressFrom { get; set; }
        protected BlockParameter DefaultBlockParameter { get; set; }
        public FunctionMessageEncodingService<TFunctionMessage> FunctionMessageEncodingService { get; } = new FunctionMessageEncodingService<TFunctionMessage>();

        protected QueryHandlerBase(IEthCall ethCall, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null)
        {
            EthCall = ethCall;
            DefaultAddressFrom = defaultAddressFrom;
            DefaultBlockParameter = defaultBlockParameter ?? BlockParameter.CreateLatest();
            _contractCall = new ContractCall(EthCall, DefaultBlockParameter);
        }

        protected QueryHandlerBase(IClient client, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null) : this(new EthCall(client), defaultAddressFrom, defaultBlockParameter)
        {

        }

        public virtual string GetAccountAddressFrom()
        {
            return DefaultAddressFrom;
        }

        protected void EnsureInitialiseAddress()
        {
            if (FunctionMessageEncodingService != null)
            {
                FunctionMessageEncodingService.DefaultAddressFrom = GetAccountAddressFrom();
            }
        }
#if !DOTNET35
        protected Task<string> CallAsync(CallInput callInput, BlockParameter block = null)
        {
            if (block == null) block = DefaultBlockParameter;
            return _contractCall.CallAsync(callInput, block);
        }
#endif
    }
}
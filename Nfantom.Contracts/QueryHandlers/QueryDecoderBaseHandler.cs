using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Transactions;

namespace Nfantom.Contracts.QueryHandlers
{
#if !DOTNET35
    public abstract class QueryDecoderBaseHandler<TFunctionMessage, TFunctionOutput> :
        IQueryHandler<TFunctionMessage, TFunctionOutput>
        where TFunctionMessage : FunctionMessage, new()
    {
        protected QueryRawHandler<TFunctionMessage> QueryRawHandler { get; set; }

        public string DefaultAddressFrom
        {
            get => QueryRawHandler.DefaultAddressFrom;
            set => QueryRawHandler.DefaultAddressFrom = value;
        }

        public QueryDecoderBaseHandler(IClient client, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null)
        {
            QueryRawHandler = new QueryRawHandler<TFunctionMessage>(client, defaultAddressFrom, defaultBlockParameter);
        }

        public QueryDecoderBaseHandler(IEthCall ethCall, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null)
        {
            QueryRawHandler = new QueryRawHandler<TFunctionMessage>(ethCall, defaultAddressFrom, defaultBlockParameter);
        }

        public async Task<TFunctionOutput> QueryAsync(string contractAddress, TFunctionMessage functionMessage = null, BlockParameter block = null)
        {
            var result = await QueryRawHandler.QueryAsync(contractAddress, functionMessage, block).ConfigureAwait(false);
            return DecodeOutput(result);
        }

        protected abstract TFunctionOutput DecodeOutput(string output);
    }
#endif
}
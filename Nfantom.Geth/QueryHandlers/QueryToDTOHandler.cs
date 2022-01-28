using Nfantom.ABI.FunctionEncoding.Attributes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Transactions;

namespace Nfantom.Opera.QueryHandlers
{
#if !DOTNET35

    public class QueryToDTOHandler<TFunctionMessage, TFunctionOutput> :
        QueryDecoderBaseHandler<TFunctionMessage, TFunctionOutput> where TFunctionMessage : FunctionMessage, new()
        where TFunctionOutput : IFunctionOutputDTO, new()
    {

        public QueryToDTOHandler(IClient client, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null) : base(client, defaultAddressFrom, defaultBlockParameter)
        {
            QueryRawHandler = new QueryRawHandler<TFunctionMessage>(client, defaultAddressFrom, defaultBlockParameter);
        }

        public QueryToDTOHandler(IEthCall ethCall, string defaultAddressFrom = null, BlockParameter defaultBlockParameter = null) : base(ethCall, defaultAddressFrom, defaultBlockParameter)
        {
            QueryRawHandler = new QueryRawHandler<TFunctionMessage>(ethCall, defaultAddressFrom, defaultBlockParameter);
        }

        protected override TFunctionOutput DecodeOutput(string output)
        {
            return QueryRawHandler.FunctionMessageEncodingService.DecodeDTOTypeOutput<TFunctionOutput>(output);
        }
    }
#endif
}
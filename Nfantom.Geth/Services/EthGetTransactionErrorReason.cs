using System.Threading.Tasks;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Services;
using Nfantom.RPC.Eth.Transactions;

namespace Nfantom.Opera.Services
{
    public class EthGetContractTransactionErrorReason : IEthGetContractTransactionErrorReason
    {
        private readonly IEthApiTransactionsService _apiTransactionsService;

        public EthGetContractTransactionErrorReason(IEthApiTransactionsService apiTransactionsService)
        {
            _apiTransactionsService = apiTransactionsService;
        }
#if !DOTNET35
        public async Task<string> SendRequestAsync(string transactionHash)
        {
            var transaction = await _apiTransactionsService.GetTransactionByHash.SendRequestAsync(transactionHash);
            var transactionInput = transaction.ConvertToTransactionInput();
            var functionCallDecoder = new FunctionCallDecoder();
            if (transactionInput.MaxFeePerGas != null)
            {
                transactionInput.GasPrice = null;
            }
            try
            {
                var errorHex = await _apiTransactionsService.Call.SendRequestAsync(transactionInput, new BlockParameter(transaction.BlockNumber));

                if (ErrorFunction.IsErrorData(errorHex))
                {
                    return functionCallDecoder.DecodeFunctionErrorMessage(errorHex);
                }
                return string.Empty;

            }
            catch (RpcResponseException rpcException)
            {
                ContractRevertExceptionHandler.HandleContractRevertException(rpcException);
                throw;
            }
        }
#endif
    }
}
using System;
using System.Threading.Tasks;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.Hex.HexTypes;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.Transactions;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.Contracts.TransactionHandlers
{
#if !DOTNET35

    public class TransactionEstimatorHandler<TFunctionMessage> :
        TransactionHandlerBase<TFunctionMessage>,
        ITransactionEstimatorHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {

        public TransactionEstimatorHandler(ITransactionManager transactionManager) : base(transactionManager)
        {

        }

        public async Task<HexBigInteger> EstimateGasAsync(string contractAddress, TFunctionMessage functionMessage = null)
        {
            if (functionMessage == null) functionMessage = new TFunctionMessage();
            SetEncoderContractAddress(contractAddress);
            var callInput = FunctionMessageEncodingService.CreateCallInput(functionMessage);
            try
            {
                return await TransactionManager.EstimateGasAsync(callInput).ConfigureAwait(false);
            }
            catch (RpcResponseException rpcException)
            {
                ContractRevertExceptionHandler.HandleContractRevertException(rpcException);
                throw;
            }
            catch (Exception)
            {
                var ethCall = new EthCall(TransactionManager.Client);
                var result = await ethCall.SendRequestAsync(callInput).ConfigureAwait(false);
                new FunctionCallDecoder().ThrowIfErrorOnOutput(result);
                throw;
            }
        }
    }
#endif
}
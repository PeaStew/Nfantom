using System.Threading.Tasks;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Transactions;

namespace Nfantom.Contracts
{
    public class ContractCall
    {
        private readonly IEthCall _ethCall;
        private readonly BlockParameter _defaulBlock;

        public ContractCall(IEthCall ethCall, BlockParameter defaulBlock)
        {
            _ethCall = ethCall;
            _defaulBlock = defaulBlock;
            if (_defaulBlock == null) _defaulBlock = BlockParameter.CreateLatest();
        }

#if !DOTNET35
        public async Task<string> CallAsync(CallInput callInput, BlockParameter block = null)
        {
            try
            {
                if (block == null) block = _defaulBlock;
                return await _ethCall.SendRequestAsync(callInput, block).ConfigureAwait(false);
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
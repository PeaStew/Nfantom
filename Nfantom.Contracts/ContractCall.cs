using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        private readonly BlockParameter _defaultBlock;

        public ContractCall(IEthCall ethCall, BlockParameter defaultBlock)
        {
            _ethCall = ethCall;
            _defaultBlock = defaultBlock;
            if (_defaultBlock == null) _defaultBlock = BlockParameter.CreateLatest();
        }

#if !DOTNET35
        public async Task<string> CallAsync(CallInput callInput, BlockParameter block = null)
        {
            try
            {
                if (block == null) block = _defaultBlock;
                return await _ethCall.SendRequestAsync(callInput, block).ConfigureAwait(false);
            }
            catch (RpcResponseException rpcException)
            {
                Console.WriteLine(JsonConvert.SerializeObject(rpcException));
                ContractRevertExceptionHandler.HandleContractRevertException(rpcException);
                throw;
            }
        }
#endif
    }
}
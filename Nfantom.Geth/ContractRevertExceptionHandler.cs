using System;
using Nfantom.ABI.FunctionEncoding;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Eth.Transactions;
using Newtonsoft.Json.Linq;
using Nfantom.Opera.Exceptions;

namespace Nfantom.Opera
{
    public class ContractRevertExceptionHandler
    {
        public static void HandleContractRevertException(RpcResponseException rpcException)
        {
            if (rpcException.RpcError.Data != null)
            {
                var encodedErrorData = rpcException.RpcError.Data.ToString();
                if (encodedErrorData.IsHex())
                {
                    //check normal revert
                    new FunctionCallDecoder().ThrowIfErrorOnOutput(encodedErrorData);

                    //throw custom error
                    throw new SmartContractCustomErrorRevertException(encodedErrorData);
                }
            }
        }


    }
}
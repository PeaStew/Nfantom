using System.Threading.Tasks;
using Nfantom.ABI.FunctionEncoding.Attributes;
using Nfantom.Opera;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.Opera.ContractHandlers
{
    public interface IContractQueryHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<TFunctionOutput> QueryAsync<TFunctionOutput>(string contractAddress, TFunctionMessage functionMessage = null, BlockParameter block = null);
        Task<TFunctionOutput> QueryDeserializingToObjectAsync<TFunctionOutput>(TFunctionMessage functionMessage, string contractAddress, BlockParameter block = null) where TFunctionOutput : IFunctionOutputDTO, new();
        Task<byte[]> QueryRawAsBytesAsync(string contractAddress, TFunctionMessage functionMessage = null, BlockParameter block = null);
        Task<string> QueryRawAsync(string contractAddress, TFunctionMessage functionMessage = null, BlockParameter block = null);
    }
}
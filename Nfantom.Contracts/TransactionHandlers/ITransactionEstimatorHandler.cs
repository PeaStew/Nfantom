using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;

namespace Nfantom.Contracts.TransactionHandlers
{
    public interface ITransactionEstimatorHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<HexBigInteger> EstimateGasAsync(string contractAddress, TFunctionMessage functionMessage = null);
    }
}
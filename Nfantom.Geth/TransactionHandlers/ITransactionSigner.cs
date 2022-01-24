using System.Threading.Tasks;

namespace Nfantom.Geth.TransactionHandlers
{
    public interface ITransactionSigner<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<string> SignTransactionAsync(string contractAddress, TFunctionMessage functionMessage = null);
    }
}
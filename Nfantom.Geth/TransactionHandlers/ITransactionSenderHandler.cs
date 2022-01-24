using System.Threading.Tasks;

namespace Nfantom.Geth.TransactionHandlers
{
    public interface ITransactionSenderHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<string> SendTransactionAsync(string contractAddress, TFunctionMessage functionMessage = null);
    }
}
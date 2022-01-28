using Nfantom.Opera;
using System.Threading.Tasks;

namespace Nfantom.Opera.TransactionHandlers
{
    public interface ITransactionSenderHandler<TFunctionMessage> where TFunctionMessage : FunctionMessage, new()
    {
        Task<string> SendTransactionAsync(string contractAddress, TFunctionMessage functionMessage = null);
    }
}
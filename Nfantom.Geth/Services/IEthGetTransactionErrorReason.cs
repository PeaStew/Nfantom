using System.Threading.Tasks;

namespace Nfantom.Geth.Services
{
    public interface IEthGetContractTransactionErrorReason
    {
#if !DOTNET35
        Task<string> SendRequestAsync(string transactionHash);
#endif
    }
}
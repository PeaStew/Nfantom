using System.Threading.Tasks;

namespace Nfantom.Contracts.Services
{
    public interface IEthGetContractTransactionErrorReason
    {
#if !DOTNET35
        Task<string> SendRequestAsync(string transactionHash);
#endif
    }
}
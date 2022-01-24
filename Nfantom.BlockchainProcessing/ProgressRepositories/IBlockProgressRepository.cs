using System.Numerics;
using System.Threading.Tasks;

namespace Nfantom.BlockchainProcessing.ProgressRepositories
{
    public interface IBlockProgressRepository
    {
        Task UpsertProgressAsync(BigInteger blockNumber);
        Task<BigInteger?> GetLastBlockNumberProcessedAsync();
    }
}
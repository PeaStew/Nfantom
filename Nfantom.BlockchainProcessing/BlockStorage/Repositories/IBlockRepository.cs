using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Entities;
using Nfantom.Hex.HexTypes;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public interface IBlockRepository
    {
        Task UpsertBlockAsync(Nfantom.RPC.Eth.DTOs.Block source);
        Task<IBlockView> FindByBlockNumberAsync(HexBigInteger blockNumber);
    }
}
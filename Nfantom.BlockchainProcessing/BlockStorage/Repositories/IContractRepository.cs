using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Entities;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public interface IContractRepository
    {
        Task FillCacheAsync();
        Task UpsertAsync(ContractCreationVO contractCreation);
        Task<bool> ExistsAsync(string contractAddress);

        Task<IContractView> FindByAddressAsync(string contractAddress);
        bool IsCached(string contractAddress);
    }
}
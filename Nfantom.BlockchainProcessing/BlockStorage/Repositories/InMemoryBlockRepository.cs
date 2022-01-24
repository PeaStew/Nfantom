using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Entities;
using Nfantom.BlockchainProcessing.BlockStorage.Entities.Mapping;
using Nfantom.Hex.HexTypes;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public class InMemoryBlockRepository : IBlockRepository
    {
        public List<IBlockView> Records { get; set;}

        public InMemoryBlockRepository(List<IBlockView> records)
        {
            Records = records;
        }

        public Task<IBlockView> FindByBlockNumberAsync(HexBigInteger blockNumber)
        {
            var block = Records.FirstOrDefault(r => r.BlockNumber == blockNumber.Value.ToString());
            return Task.FromResult(block);
        }

        public async Task UpsertBlockAsync(RPC.Eth.DTOs.Block source)
        {
            var record = await FindByBlockNumberAsync(source.Number).ConfigureAwait(false);
            if(record != null) Records.Remove(record);
            Records.Add(source.MapToStorageEntityForUpsert());
        }
    }
}

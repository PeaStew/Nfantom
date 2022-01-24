using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Repositories;
using Nfantom.BlockchainProcessing.Processor;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.BlockchainProcessing.BlockStorage.BlockStorageStepsHandlers
{
    public class BlockStorageStepHandler : ProcessorBaseHandler<BlockWithTransactions>
    {
        private readonly IBlockRepository _blockRepository;

        public BlockStorageStepHandler(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }
        protected override Task ExecuteInternalAsync(BlockWithTransactions block)
        {
            return _blockRepository.UpsertBlockAsync(block);
        }
    }
}

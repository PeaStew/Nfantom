using System;
using Common.Logging;
using Nfantom.BlockchainProcessing.BlockProcessing;
using Nfantom.BlockchainProcessing.BlockStorage;
using Nfantom.BlockchainProcessing.BlockStorage.Repositories;
using Nfantom.BlockchainProcessing.ProgressRepositories;
using Nfantom.Contracts.Services;
using Nfantom.RPC.Eth.Blocks;

namespace Nfantom.BlockchainProcessing.Services
{
    public class BlockchainBlockProcessingService : IBlockchainBlockProcessingService
    {
        private readonly IEthApiContractService _ethApiContractService;

        public BlockchainBlockProcessingService(IEthApiContractService ethApiContractService)
        {
            _ethApiContractService = ethApiContractService;
        }

#if !DOTNET35

        public BlockchainCrawlingProcessor CreateBlockProcessor(
            Action<BlockProcessingSteps> stepsConfiguration, 
            uint minimumBlockConfirmations, 
            ILog log = null) => CreateBlockProcessor(
                new InMemoryBlockchainProgressRepository(),
                stepsConfiguration, 
                minimumBlockConfirmations, 
                log);

        public BlockchainCrawlingProcessor CreateBlockProcessor(
            IBlockProgressRepository blockProgressRepository,
            Action<BlockProcessingSteps> stepsConfiguration,
            uint minimumBlockConfirmations,
            ILog log = null)
        {
            var processingSteps = new BlockProcessingSteps();
            var orchestrator = new BlockCrawlOrchestrator(_ethApiContractService, processingSteps );
            var lastConfirmedBlockNumberService = new LastConfirmedBlockNumberService(_ethApiContractService.Blocks.GetBlockNumber, minimumBlockConfirmations);

            stepsConfiguration?.Invoke(processingSteps);

            return new BlockchainCrawlingProcessor(orchestrator, blockProgressRepository, lastConfirmedBlockNumberService, log);
        }

        public BlockchainCrawlingProcessor CreateBlockStorageProcessor(
            IBlockchainStoreRepositoryFactory blockchainStorageFactory, 
            uint minimumBlockConfirmations, 
            Action<BlockProcessingSteps> configureSteps = null, 
            ILog log = null) => CreateBlockStorageProcessor(
                blockchainStorageFactory, 
                null, 
                minimumBlockConfirmations, 
                configureSteps, 
                log);


        public BlockchainCrawlingProcessor CreateBlockStorageProcessor(
            IBlockchainStoreRepositoryFactory blockchainStorageFactory,
            IBlockProgressRepository blockProgressRepository,
            uint minimumBlockConfirmations,
            Action<BlockProcessingSteps> configureSteps = null,
            ILog log = null)
        {
            var processingSteps = new BlockStorageProcessingSteps(blockchainStorageFactory);
            var orchestrator = new BlockCrawlOrchestrator(_ethApiContractService, processingSteps);

            if (blockProgressRepository == null && blockchainStorageFactory is IBlockProgressRepositoryFactory progressRepoFactory)
            {
                blockProgressRepository = progressRepoFactory.CreateBlockProgressRepository();
            }

            blockProgressRepository = blockProgressRepository ?? new InMemoryBlockchainProgressRepository();
            var lastConfirmedBlockNumberService = new LastConfirmedBlockNumberService(_ethApiContractService.Blocks.GetBlockNumber, minimumBlockConfirmations);

            configureSteps?.Invoke(processingSteps);

            return new BlockchainCrawlingProcessor(orchestrator, blockProgressRepository, lastConfirmedBlockNumberService, log);

        }

#endif
    }
}
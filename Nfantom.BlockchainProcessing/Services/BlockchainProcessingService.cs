using Nfantom.ABI.FunctionEncoding.Attributes;
using Nfantom.Contracts.ContractHandlers;
using Nfantom.Contracts.CQS;
using Nfantom.Contracts.Services;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.BlockchainProcessing.Services
{
    public class BlockchainProcessingService : IBlockchainProcessingService
    {
        private readonly IEthApiContractService _ethApiContractService;
        public IBlockchainLogProcessingService Logs { get; }
        public IBlockchainBlockProcessingService Blocks { get; }
    
        public BlockchainProcessingService(IEthApiContractService ethApiContractService)
        {
            _ethApiContractService = ethApiContractService;
            Logs = new BlockchainLogProcessingService(ethApiContractService);
            Blocks = new BlockchainBlockProcessingService(ethApiContractService);
        }

    }
}

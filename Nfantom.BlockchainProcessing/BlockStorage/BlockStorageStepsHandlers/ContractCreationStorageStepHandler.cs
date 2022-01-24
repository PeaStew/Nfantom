using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Repositories;
using Nfantom.BlockchainProcessing.Processor;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockStorage.BlockStorageStepsHandlers
{
    public class ContractCreationStorageStepHandler : ProcessorBaseHandler<ContractCreationVO>
    {
        private readonly IContractRepository _contractRepository;
        public ContractCreationStorageStepHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        protected override Task ExecuteInternalAsync(ContractCreationVO contractCreation)
        {
            return _contractRepository.UpsertAsync(
                contractCreation);
        }
    }
}

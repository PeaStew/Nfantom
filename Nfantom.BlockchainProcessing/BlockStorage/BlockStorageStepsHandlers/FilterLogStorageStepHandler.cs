using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Repositories;
using Nfantom.BlockchainProcessing.Processor;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockStorage.BlockStorageStepsHandlers
{
    public class FilterLogStorageStepHandler : ProcessorBaseHandler<FilterLogVO>
    {
        private readonly ITransactionLogRepository _transactionLogRepository;

        public FilterLogStorageStepHandler(ITransactionLogRepository transactionLogRepository)
        {
            _transactionLogRepository = transactionLogRepository;
        }

        protected override Task ExecuteInternalAsync(FilterLogVO filterLog)
        {
            return _transactionLogRepository.UpsertAsync(filterLog);
        }
    }
}

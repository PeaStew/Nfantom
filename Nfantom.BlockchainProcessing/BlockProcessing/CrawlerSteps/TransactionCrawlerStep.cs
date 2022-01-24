using System.Threading.Tasks;
using Nfantom.Contracts.Services;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockProcessing.CrawlerSteps
{
    public class TransactionCrawlerStep : CrawlerStep<TransactionVO, TransactionVO>
    {
        public TransactionCrawlerStep(IEthApiContractService ethApiContractService) : base(ethApiContractService)
        {
        }

        public override Task<TransactionVO> GetStepDataAsync(TransactionVO parentStep)
        {
            return Task.FromResult(parentStep);
        }
    }
}
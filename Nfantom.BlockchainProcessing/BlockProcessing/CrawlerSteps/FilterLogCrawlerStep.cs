using System.Threading.Tasks;
using Nfantom.Contracts.Services;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockProcessing.CrawlerSteps
{
    public class FilterLogCrawlerStep : CrawlerStep<FilterLogVO, FilterLogVO>
    {
        public FilterLogCrawlerStep(IEthApiContractService ethApiContractService) : base(ethApiContractService)
        {
        }

        public override Task<FilterLogVO> GetStepDataAsync(FilterLogVO filterLogVO)
        {
            return Task.FromResult(filterLogVO);
        }
    }
}
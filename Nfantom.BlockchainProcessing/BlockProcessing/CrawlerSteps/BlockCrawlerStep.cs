using System.Numerics;
using System.Threading.Tasks;
using Nfantom.Contracts.Services;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;

namespace Nfantom.BlockchainProcessing.BlockProcessing.CrawlerSteps
{
    public class BlockCrawlerStep : CrawlerStep<BigInteger, BlockWithTransactions>
    {
        public BlockCrawlerStep(IEthApiContractService ethApiContractService) : base(ethApiContractService)
        {

        }
        public override Task<BlockWithTransactions> GetStepDataAsync(BigInteger blockNumber)
        {
            return EthApi.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(blockNumber.ToHexBigInteger());
        }
    }
}
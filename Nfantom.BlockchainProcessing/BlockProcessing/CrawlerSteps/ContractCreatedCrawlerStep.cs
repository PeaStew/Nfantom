using System.Threading.Tasks;
using Nfantom.Contracts.Services;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockProcessing.CrawlerSteps
{
    public class ContractCreatedCrawlerStep: CrawlerStep<TransactionReceiptVO, ContractCreationVO>
    {
        public bool RetrieveCode { get; set; } = false;
        public ContractCreatedCrawlerStep(IEthApiContractService ethApiContractService) : base(ethApiContractService)
        {
        }

        public override async Task<ContractCreationVO> GetStepDataAsync(TransactionReceiptVO transactionReceiptVO)
        {
            var contractAddress = transactionReceiptVO.TransactionReceipt.ContractAddress;
            bool? hasFailed = transactionReceiptVO.TransactionReceipt.HasErrors();
            string code = null;
            if (RetrieveCode && hasFailed != null)
            {
                code = await EthApi.GetCode.SendRequestAsync(contractAddress).ConfigureAwait(false);
                hasFailed = HasFailedToCreateContract(code);
            }
            return new ContractCreationVO(transactionReceiptVO, code,
                hasFailed ?? false);
        }

        protected virtual bool HasFailedToCreateContract(string code)
        {
            return (code == null) || (code == "0x");
        }
    }



}
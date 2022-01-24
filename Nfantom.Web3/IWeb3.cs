using Nfantom.BlockchainProcessing.Services;
using Nfantom.Contracts.Services;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.Web3
{
    public interface IWeb3
    {
        IClient Client { get; }
        IEthApiContractService Eth { get; }
        IBlockchainProcessingService Processing { get; }
        INetApiService Net { get; }
        IPersonalApiService Personal { get; }
        IShhApiService Shh { get; }
        ITransactionManager TransactionManager { get; set; }
    }
}
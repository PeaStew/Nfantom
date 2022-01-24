using Nfantom.RPC.Eth;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.Services;
using Nfantom.RPC.Eth.Transactions;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.RPC
{
    public interface IEthApiService
    {
        IEthChainId ChainId { get; }
        IEthAccounts Accounts { get; }
        IEthApiBlockService Blocks { get; }
        IEthCoinBase CoinBase { get; }
        IEthApiCompilerService Compile { get; }
        BlockParameter DefaultBlock { get; set; }
        IEthApiFilterService Filters { get; }
        IEthGasPrice GasPrice { get; }
        IEthGetBalance GetBalance { get; }
        IEthGetCode GetCode { get; }
        IEthGetStorageAt GetStorageAt { get; }
        IEthApiMiningService Mining { get; }
        IEthProtocolVersion ProtocolVersion { get; }
        IEthSign Sign { get; }
        IEthSyncing Syncing { get; }
        ITransactionManager TransactionManager { get; set; }
        IEthApiTransactionsService Transactions { get; }
        IEthApiUncleService Uncles { get; }
        IEthFeeHistory FeeHistory { get; }
#if !DOTNET35
        IEtherTransferService GetEtherTransferService();
#endif
    }
}
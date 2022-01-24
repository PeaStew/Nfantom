using System.Threading.Tasks;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public interface ITransactionRepository
    {
        Task UpsertAsync(TransactionReceiptVO transactionReceiptVO, string code, bool failedCreatingContract);

        Task UpsertAsync(TransactionReceiptVO transactionReceiptVO);

        Task<Entities.ITransactionView> FindByBlockNumberAndHashAsync(HexBigInteger blockNumber, string hash);
    }
}
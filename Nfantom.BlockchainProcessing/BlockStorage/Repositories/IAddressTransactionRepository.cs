using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Entities;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public interface IAddressTransactionRepository
    {
        Task UpsertAsync(
            TransactionReceiptVO transactionReceiptVO, string address, string error = null, 
            string newContractAddress = null);

        Task<IAddressTransactionView> FindAsync(
            string address, HexBigInteger blockNumber, string transactionHash);
    }
}
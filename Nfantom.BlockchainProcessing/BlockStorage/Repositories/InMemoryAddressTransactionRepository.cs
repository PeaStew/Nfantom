using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nfantom.BlockchainProcessing.BlockStorage.Entities;
using Nfantom.BlockchainProcessing.BlockStorage.Entities.Mapping;
using Nfantom.Hex.HexTypes;
using Nfantom.RPC.Eth.DTOs;
using Nfantom.RPC.Eth.DTOs.ValueObjects;
using Nfantom.Util;

namespace Nfantom.BlockchainProcessing.BlockStorage.Repositories
{
    public class InMemoryAddressTransactionRepository : IAddressTransactionRepository
    {
        public InMemoryAddressTransactionRepository(List<IAddressTransactionView> records)
        {
            Records = records;
        }

        public List<IAddressTransactionView> Records { get; set; }

        public Task<IAddressTransactionView> FindAsync(string address, HexBigInteger blockNumber, string transactionHash)
        {
            IAddressTransactionView result = Records.FirstOrDefault(
                t => t.BlockNumber == blockNumber.Value.ToString() 
                && t.Hash == transactionHash 
                && AddressUtil.Current.AreAddressesTheSame(t.Address, address));

            return Task.FromResult(result);
        }

        public async Task UpsertAsync(TransactionReceiptVO transactionReceiptVO, string address, string error = null, string newContractAddress = null)
        {
            var entity = await FindAsync(address, transactionReceiptVO.Transaction.BlockNumber, transactionReceiptVO.TransactionHash).ConfigureAwait(false);
            if(entity != null) Records.Remove(entity);
            Records.Add(transactionReceiptVO.MapToStorageEntityForUpsert(address));
        }
    }
}

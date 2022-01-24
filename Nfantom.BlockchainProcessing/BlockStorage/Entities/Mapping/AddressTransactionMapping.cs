namespace Nfantom.BlockchainProcessing.BlockStorage.Entities.Mapping
{
    public static class AddressTransactionMapping
    {
        public static void Map(this AddressTransaction to, Nfantom.RPC.Eth.DTOs.Transaction @from, string address)
        {
            to.BlockNumber = @from.BlockNumber.Value.ToString();
            to.Hash = @from.TransactionHash;
            to.Address = address;
        }

        public static AddressTransaction MapToStorageEntityForUpsert(this Nfantom.RPC.Eth.DTOs.ValueObjects.TransactionReceiptVO @from, string address)
        {
            return from.MapToStorageEntityForUpsert<AddressTransaction>(address);
        }

        public static TEntity MapToStorageEntityForUpsert<TEntity>(this Nfantom.RPC.Eth.DTOs.ValueObjects.TransactionReceiptVO @from, string address)
            where TEntity : AddressTransaction, new()
        {
            return MapToStorageEntityForUpsert<TEntity>(new TEntity(), from, address);
        }

        public static TEntity MapToStorageEntityForUpsert<TEntity>(this TEntity to, Nfantom.RPC.Eth.DTOs.ValueObjects.TransactionReceiptVO @from, string address)
            where TEntity : AddressTransaction
        {
            to.Map(from.Transaction, address);
            to.UpdateRowDates();
            return to;
        }
    }
}

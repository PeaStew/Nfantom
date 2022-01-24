namespace Nfantom.BlockchainProcessing.BlockStorage.Entities
{
    public interface IAddressTransactionView
    {
        string BlockNumber { get;}
        string Hash { get;}
        string Address  { get; }
    }
}

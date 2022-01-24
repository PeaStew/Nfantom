namespace Nfantom.BlockchainProcessing.ProgressRepositories
{
    public interface IBlockProgressRepositoryFactory
    {
        IBlockProgressRepository CreateBlockProgressRepository();
    }
}

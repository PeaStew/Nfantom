namespace Nfantom.KeyStore.Crypto
{
    public interface IRandomBytesGenerator
    {
        byte[] GenerateRandomInitialisationVector();
        byte[] GenerateRandomSalt();
    }
}
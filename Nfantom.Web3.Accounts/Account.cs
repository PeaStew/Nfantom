using System.Numerics;
using Nfantom.Hex.HexConvertors.Extensions;
using Nfantom.KeyStore;
using Nfantom.RPC.Accounts;
using Nfantom.RPC.NonceServices;
using Nfantom.RPC.TransactionManagers;
using Nfantom.Signer;

namespace Nfantom.Web3.Accounts
{
    public class Account : IAccount
    {
        private INonceService _nonceService;
        public BigInteger? ChainId { get; }

#if !PCL
        public static Account LoadFromKeyStoreFile(string filePath, string password)
        {
            var keyStoreService = new KeyStoreService();
            var key = keyStoreService.DecryptKeyStoreFromFile(password, filePath);
            return new Account(key);
        }
#endif
        public static Account LoadFromKeyStore(string json, string password, BigInteger? chainId = null)
        {
            var keyStoreService = new KeyStoreService();
            var key = keyStoreService.DecryptKeyStoreFromJson(password, json);
            return new Account(key, chainId);
        }

        public string PrivateKey { get; private set; }
        public string PublicKey { get; private set; }


        public Account(EthECKey key, BigInteger? chainId = null)
        {
            ChainId = chainId;
            Initialise(key);
        }

        public Account(string privateKey, BigInteger? chainId = null)
        {
            ChainId = chainId;
            Initialise(new EthECKey(privateKey));
        }

        public Account(byte[] privateKey, BigInteger? chainId = null)
        {
            ChainId = chainId;
            Initialise(new EthECKey(privateKey, true));
        }

        public Account(EthECKey key, Chain chain) : this(key, (int)chain)
        {
        }

        public Account(string privateKey, Chain chain) : this(privateKey, (int)chain)
        {
        }

        public Account(byte[] privateKey, Chain chain) : this(privateKey, (int)chain)
        {
        }

        private void Initialise(EthECKey key)
        {
            PrivateKey = key.GetPrivateKey();
            Address = key.GetPublicAddress();
            PublicKey = key.GetPubKey().ToHex();
            InitialiseDefaultTransactionManager();
        }

        protected virtual void InitialiseDefaultTransactionManager()
        {
            TransactionManager = new AccountSignerTransactionManager(null, this, ChainId);
        }

        public string Address { get; protected set; }
        public ITransactionManager TransactionManager { get; protected set; }

        public INonceService NonceService
        {
            get => _nonceService ?? (_nonceService = new InMemoryNonceService(Address, TransactionManager.Client));
            set => _nonceService = value;
        }
    }
}
using System.Numerics;
using System.Threading.Tasks;
using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Accounts;
using Nfantom.RPC.NonceServices;
using Nfantom.RPC.TransactionManagers;
using Nfantom.Signer;

namespace Nfantom.Web3.Accounts.External
{
    public class ExternalAccount : IAccount
    {
        public ExternalAccount(IEthExternalSigner externalSigner, BigInteger? chainId = null)
        {
            ExternalSigner = externalSigner;
            ChainId = chainId;
        }

        public ExternalAccount(string address, IEthExternalSigner externalSigner, BigInteger? chainId = null)
        {
            ChainId = chainId;
            Address = address;
            ExternalSigner = externalSigner;
        }

        public IEthExternalSigner ExternalSigner { get; }
        public BigInteger? ChainId { get; }

        public string Address { get; protected set; }
        public ITransactionManager TransactionManager { get; protected set; }
        public INonceService NonceService { get; set; }

        public async Task InitialiseAsync()
        {
            Address = await ExternalSigner.GetAddressAsync().ConfigureAwait(false);
        }

        public void InitialiseDefaultTransactionManager(IClient client)
        {
            TransactionManager = new ExternalAccountSignerTransactionManager(client, this, ChainId);
        }
    }
}
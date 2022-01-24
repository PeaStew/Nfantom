using Nfantom.RPC.Accounts;
using Nfantom.RPC.NonceServices;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.Web3.Accounts.Managed
{
    public class ManagedAccount : IAccount
    {
        public ManagedAccount(string accountAddress, string password)
        {
            Address = accountAddress;
            Password = password;
            InitialiseDefaultTransactionManager();
        }

        public ManagedAccount(string accountAddress, string password,
            ManagedAccountTransactionManager transactionManager)
        {
            Address = accountAddress;
            Password = password;
            TransactionManager = transactionManager;
            transactionManager.SetAccount(this);
        }

        public string Password { get; protected set; }

        public string Address { get; protected set; }

        public ITransactionManager TransactionManager { get; protected set; }

        public INonceService NonceService { get; set; }

        protected virtual void InitialiseDefaultTransactionManager()
        {
            TransactionManager = new ManagedAccountTransactionManager(null, this);
        }
    }
}
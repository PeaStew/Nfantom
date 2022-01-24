using Nfantom.JsonRpc.Client;
using Nfantom.RPC.Accounts;
using Nfantom.RPC.TransactionManagers;

namespace Nfantom.Contracts.ContractHandlers
{
#if !DOTNET35
    public abstract class ContractTransactionHandlerBase
    {
        protected IClient Client { get; }
        protected IAccount Account { get; }
        protected ITransactionManager TransactionManager { get; }

        protected ContractTransactionHandlerBase(ITransactionManager transactionManager)
        {
            Client = transactionManager.Client;
            Account = transactionManager.Account;
            TransactionManager = transactionManager;
        }

        public virtual string GetAccountAddressFrom()
        {
            return Account?.Address;
        }
    }
#endif
}
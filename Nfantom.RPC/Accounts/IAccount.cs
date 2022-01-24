using Nfantom.RPC.TransactionManagers;
using System;
using System.Collections.Generic;
using System.Text;
using Nfantom.RPC.NonceServices;

namespace Nfantom.RPC.Accounts
{
    public interface IAccount
    {
        string Address { get; }
        ITransactionManager TransactionManager { get; }

        INonceService NonceService { get; set; }
    }
}

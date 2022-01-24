using Nfantom.RPC.Personal;

namespace Nfantom.RPC
{
    public interface IPersonalApiService
    {
        IPersonalListAccounts ListAccounts { get; }
        IPersonalLockAccount LockAccount { get; }
        IPersonalNewAccount NewAccount { get; }
        IPersonalSignAndSendTransaction SignAndSendTransaction { get; }
        IPersonalUnlockAccount UnlockAccount { get; }
    }
}